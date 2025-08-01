using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using DCL;
using DCL.Emotes;
using DCL.Tasks;
using GPUSkinning;
using UnityEngine;

namespace AvatarSystem
{
    // [ADR 65 - https://github.com/decentraland/adr]
    public class Avatar : IAvatar
    {
        private const string NEW_CDN_FF = "ab-new-cdn";

        private const float RESCALING_BOUNDS_FACTOR = 100f;
        internal const string LOADING_VISIBILITY_CONSTRAIN = "Loading";

        protected readonly ILoader loader;
        protected readonly IVisibility visibility;

        private readonly IAvatarCurator avatarCurator;
        private readonly ILOD lod;
        private readonly IGPUSkinning gpuSkinning;
        private readonly IGPUSkinningThrottlerService gpuSkinningThrottlerService;
        private readonly IAvatarEmotesController emotesController;

        private CancellationTokenSource loadCancellationToken;
        public IAvatar.Status status { get; private set; } = IAvatar.Status.Idle;
        public Vector3 extents { get; private set; }
        public int lodLevel => lod?.lodIndex ?? 0;
        public event Action<Renderer> OnCombinedRendererUpdate;
        private FeatureFlag featureFlags => DataStore.i.featureFlags.flags.Get();

        internal Avatar(IAvatarCurator avatarCurator, ILoader loader,
            IVisibility visibility, ILOD lod, IGPUSkinning gpuSkinning, IGPUSkinningThrottlerService gpuSkinningThrottlerService,
            IAvatarEmotesController emotesController)
        {
            this.avatarCurator = avatarCurator;
            this.loader = loader;
            this.visibility = visibility;
            this.lod = lod;
            this.gpuSkinning = gpuSkinning;
            this.gpuSkinningThrottlerService = gpuSkinningThrottlerService;
            this.emotesController = emotesController;
        }

        /// <summary>
        /// Starts the loading process for the Avatar.
        /// </summary>
        /// <param name="wearablesIds"></param>
        /// <param name="settings"></param>
        /// <param name="ct"></param>
        public async UniTask Load(List<string> wearablesIds, List<string> emotesIds, AvatarSettings settings, CancellationToken ct = default)
        {
            status = IAvatar.Status.Idle;

            loadCancellationToken = loadCancellationToken.SafeRestart();
            CancellationToken linkedCt = CancellationTokenSource.CreateLinkedTokenSource(ct, loadCancellationToken.Token).Token;

            try { await LoadTry(wearablesIds, emotesIds, settings, linkedCt); }
            catch (OperationCanceledException)
            {
                // Cancel any ongoing process except the current loadCancellationToken
                // since it was provoking a double cancellation thus inconsistencies in the flow
                // TODO: disposing collaborators is an anti-pattern in the current context. Disposed objects should not be reused. Instead all collaborators should handle OperationCancelledException by their own so the internal state is restored
                CancelAndRestoreOngoingProcessesExceptTheLoading();

                throw;
            }
            catch (Exception e)
            {
                // Cancel any ongoing process except the current loadCancellationToken
                // since it was provoking a double cancellation thus inconsistencies in the flow
                // TODO: disposing collaborators is an anti-pattern in the current context. Disposed objects should not be reused. Instead all collaborators should handle OperationCancelledException by their own so the internal state is restored
                CancelAndRestoreOngoingProcessesExceptTheLoading();

                Debug.Log($"Avatar.Load failed with wearables:[{string.Join(",", wearablesIds)}] " +
                          $"for bodyshape:{settings.bodyshapeId} and player {settings.playerName}");

                if (e.InnerException != null)
                    ExceptionDispatchInfo.Capture(e.InnerException).Throw();
                else
                    throw;
            }
        }

