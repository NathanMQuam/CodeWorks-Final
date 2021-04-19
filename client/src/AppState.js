import { reactive } from 'vue'
import { Keep } from './models/KeepModel.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  keeps: [new Keep({ name: 'Keep 1', image: 'http://placehold.it/200x200' }), new Keep({ name: 'keep two', image: 'http://placehold.it/350x200' })],
  vaults: []
})
