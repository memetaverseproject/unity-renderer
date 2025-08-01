using System;
using System.Collections.Generic;
using AvatarSystem;
using Cysharp.Threading.Tasks;
using DCL;
using DCL.Components;
using DCL.Emotes;
using DCL.Helpers;
using UnityEngine;
using Environment = DCL.Environment;

public enum AvatarAnimation
{
    IDLE,
    RUN,
    WALK,
    EMOTE,
    JUMP,
    FALL,
}

public static class AvatarAnimationExtensions
{
    public static bool ShouldLoop(this AvatarAnimation avatarAnimation)
    {
        return avatarAnimation == AvatarAnimation.RUN ||
               avatarAnimation == AvatarAnimation.IDLE ||
               avatarAnimation == AvatarAnimation.FALL ||
               avatarAnimation == AvatarAnimation.WALK;
    }
}

public class AvatarAnimatorLegacy : MonoBehaviour, IPoolLifecycleHandler, IAnimator
{
    const float IDLE_TRANSITION_TIME = 0.2f;
    const float RUN_TRANSITION_TIME = 0.15f;
    const float WALK_TRANSITION_TIME = 0.15f;
    const float WALK_MAX_SPEED = 6;
    const float RUN_MIN_SPEED = 4f;
    const float WALK_MIN_SPEED = 0.1f;
    const float WALK_RUN_SWITCH_TIME = 1.5f;
    const float JUMP_TRANSITION_TIME = 0.01f;
    const float FALL_TRANSITION_TIME = 0.5f;
    const float EXPRESSION_EXIT_TRANSITION_TIME = 0.2f;
    const float EXPRESSION_ENTER_TRANSITION_TIME = 0.1f;
    const float OTHER_PLAYER_MOVE_THRESHOLD = 0.02f;

    const float AIR_EXIT_TRANSITION_TIME = 0.2f;

    const float ELEVATION_OFFSET = 0.6f;
    const float RAY_OFFSET_LENGTH = 3.0f;

    // Time it takes to determine if a character is grounded when vertical velocity is 0
    const float FORCE_GROUND_TIME = 0.05f;

    // Minimum vertical speed used to consider whether an avatar is on air
    const float MIN_VERTICAL_SPEED_AIR = 0.025f;

    [System.Serializable]
    public class AvatarLocomotion
    {
        public AnimationClip idle;
        public AnimationClip walk;
        public AnimationClip run;
        public AnimationClip jump;
        public AnimationClip fall;
    }

    [System.Serializable]
    public class BlackBoard
    {
        public float walkSpeedFactor;
        public float runSpeedFactor;
        public float movementSpeed;
        public float verticalSpeed;
        public bool isGrounded;
        public string expressionTriggerId;
        public long expressionTriggerTimestamp;
        public float deltaTime;
        public bool shouldLoop;
    }

    [SerializeField] internal AvatarLocomotion femaleLocomotions;
    [SerializeField] internal AvatarLocomotion maleLocomotions;
    [SerializeField] internal AvatarLocomotion monkeyLocomotions;
    [SerializeField] internal AvatarLocomotion kidMonkeyLocomotions;
    AvatarLocomotion currentLocomotions;

    public new Animation animation;
    public BlackBoard blackboard;
    public Transform target;

    internal System.Action<BlackBoard> currentState;

    Vector3 lastPosition;
    bool isOwnPlayer = false;
    private AvatarAnimationEventHandler animEventHandler;

    private float lastOnAirTime = 0;

    private Dictionary<string, EmoteClipData> emoteClipDataMap = new ();

    private string runAnimationName;
    private string walkAnimationName;
    private string idleAnimationName;
    private string jumpAnimationName;
    private string fallAnimationName;
    private AvatarAnimation latestAnimationState;
    private AnimationState runAnimationState;
    private AnimationState walkAnimationState;
    private bool isUpdateRegistered = false;

    private Ray rayCache;
    private bool hasTarget;
    private EmoteClipData lastExtendedEmoteData;
    private string lastCrossFade;
    private AnimationState currentEmote;
    private int lastEmoteLoopCount;