        protected virtual async UniTask LoadTry(List<string> wearablesIds, List<string> emotesIds, AvatarSettings settings, CancellationToken linkedCt)
        {
            List<WearableItem> emotes = await LoadWearables(wearablesIds, emotesIds, settings, linkedCt: linkedCt);

            GameObject container = loader.bodyshapeContainer;

            if (featureFlags.IsFeatureEnabled(NEW_CDN_FF))
            {
                if (loader.bodyshapeContainer.transform.childCount > 0)
                {
                    loader.bodyshapeContainer.transform.Find("Armature");
                    Transform child = loader.bodyshapeContainer.transform.GetChild(0);

                    // Asset bundles assets dont have the gltf-scene name as the root, they have the file hash, for this particular object we need it to be Armature
                    child.name = "Armature";
                }
            }
            else
            {
                GameObject parent = GetDeepParentOf(loader.bodyshapeContainer, "Armature");
                container = parent != null ? parent : container;
            }

            Prepare(settings, emotes, container);
            Bind();
            Inform(loader.combinedRenderer);
        }

        private GameObject GetDeepParentOf(GameObject container, string childName)
        {
            foreach (Transform child in container.transform)
                return child.name == childName ? child.parent.gameObject : GetDeepParentOf(child.gameObject, childName);

            return null;
        }

        protected async UniTask<List<WearableItem>> LoadWearables(List<string> wearablesIds, List<string> emotesIds, AvatarSettings settings, SkinnedMeshRenderer bonesRenderers = null, CancellationToken linkedCt = default)
        {
            BodyWearables bodyWearables;
            List<WearableItem> wearables;
            List<WearableItem> emotes;

            (bodyWearables, wearables, emotes) = await avatarCurator.Curate(settings, wearablesIds, emotesIds, linkedCt);

            if (!loader.IsValidForBodyShape(bodyWearables))
                visibility.AddGlobalConstrain(LOADING_VISIBILITY_CONSTRAIN);

            await loader.Load(bodyWearables, wearables, settings, bonesRenderers, linkedCt);
            return emotes;
        }

        protected void Prepare(AvatarSettings settings, List<WearableItem> emotes, GameObject container)
        {
            //Scale the bounds due to the giant avatar not being skinned yet
            extents = loader.combinedRenderer.localBounds.extents * 2f / RESCALING_BOUNDS_FACTOR;

            emotesController.LoadEmotes(settings.bodyshapeId, emotes, container);
            gpuSkinning.Prepare(loader.combinedRenderer);
            gpuSkinningThrottlerService.Register(gpuSkinning);
        }

        protected void Bind()
        {
            visibility.Bind(gpuSkinning.renderer, loader.facialFeaturesRenderers);
            visibility.RemoveGlobalConstrain(LOADING_VISIBILITY_CONSTRAIN);
            lod.Bind(gpuSkinning.renderer);
        }

        protected void Inform(Renderer loaderCombinedRenderer)
        {
            status = IAvatar.Status.Loaded;
            OnCombinedRendererUpdate?.Invoke(loaderCombinedRenderer);
        }

        public virtual void AddVisibilityConstraint(string key)
        {
            visibility.AddGlobalConstrain(key);
        }

        public void RemoveVisibilityConstrain(string key) =>
            visibility.RemoveGlobalConstrain(key);

        public IAvatarEmotesController GetEmotesController() => emotesController;

        public void SetLODLevel(int lodIndex) =>
            lod.SetLodIndex(lodIndex);

        public void SetAnimationThrottling(int framesBetweenUpdate) =>
            gpuSkinningThrottlerService.ModifyThrottling(gpuSkinning, framesBetweenUpdate);

        public void SetImpostorTexture(Texture2D impostorTexture) =>
            lod.SetImpostorTexture(impostorTexture);

        public void SetImpostorTint(Color color) =>
            lod.SetImpostorTint(color);

        public Transform[] GetBones() =>
            loader.GetBones();

        public Renderer GetMainRenderer() =>
            gpuSkinning.renderer;

        public IReadOnlyList<SkinnedMeshRenderer> originalVisibleRenderers => loader.originalVisibleRenderers;

        public void Dispose()
        {
            loadCancellationToken?.Cancel();
            loadCancellationToken?.Dispose();
            loadCancellationToken = null;
            CancelAndRestoreOngoingProcessesExceptTheLoading();
        }

        private void CancelAndRestoreOngoingProcessesExceptTheLoading()
        {
            status = IAvatar.Status.Idle;
            avatarCurator?.Dispose();
            loader?.Dispose();
            visibility?.Dispose();
            lod?.Dispose();
            gpuSkinningThrottlerService?.Unregister(gpuSkinning);
        }
    }
}
