using AvatarSystem;
using Cysharp.Threading.Tasks;
using DCL.Components;
using DCL.Configuration;
using DCL.Controllers;
using DCL.Helpers;
using DCL.Interface;
using DCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using UnityEngine;
using LOD = AvatarSystem.LOD;

namespace DCL.ECSComponents
{
    public interface IAvatarShape
    {
        /// <summary>
        /// This will initialize the AvatarShape and set
        /// </summary>
        void Init();

        /// <summary>
        /// Clean up the avatar shape so we can reutilizate it using the pool
        /// </summary>
        void Cleanup();

        /// <summary>
        /// Apply the model of the avatar, it will reload if necessary
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="entity"></param>
        /// <param name="newModel"></param>
        void ApplyModel(IParcelScene scene, IDCLEntity entity, PBAvatarShape newModel);

        /// <summary>
        /// Get the transform of the avatar shape
        /// </summary>
        Transform transform { get; }

        /// <summary>
        /// Get non-monobehaviour internal IAvatar object that contains the merged renderer
        /// </summary>
        IAvatar internalAvatar { get; }
    }

    public class AvatarShape : MonoBehaviour, IHideAvatarAreaHandler, IPoolableObjectContainer, IAvatarShape, IPoolLifecycleHandler
    {
        private const float AVATAR_Y_AXIS_OFFSET = -0.72f;
        private const float MINIMUM_PLAYERNAME_HEIGHT = 2.7f;
        internal const string IN_HIDE_AREA = "IN_HIDE_AREA";
        private const string OPEN_PASSPORT_SOURCE = "World";

        [SerializeField] private GameObject avatarContainer;
        [SerializeField] internal Collider avatarCollider;

        [SerializeField] internal AvatarOnPointerDown onPointerDown;
        [SerializeField] internal AvatarOutlineOnHoverEvent outlineOnHover;
        [SerializeField] internal GameObject playerNameContainer;
        [SerializeField] private Transform baseAvatarContainer;
        [SerializeField] internal BaseAvatarReferences baseAvatarReferencesPrefab;

        internal IAvatarMovementController avatarMovementController;
        internal IPlayerName playerName;
        internal IAvatarReporterController avatarReporterController;

        private BaseVariable<(string playerId, string source)> currentPlayerInfoCardId;

        internal bool initializedPosition = false;

        internal Player player = null;
        internal BaseDictionary<string, Player> otherPlayers => DataStore.i.player.otherPlayers;

        private IAvatarAnchorPoints anchorPoints = new AvatarAnchorPoints();
        internal IAvatar avatar;
        internal CancellationTokenSource loadingCts;
        private ILazyTextureObserver currentLazyObserver;
        private IUserProfileBridge userProfileBridge;
        private bool isGlobalSceneAvatar = true;

        public IPoolableObject poolableObject { get; set; }
        internal PBAvatarShape model;
        internal IDCLEntity entity;

        private Service<IAvatarFactory> avatarFactory;
        private Service<IEmotesCatalogService> emotesCatalog;
        public IAvatar internalAvatar => avatar;

        private void Awake()
        {
            avatarMovementController = GetComponent<IAvatarMovementController>();
            // TODO: avoid instantiation, user profile bridge should be retrieved from the service locator
            userProfileBridge = new UserProfileWebInterfaceBridge();

            currentPlayerInfoCardId = DataStore.i.HUDs.currentPlayerId;
            Visibility visibility = new Visibility();
            avatarMovementController.SetAvatarTransform(transform);

            // Right now the avatars that are not part of the global scene of avatar are not using LOD since
            // AvatarsLodController are no taking them into account. It needs product definition and a refactor to include them
            LOD avatarLOD = new LOD(avatarContainer, visibility, avatarMovementController);
            AvatarAnimatorLegacy animator = GetComponentInChildren<AvatarAnimatorLegacy>();

            //Ensure base avatar references
            var baseAvatarReferences = baseAvatarContainer.GetComponentInChildren<IBaseAvatarReferences>() ?? Instantiate(baseAvatarReferencesPrefab, baseAvatarContainer);

            avatar = avatarFactory.Ref.CreateAvatarWithHologram(avatarContainer, new BaseAvatar(baseAvatarReferences), animator, avatarLOD, visibility);

            avatarReporterController ??= new AvatarReporterController(Environment.i.world.state);

            onPointerDown.OnPointerDownReport += PlayerClicked;
            onPointerDown.OnPointerEnterReport += PlayerPointerEnter;
            onPointerDown.OnPointerExitReport += PlayerPointerExit;
            outlineOnHover.OnPointerEnterReport += PlayerPointerEnter;
            outlineOnHover.OnPointerExitReport += PlayerPointerExit;
        }