    private void Awake()
    {
        hasTarget = target != null;
        if (!hasTarget)
            Debug.LogError(message: $"Target is not assigned. {nameof(UpdateInterface)} will not work correctly.", this);
    }

    public void Start() { OnPoolGet(); }

    // AvatarSystem entry points
    public bool Prepare(string bodyshapeId, GameObject container)
    {
        StopEmote();

        animation = container.gameObject.GetOrCreateComponent<Animation>();
        container.gameObject.GetOrCreateComponent<StickerAnimationListener>();

        PrepareLocomotionAnims(bodyshapeId);
        SetIdleFrame();
        animation.Sample();
        InitializeAvatarAudioAndParticleHandlers(animation);

        // since the avatar can be updated when changing a wearable we shouldn't register to the update event twice
        if (!isUpdateRegistered)
        {
            isUpdateRegistered = true;

            if (isOwnPlayer)
            {
                DCLCharacterController.i.OnUpdateFinish += OnUpdateWithDeltaTime;
            }
            else
            {
                Environment.i.platform.updateEventHandler.AddListener(IUpdateEventHandler.EventType.Update, OnEventHandlerUpdate);
            }

        }

        return true;
    }

    private void PrepareLocomotionAnims(string bodyshapeId)
    {
        if (bodyshapeId.Contains(WearableLiterals.BodyShapes.MALE))
        {
            currentLocomotions = maleLocomotions;
        }
        else if (bodyshapeId.Contains(WearableLiterals.BodyShapes.FEMALE))
        {
            currentLocomotions = femaleLocomotions;
        }
        else if (bodyshapeId.Contains(WearableLiterals.BodyShapes.MONKEY))
        {
            currentLocomotions = monkeyLocomotions;
        }
        else if (bodyshapeId.Contains(WearableLiterals.BodyShapes.KID_MONKEY))
        {
            currentLocomotions = kidMonkeyLocomotions;
        }

        EquipBaseClip(currentLocomotions.idle);
        EquipBaseClip(currentLocomotions.walk);
        EquipBaseClip(currentLocomotions.run);
        EquipBaseClip(currentLocomotions.jump);
        EquipBaseClip(currentLocomotions.fall);

        idleAnimationName = currentLocomotions.idle.name;
        walkAnimationName = currentLocomotions.walk.name;
        runAnimationName = currentLocomotions.run.name;
        jumpAnimationName = currentLocomotions.jump.name;
        fallAnimationName = currentLocomotions.fall.name;

        runAnimationState = animation[runAnimationName];
        walkAnimationState = animation[walkAnimationName];
    }
    private void OnEventHandlerUpdate() { OnUpdateWithDeltaTime(Time.deltaTime); }

    public void OnPoolGet()
    {
        if (DCLCharacterController.i != null)
        {
            isOwnPlayer = DCLCharacterController.i.transform == transform.parent;

            // NOTE: disable MonoBehaviour's update to use DCLCharacterController event instead
            this.enabled = !isOwnPlayer;
        }

        currentState = State_Init;
    }

    public void OnPoolRelease()
    {
        if (isUpdateRegistered)
        {
            isUpdateRegistered = false;

            if (isOwnPlayer && DCLCharacterController.i)
            {
                DCLCharacterController.i.OnUpdateFinish -= OnUpdateWithDeltaTime;
            }
            else
            {
                Environment.i.platform.updateEventHandler.RemoveListener(IUpdateEventHandler.EventType.Update, OnEventHandlerUpdate);
            }
        }
    }

    void OnUpdateWithDeltaTime(float deltaTime)
    {
        blackboard.deltaTime = deltaTime;
        UpdateInterface();
        currentState?.Invoke(blackboard);
    }

