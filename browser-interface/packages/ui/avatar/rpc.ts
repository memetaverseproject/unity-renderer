import { executeTask } from '@mtvproject/ecs'

declare let mtv: MemetaverseInterface

export async function execute(controller: string, method: string, args: Array<any>) {
  return executeTask(async () => {
    return mtv.callRpc(controller, method, args)
  })
}
