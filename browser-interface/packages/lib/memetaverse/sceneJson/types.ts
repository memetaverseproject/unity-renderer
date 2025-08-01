import { Scene } from '@mtvproject/schemas'

type FeatureToggles = NonNullable<Scene['featureToggles']>

export type SceneFeatureToggle = {
  [K in keyof FeatureToggles]: {
    name: K
    default: FeatureToggles[K]
  }
}[keyof FeatureToggles]
