import { AppState } from '../AppState.js'
import { Keep } from '../models/KeepModel.js'
import { Vault } from '../models/VaultModel.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService.js'

class VaultService {
  async GetAllVaults() {
    try {
      const res = await api.get('api/vaults')
      AppState.vaults = res.data.map(v => new Vault(v))
    } catch (err) {
      logger.error(err)
    }
  }

  async GetVaultById(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      AppState.activeVault = new Vault(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async CreateVault(newVault) {
    try {
      const res = await api.post('api/vaults', newVault)
      AppState.activeVault = new Vault(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async EditVault(UpdatedVault) {
    try {
      const res = await api.put('api/vaults', UpdatedVault)
      AppState.activeVault = new Vault(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async DeleteVault(id) {
    try {
      await api.delete('api/vaults/' + id)
    } catch (err) {
      logger.error(err)
    }
  }

  async GetKeepsByVaultId(id) {
    try {
      const res = await api.get(`api/vaults/${id}/keeps`)
      // logger.log(res.data)
      AppState.keeps = res.data.map(k => new Keep(k))
      // logger.log(AppState.keeps)
    } catch (err) {
      logger.error(err)
    }
  }
}

export const vaultService = new VaultService()
