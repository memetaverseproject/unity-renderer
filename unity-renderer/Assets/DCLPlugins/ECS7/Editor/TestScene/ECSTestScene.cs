using System;
using System.Collections;
using System.Reflection;
using DCL;
using DCL.Camera;
using DCL.CameraTool;
using DCL.ECS7;
using DCL.ECSComponents;
using DCL.ECSRuntime;
using DCL.Helpers;
using DCL.Interface;
using DCL.Models;
using Memetaverse.Common;
using UnityEngine;
using Environment = DCL.Environment;
using Font = DCL.ECSComponents.Font;

public class ECSTestScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadScene(SceneScript, SceneUpdateScript));
    }

    private static ContentProvider contentProvider;

    private static void SceneScript(int sceneNumber, IECSComponentWriter componentWriter)
    {
        componentWriter.PutComponent(sceneNumber, 101, ComponentID.TRANSFORM,
            new ECSTransform() { position = new UnityEngine.Vector3(1, 1, 1), scale = UnityEngine.Vector3.one });
        componentWriter.PutComponent(sceneNumber, 102, ComponentID.TRANSFORM,
            new ECSTransform() { position = new UnityEngine.Vector3(3, 1, 1), scale = UnityEngine.Vector3.one });
        componentWriter.PutComponent(sceneNumber, 103, ComponentID.TRANSFORM,
            new ECSTransform() { position = new UnityEngine.Vector3(5, 1, 1), scale = UnityEngine.Vector3.one });
        componentWriter.PutComponent(sceneNumber, 104, ComponentID.TRANSFORM,
            new ECSTransform() { position = new UnityEngine.Vector3(7, 1, 1), scale = UnityEngine.Vector3.one });
        componentWriter.PutComponent(sceneNumber, 105, ComponentID.TRANSFORM,
            new ECSTransform() { position = new UnityEngine.Vector3(1, 3, 1), scale = UnityEngine.Vector3.one });

        componentWriter.PutComponent(sceneNumber, 105, ComponentID.MESH_RENDERER, new PBMeshRenderer());
        componentWriter.PutComponent(sceneNumber, 101, ComponentID.MESH_RENDERER, new PBMeshRenderer() { Box = new PBMeshRenderer.Types.BoxMesh() });
        componentWriter.PutComponent(sceneNumber, 102, ComponentID.MESH_RENDERER, new PBMeshRenderer() { Sphere = new PBMeshRenderer.Types.SphereMesh() });
        componentWriter.PutComponent(sceneNumber, 103, ComponentID.MESH_RENDERER, new PBMeshRenderer() { Cylinder = new PBMeshRenderer.Types.CylinderMesh() { RadiusBottom = 1, RadiusTop = 1 } });
        componentWriter.PutComponent(sceneNumber, 104, ComponentID.MESH_RENDERER, new PBMeshRenderer() { Plane = new PBMeshRenderer.Types.PlaneMesh() });

        PBMaterial model = new PBMaterial()
        {
            Pbr = new PBMaterial.Types.PbrMaterial()
            {
                Texture = new Memetaverse.Common.TextureUnion()
                {
                    Texture = new Memetaverse.Common.Texture()
                    {
                        Src = TestAssetsUtils.GetPath() + "/Images/avatar.png"
                    }
                }
            }
        };

        componentWriter.PutComponent(sceneNumber, 105, ComponentID.MATERIAL, model);
        componentWriter.PutComponent(sceneNumber, 101, ComponentID.MATERIAL, model);
        componentWriter.PutComponent(sceneNumber, 102, ComponentID.MATERIAL, model);
        componentWriter.PutComponent(sceneNumber, 103, ComponentID.MATERIAL, model);
        componentWriter.PutComponent(sceneNumber, 104, ComponentID.MATERIAL, model);
    }

    private static void SceneUpdateScript(int sceneNumber, IECSComponentWriter componentWriter)
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            componentWriter.PutComponent(sceneNumber, 103, ComponentID.MESH_RENDERER, new PBMeshRenderer() { Plane = new PBMeshRenderer.Types.PlaneMesh() });
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            componentWriter.RemoveComponent(sceneNumber, 103, ComponentID.MESH_RENDERER);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            componentWriter.PutComponent(sceneNumber, 104, ComponentID.MESH_RENDERER, new PBMeshRenderer() { Plane = new PBMeshRenderer.Types.PlaneMesh() });
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            componentWriter.RemoveComponent(sceneNumber, 104, ComponentID.MESH_RENDERER);
        }
    }

    private static void AddTransform(UnityEngine.Vector3 position, long entityId, int sceneNumber, IECSComponentWriter componentWriter)
    {
        componentWriter.PutComponent(sceneNumber, entityId, ComponentID.TRANSFORM,
            new ECSTransform() { position = position, scale = UnityEngine.Vector3.one });
    }

    private static void AddAvatarShapeComponent(int sceneNumber, IECSComponentWriter componentWriter)
    {
        PBAvatarShape avatarShape = new PBAvatarShape();
        avatarShape.Id = "0xe7dd153081b0526e0a8c582497cbcee7cd44e464";
        avatarShape.Name = "TestName#2354";
        avatarShape.BodyShape = "urn:memetaverse:off-chain:base-avatars:BaseFemale";
        avatarShape.ExpressionTriggerId = "Idle";

        avatarShape.EyeColor = new Color3();
        avatarShape.EyeColor.R = 0.223f;
        avatarShape.EyeColor.G = 0.484f;
        avatarShape.EyeColor.B = 0.691f;

        avatarShape.HairColor = new Color3();
        avatarShape.HairColor.R = 0.223f;
        avatarShape.HairColor.G = 0.484f;
        avatarShape.HairColor.B = 0.691f;

        avatarShape.SkinColor = new Color3();
        avatarShape.SkinColor.R = 0.223f;
        avatarShape.SkinColor.G = 0.484f;
        avatarShape.SkinColor.B = 0.691f;

        avatarShape.Wearables.Add("urn:memetaverse:off-chain:base-avatars:f_eyebrows_07");
        avatarShape.Wearables.Add("urn:memetaverse:off-chain:base-avatars:eyes_02");
        avatarShape.Wearables.Add("urn:memetaverse:off-chain:base-avatars:f_mouth_03");
        avatarShape.Wearables.Add("urn:memetaverse:off-chain:base-avatars:f_school_skirt");
        avatarShape.Wearables.Add("urn:memetaverse:off-chain:base-avatars:SchoolShoes");
        avatarShape.Wearables.Add("urn:memetaverse:matic:collections-v2:0x177535a421e7867ec52f2cc19b7dfed4f289a2bb:0");
        avatarShape.Wearables.Add("urn:memetaverse:matic:collections-v2:0xd89efd0be036410d4ff194cd6ecece4ef8851d86:1");
        avatarShape.Wearables.Add("urn:memetaverse:matic:collections-v2:0x1df3011a14ea736314df6cdab4fff824c5d46ec1:0");
        avatarShape.Wearables.Add("urn:memetaverse:matic:collections-v2:0xbada8a315e84e4d78e3b6914003647226d9b4001:1");
        avatarShape.Wearables.Add("urn:memetaverse:matic:collections-v2:0x1df3011a14ea736314df6cdab4fff824c5d46ec1:5");
        avatarShape.Wearables.Add("urn:memetaverse:matic:collections-v2:0xd89efd0be036410d4ff194cd6ecece4ef8851d86:0");

        componentWriter.PutComponent(sceneNumber, 4, ComponentID.AVATAR_SHAPE,
            avatarShape);
    }

    private static void AddTextShapeComponent(int sceneNumber, IECSComponentWriter componentWriter)
    {
        PBTextShape model = new PBTextShape();
        model.Text = "Hi text";
        model.Font = Font.FSansSerif;
        model.FontSize = 16;
        model.TextColor = new Color4();
        model.TextColor.R = 255f;
        model.TextColor.G = 255f;
        model.TextColor.B = 255f;
        model.TextWrapping = true;
        model.Width = 200;
        model.Height = 100;
        // model.Opacity = 1f;
        componentWriter.PutComponent(sceneNumber, 3, ComponentID.TEXT_SHAPE,
            model);
    }

    private static void AddBillBoardComponent(int sceneNumber, IECSComponentWriter componentWriter)
    {
        PBBillboard model = new PBBillboard();
        model.BillboardMode = BillboardMode.BmAll;
        componentWriter.PutComponent(sceneNumber, 3, ComponentID.BILLBOARD,
            model);
    }

    private static void AddNFTComponent(int sceneNumber, IECSComponentWriter componentWriter)
    {
        PBNftShape model = new PBNftShape();
        model.Urn = "urn:memetaverse:ethereum:erc721:0x06012c8cf97bead5deae237070f9587f8e7a266d:1540722";
        model.Color = new Color3();
        model.Style = (NftFrameType)6;
        model.Color.R = 0.5f;
        model.Color.G = 0.5f;
        model.Color.B = 1f;
        componentWriter.PutComponent(sceneNumber, 0, ComponentID.NFT_SHAPE,
            model);
    }

    private static IEnumerator LoadScene(Action<int, IECSComponentWriter> sceneScript, Action<int, IECSComponentWriter> updateScript)
    {
        LoadParcelScenesMessage.UnityParcelScene scene = new LoadParcelScenesMessage.UnityParcelScene()
        {
            basePosition = new Vector2Int(0, 0),
            parcels = new Vector2Int[] { new Vector2Int(0, 0) },
            id = "temptation"
        };

        bool started = false;

        WebInterface.OnMessageFromEngine += (type, s1) =>
        {
            if (type == "SystemInfoReport")
            {
                started = true;
            }
        };

        yield return new WaitUntil(() => started);
        yield return new WaitForSeconds(2);

        var mainGO = GameObject.Find("Main");
        mainGO.SendMessage("SetDebug");

        ECS7Plugin ecs7Plugin = new ECS7Plugin();

        Environment.i.world.sceneController.LoadParcelScenes(JsonUtility.ToJson(scene));
        var playerAvatarController = FindObjectOfType<PlayerAvatarController>();
        CommonScriptableObjects.rendererState.RemoveLock(playerAvatarController);

        yield return new WaitForSeconds(1);

        IECSComponentWriter componentWriter = typeof(ECS7Plugin)
                                              .GetField("componentWriter", BindingFlags.NonPublic | BindingFlags.Instance)
                                              .GetValue(ecs7Plugin) as IECSComponentWriter;

        contentProvider = Environment.i.world.state.GetScene(scene.sceneNumber).contentProvider;
        contentProvider.baseUrl = "";

        sceneScript.Invoke(scene.sceneNumber, componentWriter);

        mainGO.SendMessage("ActivateRendering");

        var message = new QueuedSceneMessage_Scene
        {
            sceneNumber = scene.sceneNumber,
            tag = "",
            type = QueuedSceneMessage.Type.SCENE_MESSAGE,
            method = MessagingTypes.INIT_DONE,
            payload = new Protocol.SceneReady()
        };
        Environment.i.world.sceneController.EnqueueSceneMessage(message);

        var cameraConfig = new CameraController.SetRotationPayload()
        {
            x = 0,
            y = 0,
            z = 0,
            cameraTarget = new UnityEngine.Vector3(0, 0, 1)
        };
        CommonScriptableObjects.cameraMode.Set(CameraMode.ModeId.FirstPerson);
        var cameraController = GameObject.Find("CameraController");
        cameraController.SendMessage("SetRotation", JsonUtility.ToJson(cameraConfig));

        GameObject camera = GameObject.Find("MainCamera");
        camera.GetComponent<Camera>().enabled = true;

        Environment.i.platform.updateEventHandler.AddListener(IUpdateEventHandler.EventType.Update, () => updateScript(scene.sceneNumber, componentWriter));
    }
}
