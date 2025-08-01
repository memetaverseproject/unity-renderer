import { store } from 'shared/store/isolatedStore'
import { getRealmAdapter } from 'shared/realm/selectors'
import * as codegen from '@mtvproject/rpc/dist/codegen'
import type { RpcServerPort } from '@mtvproject/rpc/dist/types'
import type { GetRealmResponse, GetWorldTimeResponse } from 'shared/protocol/memetaverse/kernel/apis/runtime.gen'
import { RuntimeServiceDefinition } from 'shared/protocol/memetaverse/kernel/apis/runtime.gen'
import type { PortContextService } from './context'
import { getMemetaverseTime } from './EnvironmentAPI'
import { urlWithProtocol } from 'shared/realm/resolver'
import { PREVIEW, RENDERER_WS, getServerConfigurations } from 'config'
import { getSelectedNetwork } from 'shared/dao/selectors'
import { Platform } from '../IEnvironmentAPI'

export function registerRuntimeServiceServerImplementation(port: RpcServerPort<PortContextService<'sceneData'>>) {
  codegen.registerService(port, RuntimeServiceDefinition, async () => ({
    async getExplorerInformation() {
      const questsServerUrl = getServerConfigurations(getSelectedNetwork(store.getState())).questsUrl
      const platform = RENDERER_WS ? Platform.DESKTOP : Platform.BROWSER

      return {
        agent: 'explorer-kernel',
        platform,
        configurations: { questsServerUrl }
      }
    },
    
    async getWorldTime(): Promise<GetWorldTimeResponse> {
      const time = getMemetaverseTime()

      return { seconds: time }
    },
    async getRealm(): Promise<GetRealmResponse> {
      const realmAdapter = getRealmAdapter(store.getState())

      if (!realmAdapter) {
        return {}
      }
      const baseUrl = urlWithProtocol(new URL(realmAdapter.baseUrl).hostname)

      return {
        realmInfo: {
          baseUrl,
          realmName: realmAdapter.about.configurations?.realmName ?? '',
          networkId: realmAdapter.about.configurations?.networkId ?? 1,
          commsAdapter: realmAdapter.about.comms?.adapter ?? '',
          isPreview: PREVIEW
        }
      }
    },
    async getSceneInformation(_, ctx) {
      return {
        urn: ctx.sceneData.id,
        baseUrl: ctx.sceneData.baseUrl,
        content: ctx.sceneData.entity.content,
        metadataJson: JSON.stringify(ctx.sceneData.entity.metadata)
      }
    },
    async readFile(req, ctx) {
      return ctx.readFile(req.fileName)
    }
  }))
}
