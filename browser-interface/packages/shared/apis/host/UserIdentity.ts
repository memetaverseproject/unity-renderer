import { calculateDisplayName } from 'lib/memetaverse/profiles/transformations/processServerProfile'

import { sceneRuntimeCompatibleAvatar } from 'lib/memetaverse/profiles/sceneRuntime'
import { retrieveProfile } from 'shared/profiles/retrieveProfile'
import { onLoginCompleted } from 'shared/session/onLoginCompleted'

import { UserIdentityServiceDefinition } from 'shared/protocol/memetaverse/kernel/apis/user_identity.gen'
import type { RpcServerPort } from '@mtvproject/rpc'
import * as codegen from '@mtvproject/rpc/dist/codegen'
import type { PortContext } from './context'

export function registerUserIdentityServiceServerImplementation(port: RpcServerPort<PortContext>) {
  codegen.registerService(port, UserIdentityServiceDefinition, async () => ({
    async getUserPublicKey() {
      const { identity } = await onLoginCompleted()
      if (!identity || !identity.address) {
        debugger
      }
      if (identity && identity.hasConnectedWeb3) {
        return { address: identity.address }
      } else {
        return {}
      }
    },
    async getUserData() {
      const { identity } = await onLoginCompleted()

      if (!identity || !identity.address) {
        debugger
        return {}
      }

      const profile = await retrieveProfile(identity.address)

      return {
        data: {
          displayName: calculateDisplayName(profile),
          publicKey: identity.hasConnectedWeb3 ? identity.address : undefined,
          hasConnectedWeb3: !!identity.hasConnectedWeb3,
          userId: identity.address,
          version: profile.version,
          avatar: sceneRuntimeCompatibleAvatar(profile.avatar)
        }
      }
    }
  }))
}
