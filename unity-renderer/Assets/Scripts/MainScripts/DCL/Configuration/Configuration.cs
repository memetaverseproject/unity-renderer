using System.Collections.Generic;
using UnityEngine;

namespace DCL.Configuration
{
    public static class AssetCatalogUrlSettings // EX: BIWSettings
    {
        //Note: Don't use these URL directly, you need to get them in the SceneEndpoints (before known as BuilderInWorldUtils) to take into account the ENV
        public const string BASE_URL_SCENE_OBJECT_CONTENT = "https://builder-api.memetaverse.club/v1/storage/contents/";
        public const string BASE_URL_CATALOG = "https://builder-api.memetaverse.club/v1/assetPacks?owner=";
        public const string BASE_URL_ASSETS_PACK_CONTENT = "https://builder-api.memetaverse.club/v1/storage/assetPacks/";

        public const string BASE_URL_BUILDER_PROJECT_THUMBNAIL = "https://builder-api.memetaverse.club/v1/projects/{id}/media/";

        //Useful links
        public const string MARKETPLACE_URL = "https://market.memetaverse.club/lands";
        public const string GUEST_WALLET_INFO = "https://docs.memetaverse.club/examples/get-a-wallet/";

        //Deployment constants
        public const string DEPLOYMENT_DEFINITION_FILE = "scene-state-definition.json";
        public const string DEPLOYMENT_SCENE_FILE = "scene.json";
        public const string DEPLOYMENT_MODELS_FOLDER = "models";
        public const string DEPLOYMENT_BUNDLED_GAME_FILE = "bin/game.js";
        public const string DEPLOYMENT_SCENE_THUMBNAIL = "thumbnail.png";
        public const string DEPLOYMENT_ASSETS = "scene-assets.json";
        public const string DEPLOYMENT_SOURCE_TYPE = "builder-in-world";

        //Layers
        public static readonly LayerMask SELECTION_LAYER_INDEX = LayerMask.NameToLayer("Selection");
        public static readonly LayerMask DEFAULT_LAYER_INDEX = LayerMask.NameToLayer("Default");
        public static readonly LayerMask COLLIDER_SELECTION_LAYER_INDEX = LayerMask.NameToLayer("OnBuilderPointerClick");

        public static readonly LayerMask SELECTION_LAYER = LayerMask.GetMask("Selection");
        public static readonly LayerMask COLLIDER_SELECTION_LAYER = LayerMask.GetMask("OnBuilderPointerClick");
        public static readonly LayerMask GIZMOS_LAYER = LayerMask.GetMask("Gizmo");
        public static readonly LayerMask GROUND_LAYER = LayerMask.GetMask("Ground");
        public static readonly LayerMask FX_LAYER = LayerMask.GetMask("FX");

        // Screenshot settings
        public const int SCENE_SNAPSHOT_WIDTH_RES = 854;
        public const int SCENE_SNAPSHOT_HEIGHT_RES = 480;

        public const int AERIAL_SCREENSHOT_WIDTH = 315;
        public const int AERIAL_SCREENSHOT_HEIGHT = 253;

        // Identifiers
        public const string VOXEL_ASSETS_PACK_ID = "b51e5e7c-c56b-4ad9-b9d2-1dc1c6546169";
        public const string SMART_ITEM_ASSETS_PACK_ID = "07e7e010-3003-496d-a720-2a714a63a58b";
        public const string FLOOR_CATEGORY = "ground";

        public const string CATALOG_ASSET_PACK_TITLE = "Asset Packs";
        public const string VOXEL_TAG = "Voxel";
        public const string CUSTOM_LAND = "CUSTOM LAND";

        //NFT
        public const string NFT_ETHEREUM_PROTOCOL = "ethereum://";

        //Scene files
        public const string BUILDER_SCENE_STATE_DEFINITION_FILE_NAME = "scene-state-definition.json";
        public const string BUILDER_SCENE_ASSET_FILE_NAME = "scene-assets.json";

        //Builder API
        public const string PROJECT_NOT_FOUND = "Project doesn't exists";
        public const int MANIFEST_VERSION = 10;

        //Inputs
        public static float MOUSE_THRESHOLD_FOR_DRAG = 15f;
        public static float MOUSE_MS_DOUBLE_CLICK_THRESHOLD = 500f;

        //Kernel Report
        public const string STATE_EVENT_NAME = "stateEvent";
        public const string SCENE_EVENT_NAME = "SceneEvent";
        public static float ENTITY_POSITION_REPORTING_DELAY = 0.1f; // In seconds
        public static float ENTITY_POSITION_REPORTING_THRESHOLD = 0.04f; // In meters
        public static float ENTITY_SCALE_REPORTING_THRESHOLD = 0.04f; // In meters
        public static float ENTITY_ROTATION_REPORTING_THRESHOLD = 0.1f; // In degrees

