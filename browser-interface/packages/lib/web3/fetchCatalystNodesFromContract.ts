
import { requestManager } from './provider'

export type CatalystNode = {
  domain: string
}

/**
 * The HARDCODED_CATALYST_LIST exists because this function was taking ~8s fetching all the data from the contract (at
 * least through metamask)
 */

export async function fetchCatalystNodesFromContract(): Promise<CatalystNode[]> {
  if (!requestManager.provider) {
    throw new Error('requestManager.provider not set')
  }

  return [{ domain: 'https://testnet-peer.memetaverse.club' }]
}
