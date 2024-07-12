import { executeTask } from '@mtvproject/ecs'
import { avatarMessageObservable } from './avatar/avatarSystem'

declare const mtv: MemetaverseInterface

// Initialize avatar profile scene

void executeTask(async () => {
  const [_, socialController] = await Promise.all([
    mtv.loadModule('@memetaverse/Identity', {}),
    mtv.loadModule('@memetaverse/SocialController', {})
  ])

  mtv.onUpdate(async (_dt) => {
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
          avatarMessageObservable.emit('message', JSON.parse(payload))
        } catch (err) {
          console.error(err)
        }
      }
    }
  })
})
