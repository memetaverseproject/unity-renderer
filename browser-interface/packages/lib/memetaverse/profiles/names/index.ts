import { BAD_WORDS } from 'lib/memetaverse/badwords'

export const nameValidCharacterRegex = /[a-zA-Z0-9]/g

export const nameValidRegex = /^[a-zA-Z0-9]+$/

export function filterInvalidNameCharacters(name: string) {
  return name.match(nameValidCharacterRegex)?.join('') ?? ''
}

export function isBadWord(word: string) {
  return BAD_WORDS.includes(word.toLowerCase())
}