        public void Init()
        {
            // The avatars have an offset in the Y axis, so we set the offset after the avatar has been restored from the pool
            transform.position = new Vector3(transform.position.x, AVATAR_Y_AXIS_OFFSET, transform.position.z);
            SetPlayerNameReference();
        }

        private void SetPlayerNameReference()
        {
            if (playerName != null)
                return;
            playerName = GetComponentInChildren<IPlayerName>();
            playerName?.Hide(true);
        }

        private void PlayerClicked()
        {
            if (model == null)
                return;
            currentPlayerInfoCardId.Set((model.Id, OPEN_PASSPORT_SOURCE));
        }

        public void OnDestroy()
        {
            Cleanup();

            if (poolableObject != null && poolableObject.isInsidePool)
                poolableObject.RemoveFromPool();
        }

        public async void ApplyModel(IParcelScene scene, IDCLEntity entity, PBAvatarShape newModel)
        {
            this.entity = entity;

            isGlobalSceneAvatar = scene.sceneData.sceneNumber == EnvironmentSettings.AVATAR_GLOBAL_SCENE_NUMBER;

            DisablePassport();

            bool needsLoading = !AvatarUtils.HaveSameWearablesAndColors(model,newModel);
            model = newModel;

#if UNITY_EDITOR
            gameObject.name = $"Avatar Shape {model.GetName()}";
#endif

            // To deal with the cases in which the entity transform was configured before the AvatarShape
            if (!initializedPosition)
            {
                OnEntityTransformChanged(entity.gameObject.transform.localPosition,
                    entity.gameObject.transform.localRotation, true);
            }

            // NOTE: we subscribe here to transform changes since we might "lose" the message
            // if we subscribe after a any yield
            entity.OnTransformChange -= OnEntityTransformChanged;
            entity.OnTransformChange += OnEntityTransformChanged;

            var wearableItems = model.GetWereables().ToList();
            wearableItems.Add(model.GetBodyShape());

            // temporarily hardcoding the embedded emotes until the user profile provides the equipped ones
            var embeddedEmotesSo = await emotesCatalog.Ref.GetEmbeddedEmotes();
            wearableItems.AddRange(embeddedEmotesSo.GetAllIds());
            HashSet<string> emotes = new HashSet<string>();
            emotes.UnionWith(embeddedEmotesSo.GetAllIds());

            if (avatar.status != IAvatar.Status.Loaded || needsLoading)
            {
                loadingCts?.Cancel();
                loadingCts?.Dispose();
                loadingCts = new CancellationTokenSource();
                try
                {
                    await LoadAvatar(wearableItems,emotes);
                }
                catch (Exception e)
                {
                    // If the load of the avatar fails, we do it silently so the scene continue to operate.
                    // The LoadAvatar function will show the wearables but not the error itself, we need extra context
                    if (e is not OperationCanceledException)
                        Debug.LogException(e);
                }
            }

            // If the model contains a value for expressionTriggerId then we try it, if value doesn't exist, we skip
            if(model.HasExpressionTriggerId)
                avatar.GetEmotesController().PlayEmote(model.ExpressionTriggerId, model.GetExpressionTriggerTimestamp());

            UpdatePlayerStatus(entity, model);

            onPointerDown.Initialize(
                new OnPointerEvent.Model()
                {
                    type = OnPointerDown.NAME,
                    button = WebInterface.ACTION_BUTTON.POINTER.ToString(),
                    hoverText = "View Profile"
                },
                entity, player
            );

            outlineOnHover.Initialize(new OnPointerEvent.Model(), entity, player.avatar);

            avatarCollider.gameObject.SetActive(true);

            EnablePassport();

            onPointerDown.SetColliderEnabled(isGlobalSceneAvatar);
            onPointerDown.SetOnClickReportEnabled(isGlobalSceneAvatar);
        }

