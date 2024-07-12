import { RpcServerPort } from '@mtvproject/rpc'
import { RendererProtocolContext } from '../context'
import * as codegen from '@mtvproject/rpc/dist/codegen'
import {
  FriendsKernelServiceDefinition,
  GetFriendshipStatusResponse
} from 'shared/protocol/memetaverse/renderer/kernel_services/friends_kernel.gen'
import { getFriendshipStatus } from 'shared/friends/sagas'

export function registerFriendsKernelService(port: RpcServerPort<RendererProtocolContext>) {
  codegen.registerService(port, FriendsKernelServiceDefinition, async () => ({
    async getFriendshipStatus(req, _) {
      const status = getFriendshipStatus(req)

      const response: GetFriendshipStatusResponse = {
        status
      }

      return response
    }
  }))
}