        //Floor Scene Object
        public const string FLOOR_ID = "c9b17021-765c-4d9a-9966-ce93a9c323d1";
        public const string FLOOR_MODEL = "FloorBaseGrass_01/FloorBaseGrass_01.glb";
        public const string FLOOR_NAME = "Floor";
        public const string FLOOR_ASSET_PACK_ID = "e6fa9601-3e47-4dff-9a84-e8e017add15a";
        public const string FLOOR_ASSET_PACK_NAME = "Genesis City";
        public const string FLOOR_ASSET_THUMBNAIL = "https://builder-api.memetaverse.club/v1/storage/contents/QmexuPHcbEtQCR11dPXxKZmRjGuY4iTooPJYfST7hW71DE";

        public const string FLOOR_GLTF_KEY = "FloorBaseGrass_01/FloorBaseGrass_01.glb";
        public const string FLOOR_GLTF_VALUE = "QmSyvWnb5nKCaGHw9oHLSkwywvS5NYpj6vgb8L121kWveS";

        public const string FLOOR_TEXTURE_KEY = "FloorBaseGrass_01/Floor_Grass01.png.png";
        public const string FLOOR_TEXTURE_VALUE = "QmT1WfQPMBVhgwyxV5SfcfWivZ6hqMCT74nxdKXwyZBiXb";

        public const string FLOOR_THUMBNAIL_KEY = "FloorBaseGrass_01/thumbnail.png";
        public const string FLOOR_THUMBNAIL_VALUE = "QmexuPHcbEtQCR11dPXxKZmRjGuY4iTooPJYfST7hW71DE";

        //Collectables
        public const string ASSETS_COLLECTIBLES = "Collectibles";
        public const string COLLECTIBLE_MODEL_PROTOCOL = "ethereum://";

        //Gizmos
        public const string TRANSLATE_GIZMO_NAME = "MOVE";
        public const string ROTATE_GIZMO_NAME = "ROTATE";
        public const string SCALE_GIZMO_NAME = "SCALE";
        public const string EMPTY_GIZMO_NAME = "NONE";
        public const float GIZMOS_RELATIVE_SCALE_RATIO = 0.06f;

        //Publish
        public const string EXIT_MODAL_TITLE = "Exiting Builder mode";
        public const string EXIT_MODAL_SUBTITLE = "Are you sure you want to exit Builder mode? You can continue your work later";
        public const string EXIT_MODAL_CONFIRM_BUTTON = "EXIT";
        public const string EXIT_MODAL_CANCEL_BUTTON = "CANCEL";
        public const string EXIT_WITHOUT_PUBLISH_MODAL_SUBTITLE = "There are unpublished changes in this scene. But don't worry, next time you enter the editor you will be able to continue where you left off!";
        public const string EXIT_WITHOUT_PUBLISH_MODAL_CONFIRM_BUTTON = "GOT IT!";
        public const string EXIT_WITHOUT_PUBLISH_MODAL_CANCEL_BUTTON = "BACK";

        //Others
        public const float RAYCAST_MAX_DISTANCE = 10000f;
        public const string LAND_EDITION_NOT_ALLOWED_BY_PERMISSIONS_MESSAGE = "This land does not belong to you, nor have you been granted operating permits by its owner.";
        public const string LAND_EDITION_WAITING_FOR_PERMISSIONS_MESSAGE = "Checking if you have permission to edit this land";
        public const string LAND_EDITION_NOT_ALLOWED_BY_SDK_LIMITATION_MESSAGE = "This place was created with the SDK and can not be edited in-world.";
        public const string GUEST_CANT_USE_BUILDER = "In order to use the builder, you need to log-in connecting a wallet";
        public const float CACHE_TIME_LAND = 5 * 60;
        public const float CACHE_TIME_SCENES = 1 * 60;
        public const float REFRESH_LANDS_WITH_ACCESS_INTERVAL = 2 * 60;
        public const float LAND_NOTIFICATIONS_TIMER = 10f;
        public const float LAND_CHECK_MESSAGE_TIMER = 5f;
    }

    public static class TextureCompressionSettings
    {
        public const int GLTF_TEX_MAX_SIZE_WEB = 512;
        public const int GENERAL_TEX_MAX_SIZE_WEB = 2048;
    }

    public static class ApplicationSettings
    {
        public static string version = "1.0";
    }

    public static class EnvironmentSettings
    {
        public static bool RUNNING_TESTS = false;
        public static bool DEBUG = true;
        public static readonly int MORDOR_SCALAR = 8000;
        public static readonly Vector3 MORDOR = new Vector3(MORDOR_SCALAR, MORDOR_SCALAR, MORDOR_SCALAR);
        public const float UNINITIALIZED_FLOAT = 999999f;
        public static readonly int AVATAR_GLOBAL_SCENE_NUMBER = 1;
    }