        private async UniTask LoadAvatar(List<string> wearableItems, HashSet<string> emotes)
        {
            try
            {
                //TODO Add Collider to the AvatarSystem
                //TODO Without this the collider could get triggered disabling the avatar container,
                // this would stop the loading process due to the underlying coroutines of the AssetLoader not starting
                avatarCollider.gameObject.SetActive(false);

                SetImpostor(model.Id);
                UserProfile profile = userProfileBridge.Get(model.Id);
                playerName.SetName(model.GetName(), profile?.hasClaimedName ?? false, profile?.isGuest ?? false);
                playerName.Show(true);
                await avatar.Load(wearableItems, emotes.ToList(),new AvatarSettings
                {
                    playerName = model.GetName(),
                    bodyshapeId = model.GetBodyShape(),
                    eyesColor = model.GetEyeColor().ToUnityColor(),
                    skinColor = model.GetSkinColor().ToUnityColor(),
                    hairColor = model.GetHairColor().ToUnityColor(),
                }, loadingCts.Token);
            }
            catch (OperationCanceledException)
            {
                Cleanup();
                throw;
            }
            catch (Exception e)
            {
                Cleanup();
                Debug.Log($"Avatar.Load failed with wearables:[{string.Join(",", wearableItems)}] for bodyshape:{model.BodyShape} and player {model.Name}");
                throw;
            }
            finally
            {
                loadingCts?.Dispose();
                loadingCts = null;
            }
        }

        public void SetImpostor(string userId)
        {
            currentLazyObserver?.RemoveListener(avatar.SetImpostorTexture);
            if (string.IsNullOrEmpty(userId))
                return;

            UserProfile userProfile = UserProfileController.GetProfileByUserId(userId);
            if (userProfile == null)
                return;

            currentLazyObserver = userProfile.bodySnapshotObserver;
            currentLazyObserver.AddListener(avatar.SetImpostorTexture);
        }

        private void PlayerPointerExit() { playerName?.SetForceShow(false); }

        private void PlayerPointerEnter() { playerName?.SetForceShow(true); }

        internal void UpdatePlayerStatus(IDCLEntity entity, PBAvatarShape model)
        {
            // Remove the player status if the userId changes
            if (player != null && (player.id != model.Id || player.name != model.GetName()))
                otherPlayers.Remove(player.id);

            if (isGlobalSceneAvatar && string.IsNullOrEmpty(model?.GetName()))
                return;

            bool isNew = player == null;
            if (isNew)
                player = new Player();

            bool isNameDirty = player.name != model.GetName();

            player.id = model.Id;
            player.name = model.GetName();
            player.isTalking = model.Talking;
            player.worldPosition = entity.gameObject.transform.position;
            player.avatar = avatar;
            player.onPointerDownCollider = onPointerDown;
            player.collider = avatarCollider;

            if (isNew)
            {
                player.playerName = playerName;
                player.playerName.Show();
                player.anchorPoints = anchorPoints;
                if (isGlobalSceneAvatar)
                {
                    // TODO: Note: This is having a problem, sometimes the users has been detected as new 2 times and it shouldn't happen
                    // we should investigate this
                    if (otherPlayers.ContainsKey(player.id))
                        otherPlayers.Remove(player.id);
                    otherPlayers.Add(player.id, player);
                }
                avatarReporterController.ReportAvatarRemoved();
            }

            avatarReporterController.SetUp(entity.scene.sceneData.sceneNumber, player.id);

            float height = AvatarSystemUtils.AVATAR_Y_OFFSET + avatar.extents.y;

            anchorPoints.Prepare(avatarContainer.transform, avatar.GetBones(), height);

            player.playerName.SetIsTalking(model.Talking);
            player.playerName.SetYOffset(Mathf.Max(MINIMUM_PLAYERNAME_HEIGHT, height));

            if (isNameDirty)
            {
                UserProfile profile = userProfileBridge.Get(model.Id);
                player.playerName.SetName(model.GetName(), profile?.hasClaimedName ?? false, profile?.isGuest ?? false);
            }
        }

