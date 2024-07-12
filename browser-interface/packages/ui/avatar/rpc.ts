import { executeTask } from '@mtvproject/ecs'

declare let dcl: MemetaverseInterface

export async function execute(controller: string, method: string, args: Array<any>) {
  return executeTask(async () => {
    return dcl.callRpc(controller, method, args)
  })
}
