import { RpcServerPort } from '@mtvproject/rpc'
import { RendererProtocolContext } from '../context'
import * as codegen from '@mtvproject/rpc/dist/codegen'
import { EmotesKernelServiceDefinition } from 'shared/protocol/memetaverse/renderer/kernel_services/emotes_kernel.gen'
import { allScenesEvent } from 'shared/world/parcelSceneManager'
import { sendPublicChatMessage } from 'shared/comms'
import { localProfileChanged } from '../../../shared/world/runtime-7/engine'

export function registerEmotesKernelService(port: RpcServerPort<RendererProtocolContext>) {
  codegen.registerService(port, EmotesKernelServiceDefinition, async () => ({
    async triggerExpression(req, _) {
      if (!req.id) return {}

      localProfileChanged.emit('triggerEmote', { emoteUrn: req.id, timestamp: req.timestamp })

      allScenesEvent({
        eventType: 'playerExpression',
        payload: {
          expressionId: req.id
        }
      })

      const body = `␐${req.id} ${req.timestamp}`

      sendPublicChatMessage(body)
      return {}
    }
  }))
}
