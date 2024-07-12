import * as codegen from '@mtvproject/rpc/dist/codegen'
import type { RpcServerPort } from '@mtvproject/rpc/dist/types'
import { TestingServiceDefinition } from 'shared/protocol/memetaverse/kernel/apis/testing.gen'
import type { PortContextService } from './context'

declare var __MTV_TESTING_EXTENSION__: any

export function registerTestingServiceServerImplementation(port: RpcServerPort<PortContextService<'logger'>>) {
  codegen.registerService(port, TestingServiceDefinition, async () => ({
    async logTestResult(result) {
      if (typeof __MTV_TESTING_EXTENSION__ !== 'undefined') return __MTV_TESTING_EXTENSION__.logTestResult(result)
      return {}
    },
    async plan(plan) {
      if (typeof __MTV_TESTING_EXTENSION__ !== 'undefined') return __MTV_TESTING_EXTENSION__.plan(plan)
      return {}
    },
    async setCameraTransform(transform) {
      if (typeof __MTV_TESTING_EXTENSION__ !== 'undefined') return __MTV_TESTING_EXTENSION__.setCameraTransform(transform)
      return {}
    },
    async takeAndCompareScreenshot(payload) {
      if (typeof __MTV_TESTING_EXTENSION__ !== 'undefined') return __MTV_TESTING_EXTENSION__.takeAndCompareScreenshot(payload)
        return {}
    }
  }))
}