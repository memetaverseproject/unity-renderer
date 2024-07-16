import type {
  AvatarMessage,
} from 'shared/comms/interface/types'
import mitt from 'mitt'
export const avatarMessageObservable = mitt<{ message: AvatarMessage }>()


avatarMessageObservable.on('message', (evt) => {
  // if (evt.type === 'USER_DATA') {
  //   handleUserData(evt)
  // } else if (evt.type === 'USER_VISIBLE') {
  //   handleUserVisible(evt)
  // } else if (evt.type === 'USER_EXPRESSION') {
  //   handleUserExpression(evt)
  // } else if (evt.type === 'USER_REMOVED') {
  //   handleUserRemoved(evt)
  // } else if (evt.type === 'USER_TALKING') {
  //   handleUserTalkingUpdate(evt as ReceiveUserTalkingMessage)
  // }
})
