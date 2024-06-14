const BODY_SHAPES = [
  'urn:memetaverse:off-chain:base-avatars:BaseFemale',
  'urn:memetaverse:off-chain:base-avatars:BaseMale',
  'urn:memetaverse:off-chain:base-avatars:BaseKidMonkey',
  'urn:memetaverse:off-chain:base-avatars:BaseMonkey'
]

export function isValidBodyShape(shape: string) {
  return BODY_SHAPES.includes(shape)
}
