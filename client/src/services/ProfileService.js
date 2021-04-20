import { AppState } from '../AppState.js'
import { Keep } from '../models/KeepModel.js'
import { Vault } from '../models/VaultModel'
import { Profile } from '../models/ProfileModel.js'
import { logger } from '../utils/Logger.js'
import { api } from './AxiosService.js'

class ProfileService {
  async GetProfileById(id) {
    try {
      const res = await api.get('api/profiles/' + id)
      AppState.activeProfile = new Profile(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async GetUsersKeeps(id) {
    try {
      const res = await api.get(`api/profiles/${id}/keeps`)
      AppState.keeps = res.data.map(k => new Keep(k))
    } catch (err) {
      logger.error(err)
    }
  }

  async GetUsersVaults(id) {
    try {
      const res = await api.get(`api/profiles/${id}/vaults`)
      AppState.vaults = res.data.map(v => new Vault(v))
    } catch (err) {
      logger.error(err)
    }
  }
}

export const profileService = new ProfileService()
