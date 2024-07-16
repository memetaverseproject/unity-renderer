import { RpcClientPort } from '@mtvproject/rpc'
import * as codegen from '@mtvproject/rpc/dist/codegen'
import { RestrictedActionsServiceDefinition } from 'shared/protocol/memetaverse/renderer/renderer_services/restricted_actions.gen'
import defaultLogger from 'lib/logger'

// eslint-disable-next-line @typescript-eslint/ban-types
export function registerRestrictedActionsService<Context extends {}>(
  clientPort: RpcClientPort
): codegen.RpcClientModule<RestrictedActionsServiceDefinition, Context> | undefined {
  try {
    return codegen.loadService<Context, RestrictedActionsServiceDefinition>(
      clientPort,
      RestrictedActionsServiceDefinition
    )
  } catch (e) {
    defaultLogger.error('EmotesService could not be loaded')
    return undefined
  }
}
