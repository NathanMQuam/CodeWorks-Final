import { Profile } from './ProfileModel.js'

export class Keep {
  constructor(data = {}) {
    this.id = data.id || data._id || 'placeholder id'
    this.creatorId = data.creatorId || ''
    this.name = data.name || ''
    this.description = data.description || ''
    this.image = data.image || 'http://placehold.it/200x200'
    this.keeps = data.keeps || 0
    this.views = data.views || 0
    this.shares = data.shares || 0
    this.creator = new Profile(data.creator) || new Profile()
  }
}
