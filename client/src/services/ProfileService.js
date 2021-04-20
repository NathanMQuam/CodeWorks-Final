import { logger } from '../utils/Logger.js'

class ProfileService {
  async GetProfileById(id) {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }

  async GetUsersKeeps(id) {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }

  async GetUsersVaults(id) {
    try {
      // TODO
    } catch (err) {
      logger.error(err)
    }
  }
}

export const profileService = new ProfileService()
