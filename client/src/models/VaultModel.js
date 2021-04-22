export class Vault {
  constructor(data = {}) {
    this.id = data.id || 0
    this.creatorId = data.creatorId || ''
    this.name = data.name || ''
    this.description = data.description || ''
    this.isPrivate = data.isPrivate || false
  }
}
