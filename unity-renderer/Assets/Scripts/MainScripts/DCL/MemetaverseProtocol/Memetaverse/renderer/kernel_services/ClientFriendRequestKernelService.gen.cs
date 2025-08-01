
// AUTOGENERATED, DO NOT EDIT
// Type definitions for server implementations of ports.
// package: memetaverse.renderer.kernel_services
// file: memetaverse/renderer/kernel_services/friend_request_kernel.proto
using Cysharp.Threading.Tasks;
using rpc_csharp;

namespace Memetaverse.Renderer.KernelServices {
public interface IClientFriendRequestKernelService
{
  UniTask<GetFriendRequestsReply> GetFriendRequests(GetFriendRequestsPayload request);

  UniTask<SendFriendRequestReply> SendFriendRequest(SendFriendRequestPayload request);

  UniTask<CancelFriendRequestReply> CancelFriendRequest(CancelFriendRequestPayload request);

  UniTask<AcceptFriendRequestReply> AcceptFriendRequest(AcceptFriendRequestPayload request);

  UniTask<RejectFriendRequestReply> RejectFriendRequest(RejectFriendRequestPayload request);
}

public class ClientFriendRequestKernelService : IClientFriendRequestKernelService
{
  private readonly RpcClientModule module;

  public ClientFriendRequestKernelService(RpcClientModule module)
  {
      this.module = module;
  }

  
  public UniTask<GetFriendRequestsReply> GetFriendRequests(GetFriendRequestsPayload request)
  {
      return module.CallUnaryProcedure<GetFriendRequestsReply>("GetFriendRequests", request);
  }

  public UniTask<SendFriendRequestReply> SendFriendRequest(SendFriendRequestPayload request)
  {
      return module.CallUnaryProcedure<SendFriendRequestReply>("SendFriendRequest", request);
  }

  public UniTask<CancelFriendRequestReply> CancelFriendRequest(CancelFriendRequestPayload request)
  {
      return module.CallUnaryProcedure<CancelFriendRequestReply>("CancelFriendRequest", request);
  }

  public UniTask<AcceptFriendRequestReply> AcceptFriendRequest(AcceptFriendRequestPayload request)
  {
      return module.CallUnaryProcedure<AcceptFriendRequestReply>("AcceptFriendRequest", request);
  }

  public UniTask<RejectFriendRequestReply> RejectFriendRequest(RejectFriendRequestPayload request)
  {
      return module.CallUnaryProcedure<RejectFriendRequestReply>("RejectFriendRequest", request);
  }

}
}
