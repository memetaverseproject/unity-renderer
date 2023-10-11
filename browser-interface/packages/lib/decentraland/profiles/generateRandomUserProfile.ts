import type { Avatar } from '@beland/schemas'

const bodyShapeWearables = [
  {
    bodyShape: 'urn:memetaverse:off-chain:base-avatars:BaseFemale',
    wearables: [
      // 'urn:memetaverse:off-chain:base-avatars:eyes_00',
      // 'urn:memetaverse:off-chain:base-avatars:eyebrows_00',
      // 'urn:memetaverse:off-chain:base-avatars:mouth_00',
      // 'urn:memetaverse:off-chain:base-avatars:hair_left_over',
      // 'urn:memetaverse:off-chain:base-avatars:beard',
      // 'urn:memetaverse:off-chain:base-avatars:brown_jacket',
      // 'urn:memetaverse:off-chain:base-avatars:red_short',
      // 'urn:memetaverse:off-chain:base-avatars:red_sandals'
    ]
  },
  {
    bodyShape: 'urn:memetaverse:off-chain:base-avatars:BaseMale',
    wearables: [
      // 'urn:memetaverse:off-chain:base-avatars:f_eyes_00',
      // 'urn:memetaverse:off-chain:base-avatars:f_eyebrows_00',
      // 'urn:memetaverse:off-chain:base-avatars:f_mouth_00',
      // 'urn:memetaverse:off-chain:base-avatars:standard_hair',
      // 'urn:memetaverse:off-chain:base-avatars:light_green_jennie_short_dress',
      // 'urn:memetaverse:off-chain:base-avatars:purple_pants',
      // 'urn:memetaverse:off-chain:base-avatars:black_while_shoes'
    ]
  }
]

const skins = [
  {
    color: {
      r: 0.4901960790157318,
      g: 0.364705890417099,
      b: 0.27843138575553894
    }
  },
  {
    color: {
      r: 0.800000011920929,
      g: 0.6078431606292725,
      b: 0.46666666865348816
    }
  }
]

const hairs = [
  {
    color: {
      r: 0.5960784554481506,
      g: 0.37254902720451355,
      b: 0.21568627655506134
    }
  },
  {
    color: {
      r: 0.23529411852359772,
      g: 0.12941177189350128,
      b: 0.04313725605607033
    }
  }
]

const eyes = [
  {
    color: {
      r: 0.37254902720451355,
      g: 0.2235294133424759,
      b: 0.19607843458652496
    }
  },
  {
    color: {
      r: 0.125490203499794,
      g: 0.7019608020782471,
      b: 0.9647058844566345
    }
  }
]

const snapshots = [
  {
    face256: `QmZbyGxDnZ4PaMVX7kpA2NuGTrmnpwTJ8heKKTSCk4GRJL`,
    body: `QmaQvcBWg57Eqf5E9R3Ts1ttPKKLhKueqdyhshaLS1tu2g`
  }
]

function getRandomItem<T>(items: T[]): T {
  return items[Math.floor(Math.random() * items.length)]
}

export function generateRandomUserProfile(userId: string): Avatar {
  const randomSkin = getRandomItem(skins)
  const randomHair = getRandomItem(hairs)
  const randomEyes = getRandomItem(eyes)
  const randomBodyShapeWearables = getRandomItem(bodyShapeWearables)

  return {
    userId,
    email: '',
    version: -1,
    hasClaimedName: false,
    ethAddress: '0x0000000000000000000000000000000000000000',
    tutorialStep: 0,
    name: 'Guest',
    description: '',
    avatar: {
      bodyShape: randomBodyShapeWearables.bodyShape,
      skin: randomSkin,
      hair: randomHair,
      eyes: randomEyes,
      wearables: randomBodyShapeWearables.wearables,
      snapshots: snapshots[0]
    }
  }
}