    void UpdateInterface()
    {
        if (!target) return;

        Vector3 velocityTargetPosition = target.position;
        Vector3 flattenedVelocity = velocityTargetPosition - lastPosition;

        //NOTE(Brian): Vertical speed
        float verticalVelocity = flattenedVelocity.y;

        //NOTE(Kinerius): if we have more or less than zero we consider that we are either jumping or falling
        if (Mathf.Abs(verticalVelocity) > MIN_VERTICAL_SPEED_AIR)
        {
            lastOnAirTime = Time.time;
        }

        blackboard.verticalSpeed = verticalVelocity;

        flattenedVelocity.y = 0;

        if (isOwnPlayer)
            blackboard.movementSpeed = flattenedVelocity.magnitude - DCLCharacterController.i.movingPlatformSpeed;
        else
            blackboard.movementSpeed = flattenedVelocity.magnitude;

        Vector3 rayOffset = Vector3.up * RAY_OFFSET_LENGTH;

        //NOTE(Kinerius): This check is just for the playing character, it uses a combination of collision flags and raycasts to determine the ground state, its precise
        bool isGroundedByCharacterController = isOwnPlayer && DCLCharacterController.i.isGrounded;

        //NOTE(Kinerius): This check is for interpolated avatars (the other players) as we dont have a Character Controller, we determine their ground state by checking its vertical velocity
        //                this check is cheap and fast but not precise
        bool isGroundedByVelocity = !isOwnPlayer && Time.time - lastOnAirTime > FORCE_GROUND_TIME;

        //NOTE(Kinerius): This additional check is both for the player and interpolated avatars, we cast an additional raycast per avatar to check ground state
        bool isGroundedByRaycast = false;

        if (!isGroundedByCharacterController && !isGroundedByVelocity)
        {
            rayCache.origin = velocityTargetPosition + rayOffset;
            rayCache.direction = Vector3.down;

            LayerMask iGroundLayers = DCLCharacterController.i?.groundLayers ?? new LayerMask();

            isGroundedByRaycast = Physics.Raycast(rayCache,
                RAY_OFFSET_LENGTH - ELEVATION_OFFSET,
                iGroundLayers);

        }

        blackboard.isGrounded = isGroundedByCharacterController || isGroundedByVelocity || isGroundedByRaycast;

        lastPosition = velocityTargetPosition;
    }

    void State_Init(BlackBoard bb)
    {
        if (bb.isGrounded)
        {
            currentState = State_Ground;
        }
        else
        {
            currentState = State_Air;
        }
    }

    void State_Ground(BlackBoard bb)
    {
        if (bb.deltaTime <= 0)
            return;

        float movementSpeed = bb.movementSpeed / bb.deltaTime;

        runAnimationState.normalizedSpeed = movementSpeed * bb.runSpeedFactor;
        walkAnimationState.normalizedSpeed = movementSpeed * bb.walkSpeedFactor;

        if (movementSpeed >= WALK_MAX_SPEED)
        {
            CrossFadeTo(AvatarAnimation.RUN, runAnimationName, RUN_TRANSITION_TIME);
        }
        else if (movementSpeed >= RUN_MIN_SPEED && movementSpeed < WALK_MAX_SPEED)
        {
            // Keep current animation, leave empty
        }
        else if (movementSpeed > WALK_MIN_SPEED)
        {
            CrossFadeTo(AvatarAnimation.WALK, walkAnimationName, WALK_TRANSITION_TIME);
        }
        else
        {
            CrossFadeTo(AvatarAnimation.IDLE, idleAnimationName, IDLE_TRANSITION_TIME);
        }


        if (!bb.isGrounded)
        {
            currentState = State_Air;
            OnUpdateWithDeltaTime(bb.deltaTime);
        }
    }

    private void CrossFadeTo(AvatarAnimation animationState, string animationName,
        float runTransitionTime, PlayMode playMode = PlayMode.StopSameLayer)
    {
        if (latestAnimationState == animationState)
            return;

        lastCrossFade = animationName;
        latestAnimationState = animationState;
        animation.wrapMode = latestAnimationState.ShouldLoop() || blackboard.shouldLoop ? WrapMode.Loop : WrapMode.Once;
        animation.CrossFade(lastCrossFade, runTransitionTime, playMode);
    }

    void State_Air(BlackBoard bb)
    {
        if (bb.verticalSpeed > 0)
        {
            CrossFadeTo(AvatarAnimation.JUMP, jumpAnimationName, JUMP_TRANSITION_TIME, PlayMode.StopAll);
        }
        else
        {
            CrossFadeTo(AvatarAnimation.FALL, fallAnimationName, FALL_TRANSITION_TIME, PlayMode.StopAll);
        }

        if (bb.isGrounded)
        {
            animation.Blend(jumpAnimationName, 0, AIR_EXIT_TRANSITION_TIME);
            animation.Blend(fallAnimationName, 0, AIR_EXIT_TRANSITION_TIME);
            currentState = State_Ground;
            OnUpdateWithDeltaTime(bb.deltaTime);
        }
    }

