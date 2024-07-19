import { executeTask } from '@mtvproject/legacy-ecs'
import { avatarMap, avatarMessageObservable } from './avatar/avatarSystem'

declare const mtv: MemetaverseInterface

// Initialize avatar profile scene

void executeTask(async () => {
  console.log("dasdasdas")
  const [_, socialController] = await Promise.all([
    mtv.loadModule('@memetaverse/Identity', {}),
    mtv.loadModule('@memetaverse/SocialController', {})
  ])
  
  mtv.onUpdate(async (_dt: any) => {
    const ret: { events: { event: string; payload: string }[] } = await mtv.callRpc(
      socialController.rpcHandle,
      'pullAvatarEvents',
      []
    )

    let lastProcessed = ''
    for (const { payload } of ret.events) {
      if (payload !== lastProcessed) {
        try {
          lastProcessed = payload
          const msg = JSON.parse(payload)
          const invisible = avatarMap.get(msg.userId)?.visible === false && msg.visible === false

          if (!invisible) avatarMessageObservable.emit('message', msg)
        } catch (err) {
          console.error(err)
        }
      }
    }
  })
})
