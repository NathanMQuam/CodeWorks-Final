import { Profile } from './ProfileModel.js'

export class Keep {
  constructor(data = {}) {
    this.id = data.id || data._id || 0
    this.creatorId = data.creatorId || ''
    this.name = data.name || ''
    this.description = data.description || ''
    this.image = data.image || data.Img || data.img || ''
    this.img = data.image || data.Img || data.img || ''
    this.keeps = data.keeps || 0
    this.views = data.views || 0
    this.shares = data.shares || 0
    this.creator = new Profile(data.creator) || new Profile()
  }
}
