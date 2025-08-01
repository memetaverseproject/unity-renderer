
// AUTOGENERATED, DO NOT EDIT
// Type definitions for server implementations of ports.
// package: memetaverse.renderer.kernel_services
// file: memetaverse/renderer/kernel_services/sign_request.proto
using Cysharp.Threading.Tasks;
using rpc_csharp;

namespace Memetaverse.Renderer.KernelServices {
public interface IClientSignRequestKernelService
{
  UniTask<SignBodyResponse> GetRequestSignature(SignBodyRequest request);

  UniTask<GetSignedHeadersResponse> GetSignedHeaders(GetSignedHeadersRequest request);
}

public class ClientSignRequestKernelService : IClientSignRequestKernelService
{
  private readonly RpcClientModule module;

  public ClientSignRequestKernelService(RpcClientModule module)
  {
      this.module = module;
  }

  
  public UniTask<SignBodyResponse> GetRequestSignature(SignBodyRequest request)
  {
      return module.CallUnaryProcedure<SignBodyResponse>("GetRequestSignature", request);
  }

  public UniTask<GetSignedHeadersResponse> GetSignedHeaders(GetSignedHeadersRequest request)
  {
      return module.CallUnaryProcedure<GetSignedHeadersResponse>("GetSignedHeaders", request);
  }

}
}
