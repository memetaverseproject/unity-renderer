
// AUTOGENERATED, DO NOT EDIT
// Type definitions for server implementations of ports.
// package: memetaverse.renderer.renderer_services
// file: memetaverse/renderer/renderer_services/crdt.proto
using Cysharp.Threading.Tasks;
using rpc_csharp;

namespace Memetaverse.Renderer.RendererServices {
public interface IClientCRDTService
{
  UniTask<CRDTResponse> SendCrdt(CRDTManyMessages request);

  UniTask<CRDTManyMessages> PullCrdt(PullCRDTRequest request);
}

public class ClientCRDTService : IClientCRDTService
{
  private readonly RpcClientModule module;

  public ClientCRDTService(RpcClientModule module)
  {
      this.module = module;
  }

  
  public UniTask<CRDTResponse> SendCrdt(CRDTManyMessages request)
  {
      return module.CallUnaryProcedure<CRDTResponse>("SendCrdt", request);
  }

  public UniTask<CRDTManyMessages> PullCrdt(PullCRDTRequest request)
  {
      return module.CallUnaryProcedure<CRDTManyMessages>("PullCrdt", request);
  }

}
}