    private void State_Expression(BlackBoard bb)
    {
        var prevAnimation = latestAnimationState;

        var exitTransitionStarted = false;

        if (!bb.isGrounded)
        {
            currentState = State_Air;
            exitTransitionStarted = true;
        }

        if (ExpressionGroundTransitionCondition(animationState: animation[bb.expressionTriggerId]))
        {
            currentState = State_Ground;
            exitTransitionStarted = true;
        }

        if (exitTransitionStarted)
            StopEmoteInternal(false);
        else if (prevAnimation != AvatarAnimation.EMOTE) // this condition makes Blend be called only in first frame of the state
        {
            animation.wrapMode = bb.shouldLoop ? WrapMode.Loop : WrapMode.Once;
            animation.Blend(bb.expressionTriggerId, 1, EXPRESSION_ENTER_TRANSITION_TIME);
        }

        // If we reach the emote loop, we send the RPC message again to refresh new users
        if (bb.shouldLoop && isOwnPlayer)
        {
            int emoteLoop = GetCurrentEmoteLoopCount();

            if (emoteLoop != lastEmoteLoopCount)
                UserProfile.GetOwnUserProfile().SetAvatarExpression(bb.expressionTriggerId, UserProfile.EmoteSource.EmoteLoop, true);

            lastEmoteLoopCount = emoteLoop;
        }

        return;

        bool ExpressionGroundTransitionCondition(AnimationState animationState)
        {
            float timeTillEnd = animationState == null ? 0 : animationState.length - animationState.time;
            bool isAnimationOver = timeTillEnd < EXPRESSION_EXIT_TRANSITION_TIME && !bb.shouldLoop;
            bool isMoving = isOwnPlayer ? DCLCharacterController.i.isMovingByUserInput : Math.Abs(bb.movementSpeed) > OTHER_PLAYER_MOVE_THRESHOLD;

            return isAnimationOver || isMoving;
        }
    }

    private int GetCurrentEmoteLoopCount() =>
        Mathf.RoundToInt(currentEmote.time / currentEmote.length);

    public void StopEmote()
    {
        StopEmoteInternal(true);
    }

    private void StopEmoteInternal(bool immediate)
    {
        if (string.IsNullOrEmpty(blackboard.expressionTriggerId)) return;
        if (animation.GetClip(blackboard.expressionTriggerId) == null) return;

        animation.Blend(blackboard.expressionTriggerId, 0, !immediate ? EXPRESSION_EXIT_TRANSITION_TIME : 0);
        blackboard.expressionTriggerId = null;
        blackboard.shouldLoop = false;
        lastExtendedEmoteData?.Stop();

        if (!immediate) OnUpdateWithDeltaTime(blackboard.deltaTime);
    }

    private float lastEmotePlayTime = 0;
    private void StartEmote(string emoteId, bool spatial, float volume, bool occlude)
    {
        if (!string.IsNullOrEmpty(emoteId))
        {
            lastExtendedEmoteData?.Stop();

            if (emoteClipDataMap.TryGetValue(emoteId, out var emoteClipData))
            {
                lastExtendedEmoteData = emoteClipData;
                lastEmotePlayTime = Time.time;

                emoteClipData.Play(gameObject.layer, spatial, volume, occlude);
            }
        }
        else
        {
            lastExtendedEmoteData?.Stop();
        }
    }

    public void Reset()
    {
        if (animation == null)
            return;

        //It will set the animation to the first frame, but due to the nature of the script and its Update. It wont stop the animation from playing
        animation.Stop();
    }

    public void SetIdleFrame() { animation.Play(currentLocomotions.idle.name); }

