import { AppState } from '../AppState.js'
import { Keep } from '../models/KeepModel.js'
import { logger } from '../utils/Logger.js'
import { api } from './AxiosService.js'

class KeepsService {
  async GetAllKeeps() {
    try {
      const res = await api.get('api/keeps')
      // logger.log(res)
      AppState.keeps = res.data.map(k => new Keep(k))
      // logger.log(AppState.keeps)
    } catch (err) {
      logger.error(err)
    }
  }

  async GetKeepById(id) {
    try {
      const res = await api.get('api/keeps/' + id)
      AppState.activeKeep = new Keep(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async GetAccountKeeps() {
    try {
      const res = await api.get('account/keeps')
      AppState.keeps = res.data.map(k => new Keep(k))
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

  async CreateKeep(newKeep) {
    try {
      const res = await api.post('api/keeps', new Keep(newKeep))
      logger.log(res)
      AppState.activeKeep = new Keep(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async EditKeep(keep) {
    try {
      const res = await api.put('api/keeps/' + keep.id, new Keep(keep))
      logger.log(res)
      AppState.activeKeep = new Keep(res.data)
    } catch (err) {
      logger.error(err)
    }
  }

  async DeleteKeep(id) {
    try {
      await api.delete('api/keeps/' + id)
      logger.log('KEEP DELETED:', id)
    } catch (err) {
      logger.error(err)
    }
  }
}

export const keepsService = new KeepsService()
