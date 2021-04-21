import { reactive } from 'vue'
import { Keep } from './models/KeepModel.js'
import { Profile } from './models/ProfileModel.js'
import { Vault } from './models/VaultModel.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  keeps: [],
  vaults: [],
  activeKeep: new Keep(),
  activeVault: new Vault(),
  activeProfile: new Profile()
})