    public void PlayEmote(string emoteId, long timestamps, bool spatial, float volume, bool occlude,
        bool ignoreTimestamp)
    {
        if (animation == null)
            return;

        if (string.IsNullOrEmpty(emoteId))
            return;

        if (animation.GetClip(emoteId) == null)
            return;

        bool loop = emoteClipDataMap.TryGetValue(emoteId, out var clipData) && clipData.Loop;
        bool mustTriggerAnimation = !string.IsNullOrEmpty(emoteId) && (blackboard.expressionTriggerTimestamp != timestamps || ignoreTimestamp);

        if (loop && blackboard.expressionTriggerId == emoteId)
            return;

        blackboard.expressionTriggerId = emoteId;
        blackboard.expressionTriggerTimestamp = timestamps;

        if (mustTriggerAnimation || loop)
        {
            StartEmote(emoteId, spatial, volume, occlude);

            if (!string.IsNullOrEmpty(emoteId))
            {
                animation.Stop(emoteId);
                latestAnimationState = AvatarAnimation.IDLE;
            }

            blackboard.shouldLoop = loop;

            CrossFadeTo(AvatarAnimation.EMOTE, emoteId, EXPRESSION_EXIT_TRANSITION_TIME, PlayMode.StopAll);

            currentEmote = animation[emoteId];
            lastEmoteLoopCount = GetCurrentEmoteLoopCount();
            currentState = State_Expression;
        }
    }

    public void EquipBaseClip(AnimationClip clip)
    {
        var clipId = clip.name;
        if (animation == null)
            return;

        if (animation.GetClip(clipId) != null)
            animation.RemoveClip(clipId);

        animation.AddClip(clip, clipId);
    }

    public void EquipEmote(string emoteId, EmoteClipData emoteClipData)
    {
        if (animation == null)
            return;

        if (animation.GetClip(emoteId) != null)
            animation.RemoveClip(emoteId);

        emoteClipDataMap[emoteId] = emoteClipData;

        animation.AddClip(emoteClipData.AvatarClip, emoteId);

        if (emoteClipData.ExtraContent != null)
        {
            emoteClipData.ExtraContent.transform.SetParent(animation.transform.parent, false);
            emoteClipData.ExtraContent.transform.ResetLocalTRS();
            emoteClipData.ExtraContent.transform.localPosition = animation.transform.localPosition;
        }
    }

    public void UnequipEmote(string emoteId)
    {
        if (animation == null)
            return;

        if (animation.GetClip(emoteId) == null)
            return;

        animation.RemoveClip(emoteId);

        if (emoteClipDataMap.TryGetValue(emoteId, out var emoteClipData))
        {
            if (emoteClipData.ExtraContent != null)
                emoteClipData.ExtraContent.transform.SetParent(null, false);
        }
    }

    private void InitializeAvatarAudioAndParticleHandlers(Animation createdAnimation)
    {
        //NOTE(Mordi): Adds handler for animation events, and passes in the audioContainer for the avatar
        AvatarAnimationEventHandler animationEventHandler = createdAnimation.gameObject.GetOrCreateComponent<AvatarAnimationEventHandler>();
        AudioContainer audioContainer = transform.GetComponentInChildren<AudioContainer>();

        if (audioContainer != null)
        {
            animationEventHandler.Init(audioContainer);

            //NOTE(Mordi): If this is a remote avatar, pass the animation component so we can keep track of whether it is culled (off-screen) or not
            AvatarAudioHandlerRemote audioHandlerRemote = audioContainer.GetComponent<AvatarAudioHandlerRemote>();

            if (audioHandlerRemote != null)
            {
                audioHandlerRemote.Init(createdAnimation.gameObject);
            }
        }

        animEventHandler = animationEventHandler;
    }

    private void OnEnable()
    {
        if (animation == null)
            return;

        animation.enabled = true;
        SetIdleFrame();
    }

    private void OnDisable()
    {
        if (animation == null)
            return;

        StopEmoteInternal(true);
        CrossFadeTo(AvatarAnimation.IDLE, idleAnimationName, 0);
        currentState = State_Ground;

        AsyncAnimationStop().Forget();
    }

    private async UniTaskVoid AsyncAnimationStop()
    {
        await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);

        if (animation == null)
            return;

        animation.Stop();
        animation.enabled = false;
    }

    private void OnDestroy()
    {
        if (animEventHandler != null)
            Destroy(animEventHandler);
    }
}
