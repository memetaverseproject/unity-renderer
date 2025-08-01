import type { Snapshots, WearableCategory, WearableId } from '@mtvproject/schemas'

export type AvatarForUserData = {
  bodyShape: WearableId
  skinColor: string
  hairColor: string
  eyeColor: string
  wearables: WearableId[]
  forceRender?: WearableCategory[]
  emotes?: {
    slot: number
    urn: string
  }[]
  snapshots: Snapshots
}
