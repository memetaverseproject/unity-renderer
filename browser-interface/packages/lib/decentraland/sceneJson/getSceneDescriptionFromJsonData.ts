import { Scene } from '@mtvproject/schemas'

export function getSceneDescriptionFromJsonData(jsonData?: Scene) {
  return jsonData?.display?.description || ''
}
