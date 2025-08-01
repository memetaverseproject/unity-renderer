using DCL.Backpack;
using System;
using System.Collections.Generic;
using DCL.CameraTool;
using DCL.Models;
using Newtonsoft.Json;
using System.Linq;
using UnityEngine;
using Ray = UnityEngine.Ray;

#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace DCL.Interface
{
    /**
     * This class contains the outgoing interface of Memetaverse.
     * You must call those functions to interact with the WebInterface.
     *
     * The messages comming from the WebInterface instead, are reported directly to
     * the handler GameObject by name.
     */
    public static class WebInterface
    {
        public static bool VERBOSE = false;

        [System.Serializable]
        public class ReportPositionPayload
        {
            /** Camera position, world space */
            public Vector3 position;

            /** Character rotation */
            public Quaternion rotation;

            /** Camera rotation */
            public Quaternion cameraRotation;

            public float playerHeight;

            public Vector3 mousePosition;

            public string id;
        }

        [System.Serializable]
        public abstract class ControlEvent
        {
            public string eventType;
        }

        public abstract class ControlEvent<T> : ControlEvent
        {
            public T payload;

            protected ControlEvent(string eventType, T payload)
            {
                this.eventType = eventType;
                this.payload = payload;
            }
        }

        [System.Serializable]
        public class SceneReady : ControlEvent<SceneReady.Payload>
        {

            public SceneReady(int sceneNumber) : base("SceneReady", new Payload() { sceneNumber = sceneNumber }) { }

            [System.Serializable]
            public class Payload
            {
                public int sceneNumber;
            }
        }

        [System.Serializable]
        public class ActivateRenderingACK : ControlEvent<object>
        {
            public ActivateRenderingACK() : base("ActivateRenderingACK", null) { }
        }

        [System.Serializable]
        public class DeactivateRenderingACK : ControlEvent<object>
        {
            public DeactivateRenderingACK() : base("DeactivateRenderingACK", null) { }
        }

        [System.Serializable]
        public class SceneEvent<T>
        {
            public int sceneNumber;
            public string eventType;
            public T payload;
        }

        [System.Serializable]
        public class AllScenesEvent<T>
        {
            public string eventType;
            public T payload;
        }

        [System.Serializable]
        public class UUIDEvent<TPayload>
            where TPayload : class, new()
        {
            public string uuid;
            public TPayload payload = new TPayload();
        }

        private static IEnumerable<ACTION_BUTTON> concreteActionButtons;
        public static IEnumerable<ACTION_BUTTON> ConcreteActionButtons =>
            concreteActionButtons ??= Enum.GetValues(typeof(ACTION_BUTTON)).Cast<ACTION_BUTTON>()
                                          .Where(actionButton => actionButton != ACTION_BUTTON.ANY);

        public enum ACTION_BUTTON
        {
            POINTER = 0,
            PRIMARY = 1,
            SECONDARY = 2,
            ANY = 3,
            FORWARD = 4,
            BACKWARD = 5,
            RIGHT = 6,
            LEFT = 7,
            JUMP = 8,
            WALK = 9,
            ACTION_3 = 10,
            ACTION_4 = 11,
            ACTION_5 = 12,
            ACTION_6 = 13
        }

        [System.Serializable]
        public class OnClickEvent : UUIDEvent<OnClickEventPayload> { };

        [System.Serializable]
        public class CameraModePayload
        {
            public CameraMode.ModeId cameraMode;
        };

        [System.Serializable]
        public class Web3UseResponsePayload
        {
            public string id;
            public bool result;
        };

        [System.Serializable]
        public class IdleStateChangedPayload
        {
            public bool isIdle;
        };

        [System.Serializable]
        public class OnPointerDownEvent : UUIDEvent<OnPointerEventPayload> { };

        [System.Serializable]
        public class OnGlobalPointerEvent
        {
            public OnGlobalPointerEventPayload payload = new OnGlobalPointerEventPayload();
        };

        [System.Serializable]
        public class OnPointerUpEvent : UUIDEvent<OnPointerEventPayload> { };

        [System.Serializable]
        private class OnTextSubmitEvent : UUIDEvent<OnTextSubmitEventPayload> { };

        [System.Serializable]
        private class OnTextInputChangeEvent : UUIDEvent<OnTextInputChangeEventPayload> { };

        [System.Serializable]
        private class OnTextInputChangeTextEvent : UUIDEvent<OnTextInputChangeTextEventPayload> { };

        [System.Serializable]
        private class OnScrollChangeEvent : UUIDEvent<OnScrollChangeEventPayload> { };

        [System.Serializable]
        private class OnFocusEvent : UUIDEvent<EmptyPayload> { };

        [System.Serializable]
        private class OnBlurEvent : UUIDEvent<EmptyPayload> { };

        [System.Serializable]
        public class OnEnterEvent : UUIDEvent<OnEnterEventPayload> { };

        [System.Serializable]
        public class OnClickEventPayload
        {
            public ACTION_BUTTON buttonId = ACTION_BUTTON.POINTER;
        }

        [System.Serializable]
        public class SendChatMessageEvent
        {
            public ChatMessage message;
        }

        [System.Serializable]
        public class RemoveEntityComponentsPayLoad
        {
            public string entityId;
            public string componentId;
        };

        [System.Serializable]
        public class StoreSceneStateEvent
        {
            public string type = "StoreSceneState";
            public string payload = "";
        };

        [System.Serializable]
        public class OnPointerEventPayload
        {

            public ACTION_BUTTON buttonId;
            public Vector3 origin;
            public Vector3 direction;
            public Hit hit;

            [System.Serializable]
            public class Hit
            {
                public Vector3 origin;
                public float length;
                public Vector3 hitPoint;
                public Vector3 normal;
                public Vector3 worldNormal;
                public string meshName;
                public string entityId;
            }
        }

        [System.Serializable]
        public class OnGlobalPointerEventPayload : OnPointerEventPayload
        {
            public enum InputEventType
            {
                DOWN,
                UP
            }

            public InputEventType type;
        }

        [System.Serializable]
        public class OnTextSubmitEventPayload
        {
            public string id;
            public string text;
        }

        [System.Serializable]
        public class OnTextInputChangeEventPayload
        {
            public string value;
        }

        [System.Serializable]
        public class OnTextInputChangeTextEventPayload
        {

            public Payload value = new Payload();

            [System.Serializable]
            public class Payload
            {
                public string value;
                public bool isSubmit;
            }
        }

        [System.Serializable]
        public class OnScrollChangeEventPayload
        {
            public Vector2 value;
            public int pointerId;
        }

        [System.Serializable]
        public class EmptyPayload { }

        [System.Serializable]
        public class MetricsModel
        {
            public int meshes;
            public int bodies;
            public int materials;
            public int textures;
            public int triangles;
            public int entities;

            public static MetricsModel operator +(MetricsModel lhs, MetricsModel rhs)
            {
                return new MetricsModel()
                {
                    meshes = lhs.meshes + rhs.meshes,
                    bodies = lhs.bodies + rhs.bodies,
                    materials = lhs.materials + rhs.materials,
                    textures = lhs.textures + rhs.textures,
                    triangles = lhs.triangles + rhs.triangles,
                    entities = lhs.entities + rhs.entities
                };
            }
        }

        [System.Serializable]
        private class OnMetricsUpdate
        {
            public MetricsModel given = new MetricsModel();
            public MetricsModel limit = new MetricsModel();
        }

        [System.Serializable]
        public class OnEnterEventPayload { }

        [System.Serializable]
        public class TransformPayload
        {
            public Vector3 position = Vector3.zero;
            public Quaternion rotation = Quaternion.identity;
            public Vector3 scale = Vector3.one;
        }

        public class OnSendScreenshot
        {
            public string encodedTexture;
            public string id;
        };

        [System.Serializable]
        public class GotoEvent
        {
            public int x;
            public int y;
        };

        [System.Serializable]
        public class BaseResolution
        {
            public int baseResolution;
        };

        //-----------------------------------------------------
        // Raycast
        [System.Serializable]
        public class RayInfo
        {
            public Vector3 origin;
            public Vector3 direction;
            public float distance;
        }

        [System.Serializable]
        public class RaycastHitInfo
        {
            public bool didHit;
            public RayInfo ray;

            public Vector3 hitPoint;
            public Vector3 hitNormal;
        }

        [System.Serializable]
        public class HitEntityInfo
        {
            public string entityId;
            public string meshName;
        }

        [System.Serializable]
        public class RaycastHitEntity : RaycastHitInfo
        {
            public HitEntityInfo entity;
        }

        [System.Serializable]
        public class RaycastHitEntities : RaycastHitInfo
        {
            public RaycastHitEntity[] entities;
        }

        [System.Serializable]
        public class RaycastResponse<T> where T : RaycastHitInfo
        {
            public string queryId;
            public string queryType;
            public T payload;
        }

        // Note (Zak): We need to explicitly define this classes for the JsonUtility to
        // be able to serialize them
        [System.Serializable]
        public class RaycastHitFirstResponse : RaycastResponse<RaycastHitEntity> { }

        [System.Serializable]
        public class RaycastHitAllResponse : RaycastResponse<RaycastHitEntities> { }

        [System.Serializable]
        public class SendBlockPlayerPayload
        {
            public string userId;
        }

        [Serializable]
        private class SendReportPlayerPayload
        {
            public string userId;
            public string name;
        }

        [Serializable]
        private class SendReportScenePayload
        {
            public int sceneNumber;
        }

        [Serializable]
        private class SetHomeScenePayload
        {
            public string sceneCoords;
        }

        [System.Serializable]
        public class SendUnblockPlayerPayload
        {
            public string userId;
        }

        [System.Serializable]
        public class TutorialStepPayload
        {
            public int tutorialStep;
        }

        [System.Serializable]
        public class PerformanceReportPayload
        {
            public string samples;
            public bool fpsIsCapped;
            public int hiccupsInThousandFrames;
            public float hiccupsTime;
            public float totalTime;
            public int gltfInProgress;
            public int gltfFailed;
            public int gltfCancelled;
            public int gltfLoaded;
            public int abInProgress;
            public int abFailed;
            public int abCancelled;
            public int abLoaded;
            public int gltfTexturesLoaded;
            public int abTexturesLoaded;
            public int promiseTexturesLoaded;
            public int enqueuedMessages;
            public int processedMessages;
            public int playerCount;
            public int loadRadius;
            public object drawCalls; //int *
            public object memoryReserved; //long, in total bytes *
            public object memoryUsage; //long, in total bytes *
            public object totalGCAlloc; //long, in total bytes, its the sum of all GCAllocs per frame over 1000 frames *
            public Dictionary<int, long> sceneScores;

            //* is NULL if SendProfilerMetrics is false
        }

        [System.Serializable]
        public class SystemInfoReportPayload
        {
            public string graphicsDeviceName = SystemInfo.graphicsDeviceName;
            public string graphicsDeviceVersion = SystemInfo.graphicsDeviceVersion;
            public int graphicsMemorySize = SystemInfo.graphicsMemorySize;
            public string processorType = SystemInfo.processorType;
            public int processorCount = SystemInfo.processorCount;
            public int systemMemorySize = SystemInfo.systemMemorySize;

            // TODO: remove useBinaryTransform after ECS7 is fully in prod
            public bool useBinaryTransform = true;
        }

        [System.Serializable]
        public class GenericAnalyticPayload
        {
            public string eventName;
            public Dictionary<object, object> data;
        }

        [System.Serializable]
        public class PerformanceHiccupPayload
        {
            public int hiccupsInThousandFrames;
            public float hiccupsTime;
            public float totalTime;
        }

        [System.Serializable]
        public class TermsOfServiceResponsePayload
        {
            public int sceneNumber;
            public bool dontShowAgain;
            public bool accepted;
        }

        [System.Serializable]
        public class OpenURLPayload
        {
            public string url;
        }

        [System.Serializable]
        public class GIFSetupPayload
        {
            public string imageSource;
            public string id;
            public bool isWebGL1;
        }

        [System.Serializable]
        public class RequestScenesInfoAroundParcelPayload
        {
            public Vector2 parcel;
            public int scenesAround;
        }

        [System.Serializable]
        public class AudioStreamingPayload
        {
            public string url;
            public bool play;
            public float volume;
        }

        [System.Serializable]
        public class SetScenesLoadRadiusPayload
        {
            public float newRadius;
        }

        [System.Serializable]
        public class SetVoiceChatRecordingPayload
        {
            public bool recording;
        }

        [System.Serializable]
        public class ApplySettingsPayload
        {
            public float voiceChatVolume;
            public int voiceChatAllowCategory;
        }

        [Serializable]
        public class UserRealmPayload
        {
            public string serverName;
            public string layer;
        }

        [System.Serializable]
        public class JumpInPayload
        {
            public UserRealmPayload realm = new UserRealmPayload();
            public Vector2 gridPosition;
        }

        [System.Serializable]
        public class LoadingFeedbackMessage
        {
            public string message;
            public int loadPercentage;
        }

        [System.Serializable]
        public class AnalyticsPayload
        {

            public string name;
            public Property[] properties;

            [System.Serializable]
            public class Property
            {
                public string key;
                public string value;

                public Property(string key, string value)
                {
                    this.key = key;
                    this.value = value;
                }
            }
        }

        [System.Serializable]
        public class DelightedSurveyEnabledPayload
        {
            public bool enabled;
        }

        [System.Serializable]
        public class ExternalActionSceneEventPayload
        {
            public string type;
            public string payload;
        }

        [System.Serializable]
        public class MuteUserPayload
        {
            public string[] usersId;
            public bool mute;
        }

        [System.Serializable]
        public class CloseUserAvatarPayload
        {
            public bool isSignUpFlow;
        }

        [System.Serializable]
        public class StringPayload
        {
            public string value;
        }

        [System.Serializable]
        public class KillPortableExperiencePayload
        {
            public string portableExperienceId;
        }

        [System.Serializable]
        public class SetDisabledPortableExperiencesPayload
        {
            public string[] idsToDisable;
        }

        [System.Serializable]
        public class WearablesRequestFiltersPayload
        {
            public string ownedByUser;
            public string[] wearableIds;
            public string[] collectionIds;
            public string thirdPartyId;
        }

        [System.Serializable]
        public class EmotesRequestFiltersPayload
        {
            public string ownedByUser;
            public string[] emoteIds;
            public string[] collectionIds;
            public string thirdPartyId;
        }

        [System.Serializable]
        public class RequestWearablesPayload
        {
            public WearablesRequestFiltersPayload filters;
            public string context;
        }

        [System.Serializable]
        public class RequestEmotesPayload
        {
            public EmotesRequestFiltersPayload filters;
            public string context;
        }

        [System.Serializable]
        public class HeadersPayload
        {
            public string method;
            public string url;
            public Dictionary<string, object> metadata = new Dictionary<string, object>();
        }

        [System.Serializable]
        public class SearchENSOwnerPayload
        {
            public string name;
            public int maxResults;
        }

        [System.Serializable]
        public class UnpublishScenePayload
        {
            public string coordinates;
        }

        [System.Serializable]
        public class AvatarStateBase
        {
            public string type;
            public string avatarShapeId;
        }

        [System.Serializable]
        public class AvatarStateSceneChanged : AvatarStateBase
        {
            public int sceneNumber;
        }

        [System.Serializable]
        public class AvatarOnClickPayload
        {
            public string userId;
            public RayInfo ray = new RayInfo();
        }

        [System.Serializable]
        public class TimeReportPayload
        {
            public float timeNormalizationFactor;
            public float cycleTime;
            public bool isPaused;
            public float time;
        }

        [System.Serializable]
        public class GetFriendsWithDirectMessagesPayload
        {
            public string userNameOrId;
            public int limit;
            public int skip;
        }

        [System.Serializable]
        public class MarkMessagesAsSeenPayload
        {
            public string userId;
        }

        [System.Serializable]
        public class MarkChannelMessagesAsSeenPayload
        {
            public string channelId;
        }

        [System.Serializable]
        public class GetPrivateMessagesPayload
        {
            public string userId;
            public int limit;
            public string fromMessageId;
        }

        [Serializable]
        public class FriendshipUpdateStatusMessage
        {
            public string userId;
            public FriendshipAction action;
        }

        [Serializable]
        public class SetInputAudioDevicePayload
        {
            public string deviceId;
        }

        public enum FriendshipAction
        {
            NONE,
            APPROVED,
            REJECTED,
            CANCELLED,
            REQUESTED_FROM,
            REQUESTED_TO,
            DELETED
        }

        [Serializable]
        private class GetFriendsPayload
        {
            public string userNameOrId;
            public int limit;
            public int skip;
        }

        [Serializable]
        private class LeaveChannelPayload
        {
            public string channelId;
        }

        [Serializable]
        private class CreateChannelPayload
        {
            public string channelId;
        }

        public struct MuteChannelPayload
        {
            public string channelId;
            public bool muted;
        }

        [Serializable]
        private class JoinOrCreateChannelPayload
        {
            public string channelId;
        }

        [Serializable]
        private class GetChannelMessagesPayload
        {
            public string channelId;
            public int limit;
            public string from;
        }

        [Serializable]
        private class GetJoinedChannelsPayload
        {
            public int limit;
            public int skip;
        }

        [Serializable]
        private class GetChannelsPayload
        {
            public int limit;
            public string since;
            public string name;
        }

        [Serializable]
        private class GetChannelInfoPayload
        {
            public string[] channelIds;
        }

        [Serializable]
        private class GetChannelMembersPayload
        {
            public string channelId;
            public int limit;
            public int skip;
            public string userName;
        }

        [Serializable]
        private class ErrorPayload
        {
            public string error;
        }

        [Serializable]
        public class SaveLinksPayload
        {
            [Serializable]
            public class Link
            {
                public string title;
                public string url;
            }

            public List<Link> links;
        }

        [Serializable]
        public class SaveAdditionalInfoPayload
        {
            public string country;
            public string employmentStatus;
            public string gender;
            public string pronouns;
            public string relationshipStatus;
            public string sexualOrientation;
            public string language;
            public string profession;
            public long birthdate;
            public string realName;
            public string hobbies;
        }

        public static event Action<string, byte[]> OnBinaryMessageFromEngine;

#if UNITY_WEBGL && !UNITY_EDITOR
    /**
     * This method is called after the first render. It marks the loading of the
     * rest of the JS client.
     */
    [DllImport("__Internal")] public static extern void StartDecentraland();
    [DllImport("__Internal")] public static extern void MessageFromEngine(string type, string message);
    [DllImport("__Internal")] public static extern string GetGraphicCard();
    [DllImport("__Internal")] public static extern bool CheckURLParam(string targetParam);
    [DllImport("__Internal")] public static extern string GetURLParam(string targetParam);

    public static System.Action<string, string> OnMessageFromEngine;
#else
        public static Action<string, string> OnMessageFromEngine
        {
            set
            {
                OnMessage = value;
                if (OnMessage != null)
                {
                    ProcessQueuedMessages();
                }
            }
            get => OnMessage;
        }
        private static Action<string, string> OnMessage;

        private static bool hasQueuedMessages = false;
        private static List<(string, string)> queuedMessages = new List<(string, string)>();
        public static void StartDecentraland() { }

        // CheckURLParam() is only available on web builds.
        public static bool CheckURLParam(string targetParam) { return false; }

        // GetURLParam() is only available on web builds.
        public static string GetURLParam(string targetParam) { return String.Empty; }

        public static void MessageFromEngine(string type, string message)
        {
            if (OnMessageFromEngine != null)
            {
                if (hasQueuedMessages)
                {
                    ProcessQueuedMessages();
                }

                OnMessageFromEngine.Invoke(type, message);
                if (VERBOSE)
                {
                    Debug.Log("MessageFromEngine called with: " + type + ", " + message);
                }
            }
            else
            {
                lock (queuedMessages)
                {
                    queuedMessages.Add((type, message));
                }

                hasQueuedMessages = true;
            }
        }

        private static void ProcessQueuedMessages()
        {
            hasQueuedMessages = false;
            lock (queuedMessages)
            {
                foreach ((string type, string payload) in queuedMessages)
                {
                    MessageFromEngine(type, payload);
                }

                queuedMessages.Clear();
            }
        }

        public static string GetGraphicCard() => "In Editor Graphic Card";
#endif

        public static void SendMessage(string type)
        {
            // sending an empty JSON object to be compatible with other messages
            MessageFromEngine(type, "{}");
        }

        public static void SendMessage<T>(string type, T message)
        {
            string messageJson = JsonUtility.ToJson(message);
            SendJson(type, messageJson);
        }

        public static void SendJson(string type, string json)
        {
            if (VERBOSE)
            {
                Debug.Log($"Sending message: " + json);
            }

            MessageFromEngine(type, json);
        }

        private static ReportPositionPayload positionPayload = new ReportPositionPayload();
        private static CameraModePayload cameraModePayload = new CameraModePayload();
        private static Web3UseResponsePayload web3UseResponsePayload = new Web3UseResponsePayload();
        private static IdleStateChangedPayload idleStateChangedPayload = new IdleStateChangedPayload();
        private static OnMetricsUpdate onMetricsUpdate = new OnMetricsUpdate();
        private static OnClickEvent onClickEvent = new OnClickEvent();
        private static OnPointerDownEvent onPointerDownEvent = new OnPointerDownEvent();
        private static OnPointerUpEvent onPointerUpEvent = new OnPointerUpEvent();
        private static OnTextSubmitEvent onTextSubmitEvent = new OnTextSubmitEvent();
        private static OnTextInputChangeEvent onTextInputChangeEvent = new OnTextInputChangeEvent();
        private static OnTextInputChangeTextEvent onTextInputChangeTextEvent = new OnTextInputChangeTextEvent();
        private static OnScrollChangeEvent onScrollChangeEvent = new OnScrollChangeEvent();
        private static OnFocusEvent onFocusEvent = new OnFocusEvent();
        private static OnBlurEvent onBlurEvent = new OnBlurEvent();
        private static OnEnterEvent onEnterEvent = new OnEnterEvent();
        private static OnSendScreenshot onSendScreenshot = new OnSendScreenshot();
        private static OnPointerEventPayload onPointerEventPayload = new OnPointerEventPayload();
        private static OnGlobalPointerEventPayload onGlobalPointerEventPayload = new OnGlobalPointerEventPayload();
        private static OnGlobalPointerEvent onGlobalPointerEvent = new OnGlobalPointerEvent();
        private static AudioStreamingPayload onAudioStreamingEvent = new AudioStreamingPayload();
        private static SetVoiceChatRecordingPayload setVoiceChatRecordingPayload = new SetVoiceChatRecordingPayload();
        private static SetScenesLoadRadiusPayload setScenesLoadRadiusPayload = new SetScenesLoadRadiusPayload();
        private static ApplySettingsPayload applySettingsPayload = new ApplySettingsPayload();
        private static GIFSetupPayload gifSetupPayload = new GIFSetupPayload();
        private static JumpInPayload jumpInPayload = new JumpInPayload();
        private static GotoEvent gotoEvent = new GotoEvent();
        private static SendChatMessageEvent sendChatMessageEvent = new SendChatMessageEvent();
        private static BaseResolution baseResEvent = new BaseResolution();
        private static AnalyticsPayload analyticsEvent = new AnalyticsPayload();
        private static DelightedSurveyEnabledPayload delightedSurveyEnabled = new DelightedSurveyEnabledPayload();
        private static ExternalActionSceneEventPayload sceneExternalActionEvent = new ExternalActionSceneEventPayload();
        private static MuteUserPayload muteUserEvent = new MuteUserPayload();
        private static StoreSceneStateEvent storeSceneState = new StoreSceneStateEvent();
        private static CloseUserAvatarPayload closeUserAvatarPayload = new CloseUserAvatarPayload();
        private static StringPayload stringPayload = new StringPayload();
        private static KillPortableExperiencePayload killPortableExperiencePayload = new KillPortableExperiencePayload();
        private static SetDisabledPortableExperiencesPayload setDisabledPortableExperiencesPayload = new SetDisabledPortableExperiencesPayload();
        private static RequestWearablesPayload requestWearablesPayload = new RequestWearablesPayload();
        private static RequestEmotesPayload requestEmotesPayload = new RequestEmotesPayload();
        private static SearchENSOwnerPayload searchEnsOwnerPayload = new SearchENSOwnerPayload();
        private static HeadersPayload headersPayload = new HeadersPayload();
        private static AvatarStateBase avatarStatePayload = new AvatarStateBase();
        private static AvatarStateSceneChanged avatarSceneChangedPayload = new AvatarStateSceneChanged();
        public static AvatarOnClickPayload avatarOnClickPayload = new AvatarOnClickPayload();
        private static UUIDEvent<EmptyPayload> onPointerHoverEnterEvent = new UUIDEvent<EmptyPayload>();
        private static UUIDEvent<EmptyPayload> onPointerHoverExitEvent = new UUIDEvent<EmptyPayload>();
        private static TimeReportPayload timeReportPayload = new TimeReportPayload();
        private static GetFriendsWithDirectMessagesPayload getFriendsWithDirectMessagesPayload = new GetFriendsWithDirectMessagesPayload();
        private static MarkMessagesAsSeenPayload markMessagesAsSeenPayload = new MarkMessagesAsSeenPayload();
        private static MarkChannelMessagesAsSeenPayload markChannelMessagesAsSeenPayload = new MarkChannelMessagesAsSeenPayload();
        private static GetPrivateMessagesPayload getPrivateMessagesPayload = new GetPrivateMessagesPayload();

        public static void SendSceneEvent<T> (int sceneNumber, string eventType, T payload)
        {
            SceneEvent<T> sceneEvent = new SceneEvent<T>();
            sceneEvent.sceneNumber = sceneNumber;
            sceneEvent.eventType = eventType;
            sceneEvent.payload = payload;

            SendMessage("SceneEvent", sceneEvent);
        }

        private static void SendAllScenesEvent<T>(string eventType, T payload)
        {
            AllScenesEvent<T> allScenesEvent = new AllScenesEvent<T>();
            allScenesEvent.eventType = eventType;
            allScenesEvent.payload = payload;

            SendMessage("AllScenesEvent", allScenesEvent);
        }

        public static void ReportPosition(Vector3 position, Quaternion rotation, float playerHeight, Quaternion cameraRotation)
        {
            positionPayload.position = position;
            positionPayload.rotation = rotation;
            positionPayload.playerHeight = playerHeight;
            positionPayload.cameraRotation = cameraRotation;

            SendMessage("ReportPosition", positionPayload);
        }

        public static void ReportCameraChanged(CameraMode.ModeId cameraMode) { ReportCameraChanged(cameraMode, -1); }

        public static void ReportCameraChanged(CameraMode.ModeId cameraMode, int targetSceneNumber)
        {
            cameraModePayload.cameraMode = cameraMode;
            if (targetSceneNumber > 0)
            {
                SendSceneEvent(targetSceneNumber, "cameraModeChanged", cameraModePayload);
            }
            else
            {
                SendAllScenesEvent("cameraModeChanged", cameraModePayload);
            }
        }

        public static void Web3UseResponse(string id, bool result)
        {
            web3UseResponsePayload.id = id;
            web3UseResponsePayload.result = result;
            SendMessage("Web3UseResponse", web3UseResponsePayload);
        }

        public static void ReportIdleStateChanged(bool isIdle)
        {
            idleStateChangedPayload.isIdle = isIdle;
            SendAllScenesEvent("idleStateChanged", idleStateChangedPayload);
        }

        public static void ReportControlEvent<T>(T controlEvent) where T : ControlEvent { SendMessage("ControlEvent", controlEvent); }

        public static void SendRequestHeadersForUrl(string eventName, string method, string url, Dictionary<string, object> metadata = null)
        {
            headersPayload.method = method;
            headersPayload.url = url;
            if (metadata != null)
                headersPayload.metadata = metadata;
            SendMessage(eventName, headersPayload);
        }

        public static void BuilderInWorldMessage(string type, string message) { MessageFromEngine(type, message); }

        public static void ReportOnClickEvent(int sceneNumber, string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onClickEvent.uuid = uuid;

            SendSceneEvent(sceneNumber, "uuidEvent", onClickEvent);
        }

        // TODO: Add sceneNumber to this response
        private static void ReportRaycastResult<T, P>(int sceneNumber, string queryId, string queryType, P payload) where T : RaycastResponse<P>, new() where P : RaycastHitInfo
        {
            T response = new T();
            response.queryId = queryId;
            response.queryType = queryType;
            response.payload = payload;

            SendSceneEvent<T>(sceneNumber, "raycastResponse", response);
        }

        public static void ReportRaycastHitFirstResult(int sceneNumber, string queryId, RaycastType raycastType, RaycastHitEntity payload) { ReportRaycastResult<RaycastHitFirstResponse, RaycastHitEntity>(sceneNumber, queryId, Protocol.RaycastTypeToLiteral(raycastType), payload); }

        public static void ReportRaycastHitAllResult(int sceneNumber, string queryId, RaycastType raycastType, RaycastHitEntities payload) { ReportRaycastResult<RaycastHitAllResponse, RaycastHitEntities>(sceneNumber, queryId, Protocol.RaycastTypeToLiteral(raycastType), payload); }

        private static OnPointerEventPayload.Hit CreateHitObject(string entityId, string meshName, Vector3 point,
            Vector3 normal, float distance)
        {
            OnPointerEventPayload.Hit hit = new OnPointerEventPayload.Hit();

            hit.hitPoint = point;
            hit.length = distance;
            hit.normal = normal;
            hit.worldNormal = normal;
            hit.meshName = meshName;
            hit.entityId = entityId;

            return hit;
        }

        private static void SetPointerEventPayload(OnPointerEventPayload pointerEventPayload, ACTION_BUTTON buttonId,
            string entityId, string meshName, Ray ray, Vector3 point, Vector3 normal, float distance,
            bool isHitInfoValid)
        {
            pointerEventPayload.origin = ray.origin;
            pointerEventPayload.direction = ray.direction;
            pointerEventPayload.buttonId = buttonId;

            if (isHitInfoValid)
                pointerEventPayload.hit = CreateHitObject(entityId, meshName, point, normal, distance);
            else
                pointerEventPayload.hit = null;
        }


        public static void ReportGlobalPointerEvent(OnGlobalPointerEventPayload.InputEventType pointerDirection, ACTION_BUTTON buttonId, Ray ray, Vector3 point, Vector3 normal,
            float distance, int sceneNumber, string entityId = "0", string meshName = null, bool isHitInfoValid = false)
        {
            SetPointerEventPayload(onGlobalPointerEventPayload, buttonId, entityId, meshName, ray, point, normal, distance, isHitInfoValid);
            onGlobalPointerEventPayload.type = pointerDirection;

            onGlobalPointerEvent.payload = onGlobalPointerEventPayload;

            SendSceneEvent(sceneNumber, "actionButtonEvent", onGlobalPointerEvent);
        }

        public static void ReportOnPointerDownEvent(ACTION_BUTTON buttonId, int sceneNumber, string uuid,
            string entityId, string meshName, Ray ray, Vector3 point, Vector3 normal, float distance)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onPointerDownEvent.uuid = uuid;
            SetPointerEventPayload(onPointerEventPayload, buttonId, entityId, meshName, ray, point,
                normal, distance, isHitInfoValid: true);
            onPointerDownEvent.payload = onPointerEventPayload;

            SendSceneEvent(sceneNumber, "uuidEvent", onPointerDownEvent);
        }

        public static void ReportOnPointerUpEvent(ACTION_BUTTON buttonId, int sceneNumber, string uuid, string entityId,
            string meshName, Ray ray, Vector3 point, Vector3 normal, float distance)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onPointerUpEvent.uuid = uuid;
            SetPointerEventPayload(onPointerEventPayload, buttonId, entityId, meshName, ray, point,
                normal, distance, isHitInfoValid: true);
            onPointerUpEvent.payload = onPointerEventPayload;

            SendSceneEvent(sceneNumber, "uuidEvent", onPointerUpEvent);
        }

        public static void ReportOnTextSubmitEvent(int sceneNumber, string uuid, string text)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onTextSubmitEvent.uuid = uuid;
            onTextSubmitEvent.payload.text = text;

            SendSceneEvent(sceneNumber, "uuidEvent", onTextSubmitEvent);
        }

        public static void ReportOnTextInputChangedEvent(int sceneNumber, string uuid, string text)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onTextInputChangeEvent.uuid = uuid;
            onTextInputChangeEvent.payload.value = text;

            SendSceneEvent(sceneNumber, "uuidEvent", onTextInputChangeEvent);
        }

        public static void ReportOnTextInputChangedTextEvent(int sceneNumber, string uuid, string text, bool isSubmit)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onTextInputChangeTextEvent.uuid = uuid;
            onTextInputChangeTextEvent.payload.value.value = text;
            onTextInputChangeTextEvent.payload.value.isSubmit = isSubmit;

            SendSceneEvent(sceneNumber, "uuidEvent", onTextInputChangeTextEvent);
        }

        public static void ReportOnFocusEvent(int sceneNumber, string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onFocusEvent.uuid = uuid;
            SendSceneEvent(sceneNumber, "uuidEvent", onFocusEvent);
        }

        public static void ReportOnBlurEvent(int sceneNumber, string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onBlurEvent.uuid = uuid;
            SendSceneEvent(sceneNumber, "uuidEvent", onBlurEvent);
        }

        public static void ReportOnScrollChange(int sceneNumber, string uuid, Vector2 value, int pointerId)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                return;
            }

            onScrollChangeEvent.uuid = uuid;
            onScrollChangeEvent.payload.value = value;
            onScrollChangeEvent.payload.pointerId = pointerId;

            SendSceneEvent(sceneNumber, "uuidEvent", onScrollChangeEvent);
        }

        public static void ReportEvent<T>(int sceneNumber, T @event) { SendSceneEvent(sceneNumber, "uuidEvent", @event); }

        public static void ReportOnMetricsUpdate(int sceneNumber, MetricsModel current,
            MetricsModel limit)
        {
            onMetricsUpdate.given = current;
            onMetricsUpdate.limit = limit;

            SendSceneEvent(sceneNumber, "metricsUpdate", onMetricsUpdate);
        }

        public static void ReportOnEnterEvent(int sceneNumber, string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
                return;

            onEnterEvent.uuid = uuid;

            SendSceneEvent(sceneNumber, "uuidEvent", onEnterEvent);
        }

        public static void LogOut() { SendMessage("LogOut"); }

        public static void RedirectToSignUp() { SendMessage("RedirectToSignUp"); }

        public static void PreloadFinished(int sceneNumber) { SendMessage("PreloadFinished", sceneNumber); }

        public static void ReportMousePosition(Vector3 mousePosition, string id)
        {
            positionPayload.mousePosition = mousePosition;
            positionPayload.id = id;
            SendMessage("ReportMousePosition", positionPayload);
        }

        public static void SendScreenshot(string encodedTexture, string id)
        {
            onSendScreenshot.encodedTexture = encodedTexture;
            onSendScreenshot.id = id;
            SendMessage("SendScreenshot", onSendScreenshot);
        }

        public static void SetDelightedSurveyEnabled(bool enabled)
        {
            delightedSurveyEnabled.enabled = enabled;
            SendMessage("SetDelightedSurveyEnabled", delightedSurveyEnabled);
        }

        public static void SetScenesLoadRadius(float newRadius)
        {
            setScenesLoadRadiusPayload.newRadius = newRadius;
            SendMessage("SetScenesLoadRadius", setScenesLoadRadiusPayload);
        }

        [System.Serializable]
        public class SaveAvatarPayload
        {
            public string face256;
            public string body;
            public bool isSignUpFlow;
            public AvatarModelDTO avatar;
        }

        [System.Serializable]
        public class SaveUserOutfitsPayload
        {
            public OutfitItem[] outfits;
            public string[] namesForExtraSlots;
        }

        public static class RendererAuthenticationType
        {
            public static string Guest => "guest";
            public static string WalletConnect => "wallet_connect";
        }

        [System.Serializable]
        public class SendAuthenticationPayload
        {
            public string rendererAuthenticationType;
        }

        [System.Serializable]
        public class SendPassportPayload
        {
            public string name;
            public string email;
        }

        [System.Serializable]
        public class SendSaveUserVerifiedNamePayload
        {
            public string newVerifiedName;
        }

        [System.Serializable]
        public class SendSaveUserUnverifiedNamePayload
        {
            public string newUnverifiedName;
        }

        [System.Serializable]
        public class SendSaveUserDescriptionPayload
        {
            public string description;

            public SendSaveUserDescriptionPayload(string description) { this.description = description; }
        }

        [System.Serializable]
        public class SendRequestUserProfilePayload
        {
            public string value;
        }

        [Serializable]
        public class SendVideoProgressEvent
        {
            public string componentId;
            public int sceneNumber;
            public string videoTextureId;
            public int status;
            public float currentOffset;
            public float videoLength;
        }

        public static void RequestOwnProfileUpdate() { SendMessage("RequestOwnProfileUpdate"); }

        public static void SendSaveAvatar(AvatarModel avatar, Texture2D face256Snapshot, Texture2D bodySnapshot, bool isSignUpFlow = false)
        {
            var payload = new SaveAvatarPayload
            {
                avatar = AvatarModelDTO.FromAvatarModel(avatar),
                face256 = System.Convert.ToBase64String(face256Snapshot.EncodeToPNG()),
                body = System.Convert.ToBase64String(bodySnapshot.EncodeToPNG()),
                isSignUpFlow = isSignUpFlow
            };
            SendMessage("SaveUserAvatar", payload);
        }

        public static void SaveUserOutfits(OutfitItem[] outfits)
        {
            var payload = new SaveUserOutfitsPayload()
            {
                outfits = outfits,
                namesForExtraSlots = new string[]{}
            };

            SendMessage("SaveUserOutfits", payload);
        }

        public static void SendAuthentication(string rendererAuthenticationType) { SendMessage("SendAuthentication", new SendAuthenticationPayload { rendererAuthenticationType = rendererAuthenticationType }); }

        public static void SendPassport(string name, string email) { SendMessage("SendPassport", new SendPassportPayload { name = name, email = email }); }

        public static void SendSaveUserVerifiedName(string newName)
        {
            var payload = new SendSaveUserVerifiedNamePayload()
            {
                newVerifiedName = newName
            };

            SendMessage("SaveUserVerifiedName", payload);
        }

        public static void SendSaveUserUnverifiedName(string newName)
        {
            var payload = new SendSaveUserUnverifiedNamePayload()
            {
                newUnverifiedName = newName
            };

            SendMessage("SaveUserUnverifiedName", payload);
        }

        public static void SendSaveUserDescription(string about) { SendMessage("SaveUserDescription", new SendSaveUserDescriptionPayload(about)); }

        public static void SendRequestUserProfile(string userId) { SendMessage("RequestUserProfile", new SendRequestUserProfilePayload() { value = userId }); }

        public static void SaveUserTutorialStep(int newTutorialStep) { SendMessage("SaveUserTutorialStep", new TutorialStepPayload() { tutorialStep = newTutorialStep }); }

        public static void SendPerformanceReport(string performanceReportPayload) { SendJson("PerformanceReport", performanceReportPayload); }

        public static void SendSystemInfoReport() { SendMessage("SystemInfoReport", new SystemInfoReportPayload()); }

        public static void SendTermsOfServiceResponse(int sceneNumber, bool accepted, bool dontShowAgain)
        {
            var payload = new TermsOfServiceResponsePayload()
            {
                sceneNumber = sceneNumber,
                accepted = accepted,
                dontShowAgain = dontShowAgain
            };
            SendMessage("TermsOfServiceResponse", payload);
        }

        public static void OpenURL(string url)
        {
#if UNITY_WEBGL
            SendMessage("OpenWebURL", new OpenURLPayload { url = url });
#else
            Application.OpenURL(url);
#endif
        }

        public static void PublishStatefulScene(ProtocolV2.PublishPayload payload) { MessageFromEngine("PublishSceneState", JsonConvert.SerializeObject(payload)); }

        public static void SendReportScene(int sceneNumber)
        {
            SendMessage("ReportScene", new SendReportScenePayload
            {
                sceneNumber = sceneNumber
            });
        }

        public static void SetHomeScene(string sceneCoords)
        {
            SendMessage("SetHomeScene", new SetHomeScenePayload
            {
                sceneCoords = sceneCoords
            });
        }

        public static void SendReportPlayer(string playerId, string playerName)
        {
            SendMessage("ReportPlayer", new SendReportPlayerPayload
            {
                userId = playerId,
                name = playerName
            });
        }

        public static void SendBlockPlayer(string userId)
        {
            SendMessage("BlockPlayer", new SendBlockPlayerPayload()
            {
                userId = userId
            });
        }

        public static void SendUnblockPlayer(string userId)
        {
            SendMessage("UnblockPlayer", new SendUnblockPlayerPayload()
            {
                userId = userId
            });
        }

        public static void RequestScenesInfoAroundParcel(Vector2 parcel, int maxScenesArea)
        {
            SendMessage("RequestScenesInfoInArea", new RequestScenesInfoAroundParcelPayload()
            {
                parcel = parcel,
                scenesAround = maxScenesArea
            });
        }

        public static void SendAudioStreamEvent(string url, bool play, float volume)
        {
            onAudioStreamingEvent.url = url;
            onAudioStreamingEvent.play = play;
            onAudioStreamingEvent.volume = volume;
            SendMessage("SetAudioStream", onAudioStreamingEvent);
        }

        public static void JoinVoiceChat() { SendMessage("JoinVoiceChat"); }

        public static void LeaveVoiceChat() { SendMessage("LeaveVoiceChat"); }

        public static void SendSetVoiceChatRecording(bool recording)
        {
            setVoiceChatRecordingPayload.recording = recording;
            SendMessage("SetVoiceChatRecording", setVoiceChatRecordingPayload);
        }

        public static void ToggleVoiceChatRecording() { SendMessage("ToggleVoiceChatRecording"); }

        public static void ApplySettings(float voiceChatVolume, int voiceChatAllowCategory)
        {
            applySettingsPayload.voiceChatVolume = voiceChatVolume;
            applySettingsPayload.voiceChatAllowCategory = voiceChatAllowCategory;
            SendMessage("ApplySettings", applySettingsPayload);
        }

        public static void RequestGIFProcessor(string gifURL, string gifId, bool isWebGL1)
        {
            gifSetupPayload.imageSource = gifURL;
            gifSetupPayload.id = gifId;
            gifSetupPayload.isWebGL1 = isWebGL1;

            SendMessage("RequestGIFProcessor", gifSetupPayload);
        }

        public static void DeleteGIF(string id)
        {
            stringPayload.value = id;
            SendMessage("DeleteGIF", stringPayload);
        }

        public static void GoTo(int x, int y)
        {
            gotoEvent.x = x;
            gotoEvent.y = y;
            SendMessage("GoTo", gotoEvent);
        }

        public static void GoToCrowd()
        {
            SendMessage("GoToCrowd");
        }

        public static void GoToMagic()
        {
            SendMessage("GoToMagic");
        }

        public static void LoadingHUDReadyForTeleport(int x, int y)
        {
            gotoEvent.x = x;
            gotoEvent.y = y;
            SendMessage("LoadingHUDReadyForTeleport", gotoEvent);
        }

        public static void JumpIn(int x, int y, string serverName, string layerName)
        {
            jumpInPayload.realm.serverName = serverName;
            jumpInPayload.realm.layer = layerName;

            jumpInPayload.gridPosition.x = x;
            jumpInPayload.gridPosition.y = y;

            SendMessage("JumpIn", jumpInPayload);
        }

        public static void JumpInHome(string mostPopulatedRealm)
        {
            jumpInPayload.realm.serverName = mostPopulatedRealm;
            SendMessage("JumpInHome", jumpInPayload);
        }

        public static void SendChatMessage(ChatMessage message)
        {
            sendChatMessageEvent.message = message;
            SendMessage("SendChatMessage", sendChatMessageEvent);
        }

        public static void UpdateFriendshipStatus(FriendshipUpdateStatusMessage message) { SendMessage("UpdateFriendshipStatus", message); }

        public static void ScenesLoadingFeedback(LoadingFeedbackMessage message) { SendMessage("ScenesLoadingFeedback", message); }

        public static void FetchHotScenes() { SendMessage("FetchHotScenes"); }

        public static void SetBaseResolution(int resolution)
        {
            baseResEvent.baseResolution = resolution;
            SendMessage("SetBaseResolution", baseResEvent);
        }

        public static void ReportAnalyticsEvent(string eventName) { ReportAnalyticsEvent(eventName, null); }

        public static void ReportAnalyticsEvent(string eventName, AnalyticsPayload.Property[] eventProperties)
        {
            analyticsEvent.name = eventName;
            analyticsEvent.properties = eventProperties;
            SendMessage("Track", analyticsEvent);
        }

        public static void FetchBalanceOfMANA() { SendMessage("FetchBalanceOfMANA"); }

        public static void SendSceneExternalActionEvent(int sceneNumber, string type, string payload)
        {
            sceneExternalActionEvent.type = type;
            sceneExternalActionEvent.payload = payload;
            SendSceneEvent(sceneNumber, "externalAction", sceneExternalActionEvent);
        }

        public static void SetMuteUsers(string[] usersId, bool mute)
        {
            muteUserEvent.usersId = usersId;
            muteUserEvent.mute = mute;
            SendMessage("SetMuteUsers", muteUserEvent);
        }

        public static void SendCloseUserAvatar(bool isSignUpFlow)
        {
            closeUserAvatarPayload.isSignUpFlow = isSignUpFlow;
            SendMessage("CloseUserAvatar", closeUserAvatarPayload);
        }

        // Warning: Use this method only for PEXs non-associated to smart wearables.
        //          For PEX associated to smart wearables use 'SetDisabledPortableExperiences'.
        public static void KillPortableExperience(string portableExperienceId)
        {
            killPortableExperiencePayload.portableExperienceId = portableExperienceId;
            SendMessage("KillPortableExperience", killPortableExperiencePayload);
        }

        public static void RequestThirdPartyWearables(
            string ownedByUser,
            string thirdPartyCollectionId,
            string context)
        {
            requestWearablesPayload.filters = new WearablesRequestFiltersPayload
            {
                ownedByUser = ownedByUser,
                thirdPartyId = thirdPartyCollectionId,
                collectionIds = null,
                wearableIds = null
            };

            requestWearablesPayload.context = context;

            SendMessage("RequestWearables", requestWearablesPayload);
        }

        public static void SetDisabledPortableExperiences(string[] idsToDisable)
        {
            setDisabledPortableExperiencesPayload.idsToDisable = idsToDisable;
            SendMessage("SetDisabledPortableExperiences", setDisabledPortableExperiencesPayload);
        }

        public static void RequestWearables(
            string ownedByUser,
            string[] wearableIds,
            string[] collectionIds,
            string context)
        {
            requestWearablesPayload.filters = new WearablesRequestFiltersPayload
            {
                ownedByUser = ownedByUser,
                wearableIds = wearableIds,
                collectionIds = collectionIds,
                thirdPartyId = null
            };

            requestWearablesPayload.context = context;

            SendMessage("RequestWearables", requestWearablesPayload);
        }

        public static void RequestEmotes(
            string ownedByUser,
            string[] emoteIds,
            string[] collectionIds,
            string context)
        {
            requestEmotesPayload.filters = new EmotesRequestFiltersPayload()
            {
                ownedByUser = ownedByUser,
                emoteIds = emoteIds,
                collectionIds = collectionIds,
                thirdPartyId = null
            };

            requestEmotesPayload.context = context;

            SendMessage("RequestEmotes", requestEmotesPayload);
        }

        public static void SearchENSOwner(string name, int maxResults)
        {
            searchEnsOwnerPayload.name = name;
            searchEnsOwnerPayload.maxResults = maxResults;

            SendMessage("SearchENSOwner", searchEnsOwnerPayload);
        }

        public static void RequestHomeCoordinates() { SendMessage("RequestHomeCoordinates"); }

        public static void RequestUserProfile(string userId)
        {
            stringPayload.value = userId;
            SendMessage("RequestUserProfile", stringPayload);
        }

        public static void ReportAvatarFatalError(string payload)
        {
            ErrorPayload errorPayload = new ErrorPayload() { error = payload };
            SendMessage("ReportAvatarFatalError", errorPayload);
        }

        public static void UnpublishScene(Vector2Int sceneCoordinates)
        {
            var payload = new UnpublishScenePayload() { coordinates = $"{sceneCoordinates.x},{sceneCoordinates.y}" };
            SendMessage("UnpublishScene", payload);
        }

        public static void NotifyStatusThroughChat(string message)
        {
            stringPayload.value = message;
            SendMessage("NotifyStatusThroughChat", stringPayload);
        }

        public static void ReportVideoProgressEvent(
            string componentId,
            int sceneNumber,
            string videoClipId,
            int videoStatus,
            float currentOffset,
            float length)
        {
            SendVideoProgressEvent progressEvent = new SendVideoProgressEvent()
            {
                componentId = componentId,
                sceneNumber = sceneNumber,
                videoTextureId = videoClipId,
                status = videoStatus,
                currentOffset = currentOffset,
                videoLength = float.IsInfinity(length) ? float.MaxValue : length
            };

            SendMessage("VideoProgressEvent", progressEvent);
        }

        public static void ReportAvatarRemoved(string avatarId)
        {
            avatarStatePayload.type = "Removed";
            avatarStatePayload.avatarShapeId = avatarId;
            SendMessage("ReportAvatarState", avatarStatePayload);
        }

        public static void ReportAvatarSceneChanged(string avatarId, int sceneNumber)
        {
            avatarSceneChangedPayload.type = "SceneChanged";
            avatarSceneChangedPayload.avatarShapeId = avatarId;
            avatarSceneChangedPayload.sceneNumber = sceneNumber;
            SendMessage("ReportAvatarState", avatarSceneChangedPayload);
        }

        public static void ReportAvatarClick(int sceneNumber, string userId, Vector3 rayOrigin, Vector3 rayDirection, float distance)
        {
            avatarOnClickPayload.userId = userId;
            avatarOnClickPayload.ray.origin = rayOrigin;
            avatarOnClickPayload.ray.direction = rayDirection;
            avatarOnClickPayload.ray.distance = distance;

            SendSceneEvent(sceneNumber, "playerClicked", avatarOnClickPayload);
        }

        public static void ReportOnPointerHoverEnterEvent(int sceneNumber, string uuid)
        {
            onPointerHoverEnterEvent.uuid = uuid;
            SendSceneEvent(sceneNumber, "uuidEvent", onPointerHoverEnterEvent);
        }

        public static void ReportOnPointerHoverExitEvent(int sceneNumber, string uuid)
        {
            onPointerHoverExitEvent.uuid = uuid;
            SendSceneEvent(sceneNumber, "uuidEvent", onPointerHoverExitEvent);
        }

        public static void ReportTime(float time, bool isPaused, float timeNormalizationFactor, float cycleTime)
        {
            timeReportPayload.time = time;
            timeReportPayload.isPaused = isPaused;
            timeReportPayload.timeNormalizationFactor = timeNormalizationFactor;
            timeReportPayload.cycleTime = cycleTime;
            SendMessage("ReportMemetaverseTime", timeReportPayload);
        }

        public static void GetFriendsWithDirectMessages(string userNameOrId, int limit, int skip)
        {
            getFriendsWithDirectMessagesPayload.userNameOrId = userNameOrId;
            getFriendsWithDirectMessagesPayload.limit = limit;
            getFriendsWithDirectMessagesPayload.skip = skip;
            SendMessage("GetFriendsWithDirectMessages", getFriendsWithDirectMessagesPayload);
        }

        public static void MarkMessagesAsSeen(string userId)
        {
            markMessagesAsSeenPayload.userId = userId;
            SendMessage("MarkMessagesAsSeen", markMessagesAsSeenPayload);
        }

        public static void GetPrivateMessages(string userId, int limit, string fromMessageId)
        {
            getPrivateMessagesPayload.userId = userId;
            getPrivateMessagesPayload.limit = limit;
            getPrivateMessagesPayload.fromMessageId = fromMessageId;
            SendMessage("GetPrivateMessages", getPrivateMessagesPayload);
        }

        public static void MarkChannelMessagesAsSeen(string channelId)
        {
            markChannelMessagesAsSeenPayload.channelId = channelId;
            SendMessage("MarkChannelMessagesAsSeen", markChannelMessagesAsSeenPayload);
        }

        public static void GetUnseenMessagesByUser() { SendMessage("GetUnseenMessagesByUser"); }

        public static void GetUnseenMessagesByChannel()
        {
            SendMessage("GetUnseenMessagesByChannel");
        }

        public static void GetFriends(int limit, int skip)
        {
            SendMessage("GetFriends", new GetFriendsPayload
            {
                limit = limit,
                skip = skip
            });
        }

        public static void GetFriends(string usernameOrId, int limit)
        {
            SendMessage("GetFriends", new GetFriendsPayload
            {
                userNameOrId = usernameOrId,
                limit = limit
            });
        }

        public static void LeaveChannel(string channelId)
        {
            SendMessage("LeaveChannel", new LeaveChannelPayload
            {
                channelId = channelId
            });
        }

        public static void CreateChannel(string channelId)
        {
            SendMessage("CreateChannel", new CreateChannelPayload
            {
                channelId = channelId
            });
        }

        public static void JoinOrCreateChannel(string channelId)
        {
            SendMessage("JoinOrCreateChannel", new JoinOrCreateChannelPayload
            {
                channelId = channelId
            });
        }

        public static void GetChannelMessages(string channelId, int limit, string fromMessageId)
        {
            SendMessage("GetChannelMessages", new GetChannelMessagesPayload
            {
                channelId = channelId,
                limit = limit,
                from = fromMessageId
            });
        }

        public static void GetJoinedChannels(int limit, int skip)
        {
            SendMessage("GetJoinedChannels", new GetJoinedChannelsPayload
            {
                limit = limit,
                skip = skip
            });
        }

        public static void GetChannels(int limit, string since, string name)
        {
            SendMessage("GetChannels", new GetChannelsPayload
            {
                limit = limit,
                since = since,
                name = name
            });
        }

        public static void GetChannelInfo(string[] channelIds)
        {
            SendMessage("GetChannelInfo", new GetChannelInfoPayload
            {
                channelIds = channelIds
            });
        }

        public static void GetChannelMembers(string channelId, int limit, int skip, string name)
        {
            SendMessage("GetChannelMembers", new GetChannelMembersPayload
            {
                channelId = channelId,
                limit = limit,
                skip = skip,
                userName = name
            });
        }

        public static void MuteChannel(string channelId, bool muted)
        {
            SendMessage("MuteChannel", new MuteChannelPayload
            {
                channelId = channelId,
                muted = muted
            });
        }

        public static void UpdateMemoryUsage()
        {
            SendMessage("UpdateMemoryUsage");
        }

        public static void RequestAudioDevices() => SendMessage("RequestAudioDevices");

        public static void SetInputAudioDevice(string inputDeviceId)
        {
            SendMessage(nameof(SetInputAudioDevice), new SetInputAudioDevicePayload()
            {
                deviceId = inputDeviceId
            });
        }


        // After A/B test seamless login this should be removed and implement a proper renderer<>browser-interface service
        public static void SendToSPopupAccepted()
        {
            SendMessage("ToSPopupAccepted");
        }

        public static void SendToSPopupRejected()
        {
            SendMessage("ToSPopupRejected");
        }

        public static void SendGoToTos()
        {
            SendMessage("ToSPopupGoToToS");
        }

        public static void SaveProfileLinks(SaveLinksPayload payload)
        {
            SendMessage("SaveProfileLinks", payload);
        }

        public static void SaveAdditionalInfo(SaveAdditionalInfoPayload payload)
        {
            SendMessage("SaveProfileAdditionalInfo", payload);
        }

        public static void GetWithCollectionsUrlParam()
        {
            SendMessage("GetWithCollectionsUrlParam");
        }

        public static void GetWithItemsUrlParam()
        {
            SendMessage("GetWithItemsUrlParam");
        }
    }
}
