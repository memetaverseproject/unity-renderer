// AUTOGENERATED, DO NOT EDIT
// Type definitions for server implementations of ports.
// package: memetaverse.renderer.kernel_services
// file: memetaverse/renderer/kernel_services/friends_kernel.proto
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Google.Protobuf;
using rpc_csharp.protocol;
using rpc_csharp;
namespace Memetaverse.Renderer.KernelServices {
public interface IFriendsKernelService<Context>
{

  UniTask<GetFriendshipStatusResponse> GetFriendshipStatus(GetFriendshipStatusRequest request, Context context, CancellationToken ct);

}

public static class FriendsKernelServiceCodeGen
{
  public const string ServiceName = "FriendsKernelService";

  public static void RegisterService<Context>(RpcServerPort<Context> port, IFriendsKernelService<Context> service)
  {
    var result = new ServerModuleDefinition<Context>();
      
    result.definition.Add("GetFriendshipStatus", async (payload, context, ct) => { var res = await service.GetFriendshipStatus(GetFriendshipStatusRequest.Parser.ParseFrom(payload), context, ct); return res?.ToByteString(); });

    port.RegisterModule(ServiceName, (port) => UniTask.FromResult(result));
  }
}
}
