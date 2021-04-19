export class Profile {
  constructor(data = {}) {
    this.id = data.id || ''
    this.name = data.name || ''
    this.email = data.email || ''
    this.picture = data.picture || 'http://placehold.it/200x200'
  }
}
