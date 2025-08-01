/**
 * @deprecated: use `getExplorerVersion`
 */
export function injectVersions<T extends Record<string, any>>(versions: T): T & Record<string, string> {
  const rolloutsInfo = (globalThis as any).ROLLOUTS || {}

  for (const component in rolloutsInfo) {
    if (component === '_site' || component.startsWith('@mtvproject')) {
      if (rolloutsInfo[component] && rolloutsInfo[component].version) {
        versions[component as keyof T] = rolloutsInfo[component].version
      }
    }
  }

  return versions
}

/**
 * @deprecated: use `getExplorerVersion`
 */
export function getUsedComponentVersions() {
  const versions = injectVersions({})
  const explorerVersion = versions['@mtvproject/explorer'] || 'unknown'
  return { explorerVersion }
}

/**
 * Returns the build version
 */
export function getExplorerVersion() {
  return ((globalThis as any).ROLLOUTS || {})['@mtvproject/explorer']?.version || 'unknown'
}
