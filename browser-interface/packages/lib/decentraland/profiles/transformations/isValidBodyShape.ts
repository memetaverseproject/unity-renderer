const BODY_SHAPES = [
  'dcl://base-avatars/BaseFemale',
  'dcl://base-avatars/BaseMale',
  'urn:memetaverse:off-chain:base-avatars:BaseFemale',
  'urn:memetaverse:off-chain:base-avatars:BaseMale'
]

export function isValidBodyShape(shape: string) {
  return BODY_SHAPES.includes(shape)
}
