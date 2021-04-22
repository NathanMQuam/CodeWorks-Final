import { logger } from '../utils/Logger.js'
import { api } from './AxiosService.js'

class VaultKeepsService {
  async AddKeepToVault(keepId, vaultId) {
    try {
      const newVaultKeep = { vaultId: vaultId, keepId: keepId }
      await api.post('api/vaultKeeps', newVaultKeep)
    } catch (err) {
      logger.error(err)
    }
  }

  async RemoveKeepFromVault(vaultKeepId) {
    try {
      await api.delete('api/vaultKeeps', vaultKeepId)
    } catch (err) {
      logger.error(err)
    }
  }
}

export const vaultKeepsService = new VaultKeepsService()