        private void Update()
        {
            if (player == null || entity == null)
                return;

            player.worldPosition = entity.gameObject.transform.position;
            player.forwardDirection = entity.gameObject.transform.forward;
            avatarReporterController.ReportAvatarPosition(player.worldPosition);
        }

        public void DisablePassport()
        {
            if (onPointerDown.collider == null)
                return;

            onPointerDown.SetPassportEnabled(false);
        }

        public void EnablePassport()
        {
            if (onPointerDown.collider == null)
                return;

            onPointerDown.SetPassportEnabled(true);
        }

        private void OnEntityTransformChanged(Vector3 newPosition, Quaternion newRotation)
        {
            OnEntityTransformChanged(newPosition, newRotation, !initializedPosition);
        }

        private void OnEntityTransformChanged(Vector3 position, Quaternion rotation, bool inmediate)
        {
            if (entity == null)
                return;

            if (isGlobalSceneAvatar)
            {
                avatarMovementController.OnTransformChanged(position, rotation, inmediate);
            }
            else
            {
                var scenePosition = Helpers.Utils.GridToWorldPosition(entity.scene.sceneData.basePosition.x, entity.scene.sceneData.basePosition.y);
                avatarMovementController.OnTransformChanged(scenePosition + position, rotation, inmediate);
            }
            initializedPosition = true;
        }

        public void OnPoolRelease()
        {
            Cleanup();
        }

        public void OnPoolGet()
        {
            initializedPosition = false;
            model = new PBAvatarShape();
            player = null;
            SetPlayerNameReference();
        }

        public void ApplyHideAvatarModifier()
        {
            avatar.AddVisibilityConstraint(IN_HIDE_AREA);
            onPointerDown.gameObject.SetActive(false);
            playerNameContainer.SetActive(false);
        }

        public void RemoveHideAvatarModifier()
        {
            avatar.RemoveVisibilityConstrain(IN_HIDE_AREA);
            onPointerDown.gameObject.SetActive(true);
            playerNameContainer.SetActive(true);
        }

        public void Cleanup()
        {
            playerName?.Hide(true);
            if (player != null)
            {
                otherPlayers.Remove(player.id);
                player = null;
            }

            loadingCts?.Cancel();
            loadingCts?.Dispose();
            loadingCts = null;

            currentLazyObserver?.RemoveListener(avatar.SetImpostorTexture);
            avatar.Dispose();

            if (poolableObject != null)
            {
                poolableObject.OnRelease -= Cleanup;
            }

            onPointerDown.OnPointerDownReport -= PlayerClicked;
            onPointerDown.OnPointerEnterReport -= PlayerPointerEnter;
            onPointerDown.OnPointerExitReport -= PlayerPointerExit;
            outlineOnHover.OnPointerEnterReport -= PlayerPointerEnter;
            outlineOnHover.OnPointerExitReport -= PlayerPointerExit;

            if (entity != null)
            {
                entity.OnTransformChange = null;
                entity = null;
            }

            avatarReporterController.ReportAvatarRemoved();
        }

        [ContextMenu("Print current profile")]
        private void PrintCurrentProfile() { Debug.Log(JsonUtility.ToJson(model)); }
    }
}

