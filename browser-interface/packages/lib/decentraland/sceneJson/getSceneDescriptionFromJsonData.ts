import { Scene } from '@beland/schemas'

export function getSceneDescriptionFromJsonData(jsonData?: Scene) {
  return jsonData?.display?.description || ''
}
