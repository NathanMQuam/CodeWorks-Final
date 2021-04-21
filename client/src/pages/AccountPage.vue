<template>
  <div class="Account container">
    <div class="row py-4">
      <div class="col-2">
        <img class="rounded img-fluid w-100" :src="state.account.picture" />
      </div>
      <div class="col-9">
        <div>
          <h1>{{ state.account.name }}</h1>
        </div>
        <div>
          <h4>Vaults: {{ state.myVaults }}</h4>
          <h4>Keeps: {{ state.myKeeps }}</h4>
        </div>
      </div>
    </div>
    <h3>Vaults</h3>
    <VaultsList />
    <h3>Keeps</h3>
    <KeepsList />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService.js'
import { vaultService } from '../services/VaultService.js'
export default {
  name: 'Account',
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      myKeeps: computed(() => AppState.keeps.length),
      myVaults: computed(() => AppState.vaults.length)
    })
    onMounted(() => {
      keepsService.GetAccountKeeps()
      vaultService.GetAccountVaults()
    })
    return {
      state
    }
  }
}
</script>

<style scoped>
</style>
