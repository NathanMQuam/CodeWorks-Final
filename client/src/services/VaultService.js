import { logger } from '../utils/Logger'

class VaultService {
  async GetAllVaults() {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }

  async GetVaultById(id) {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }

  async CreateVault() {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }

  async EditVault(UpdatedVault) {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }

  async DeleteVault(id) {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }

  async GetKeepsByVaultId(id) {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }
}

export const vaultService = new VaultService()