    public static class InputSettings
    {
        public static KeyCode PrimaryButtonKeyCode = KeyCode.E;
        public static KeyCode SecondaryButtonKeyCode = KeyCode.F;
        public static KeyCode ForwardButtonKeyCode = KeyCode.W;
        public static KeyCode BackwardButtonKeyCode = KeyCode.S;
        public static KeyCode LeftButtonKeyCode = KeyCode.A;
        public static KeyCode RightButtonKeyCode = KeyCode.D;
        public static KeyCode ForwardButtonKeyCodeAlt = KeyCode.UpArrow;
        public static KeyCode BackwardButtonKeyCodeAlt = KeyCode.DownArrow;
        public static KeyCode LeftButtonKeyCodeAlt = KeyCode.LeftArrow;
        public static KeyCode RightButtonKeyCodeAlt = KeyCode.RightArrow;
        public static KeyCode JumpButtonKeyCode = KeyCode.Space;
        public static KeyCode WalkButtonKeyCode = KeyCode.LeftShift;
        public static KeyCode PlusKeyCode = KeyCode.KeypadPlus;
        public static KeyCode MinusKeyCode = KeyCode.KeypadMinus;
        public static KeyCode ActionButton3Keycode = KeyCode.Alpha1;
        public static KeyCode ActionButton4Keycode = KeyCode.Alpha2;
        public static KeyCode ActionButton5Keycode = KeyCode.Alpha3;
        public static KeyCode ActionButton6Keycode = KeyCode.Alpha4;
    }

    public static class PlayerSettings
    {
        public static float POSITION_REPORTING_DELAY = 0.1f; // In seconds
        public static float WORLD_REPOSITION_MINIMUM_DISTANCE = 100f;
    }

    public static class ParcelSettings
    {
        public static float DEBUG_FLOOR_HEIGHT = -0.1f;
        public static float PARCEL_SIZE = 16f;
        public static float PARCEL_BOUNDARIES_THRESHOLD = 0.01f;
        public static float UNLOAD_DISTANCE = PARCEL_SIZE * 12f;
    }

    public static class TestSettings
    {
        public static int VISUAL_TESTS_APPROVED_AFFINITY = 93;
        public static float VISUAL_TESTS_PIXELS_CHECK_THRESHOLD = 5.0f;
        public static int VISUAL_TESTS_SNAPSHOT_WIDTH = 1280;
        public static int VISUAL_TESTS_SNAPSHOT_HEIGHT = 720;
    }

    public static class AssetManagerSettings
    {
        //When library item count gets above this threshold, unused items will get pruned on Get() method.
        public static int LIBRARY_CLEANUP_THRESHOLD = 10;
    }

    public static class MessageThrottlingSettings
    {
        public static float SIXTY_FPS_TIME = 1.0f / 60.0f;
        public static float GLOBAL_FRAME_THROTTLING_TIME = SIXTY_FPS_TIME / 8.0f;
        public static float LOAD_PARCEL_SCENES_THROTTLING_TIME = SIXTY_FPS_TIME / 4.0f;
    }

    public static class UISettings
    {
        public static float RESERVED_CANVAS_TOP_PERCENTAGE = 10f;
    }

    public static class NFTDataFetchingSettings
    {
        public static UnityEngine.Vector2
            NORMALIZED_DIMENSIONS =
                new UnityEngine.Vector2(512f, 512f); // The image dimensions that correspond to Vector3.One scale

        public static string DAR_API_URL = "https://schema.memetaverse.club/dar";
    }

    public static class PhysicsLayers
    {
        public static int defaultLayer = LayerMask.NameToLayer("Default");
        public static int onPointerEventLayer = LayerMask.NameToLayer("OnPointerEvent");
        public static int characterLayer = LayerMask.NameToLayer("CharacterController");
        public static int characterOnlyLayer = LayerMask.NameToLayer("CharacterOnly");
        public static int sdkCustomLayer = LayerMask.NameToLayer("SDKCustomLayer");
        public static LayerMask physicsCastLayerMask = 1 << onPointerEventLayer;

        public static LayerMask physicsCastLayerMaskWithoutCharacter = (physicsCastLayerMask | (1 << defaultLayer))
                                                                       & ~(1 << characterLayer)
                                                                       & ~(1 << characterOnlyLayer);

        public static int friendsHUDPlayerMenu = LayerMask.NameToLayer("FriendsHUDPlayerMenu");
        public static int playerInfoCardMenu = LayerMask.NameToLayer("PlayerInfoCardMenu");
        public static int avatarTriggerMask = LayerMask.GetMask("AvatarTriggerDetection");
    }
}
