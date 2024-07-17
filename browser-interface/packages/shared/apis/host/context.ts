import type { ILogger } from 'lib/logger'
import type { LoadableScene } from 'shared/types'
import type { PermissionItem } from 'shared/protocol/memetaverse/kernel/apis/permissions.gen'
import type { EventData } from 'shared/protocol/memetaverse/kernel/apis/engine_api.gen'
import type { RpcClientPort } from '@mtvproject/rpc'
import type { RpcSceneControllerServiceDefinition } from 'shared/protocol/memetaverse/renderer/renderer_services/scene_controller.gen'
import type { RpcClientModule } from '@mtvproject/rpc/dist/codegen'
import { EntityAction } from 'shared/protocol/memetaverse/sdk/ecs6/engine_interface_ecs6.gen'
import { Sourcemap } from 'shared/world/runtime-7/sourcemap/types'
import { IInternalEngine } from 'shared/world/runtime-7/engine'

type WithRequired<T, K extends keyof T> = T & { [P in K]-?: T[P] }

export type PortContextService<K extends keyof PortContext> = WithRequired<PortContext, K>

export type PortContext = {
  sdk7: boolean
  permissionGranted: Set<PermissionItem>
  sceneData: LoadableScene & {
    readonly sceneNumber: number
  }
  subscribedEvents: Set<string>
  events: EventData[]

  // @deprecated
  sendBatch(actions: EntityAction[]): void
  sendSceneEvent<K extends keyof IEvents>(id: K, event: IEvents[K]): void
  sendProtoSceneEvent(event: EventData): void
  logger: ILogger

  // port used for this specific scene in the renderer
  scenePort: RpcClientPort
  rpcSceneControllerService: RpcClientModule<RpcSceneControllerServiceDefinition, unknown>

  initialEntitiesTick0: Uint8Array
  hasMainCrdt: boolean

  readFile(path: string): Promise<{ content: Uint8Array; hash: string }>

   // Internal engine used to store the user avatar's info
  internalEngine: IInternalEngine | undefined

   // Parse sdk7 errors.
  sourcemap: Sourcemap | undefined
}
