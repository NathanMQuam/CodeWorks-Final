<template>
  <div class="home container">
    <KeepsList />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState.js'
import { vaultService } from '../services/VaultService.js'
export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      keepsService.GetAllKeeps()
      if (AppState.account.name) {
        vaultService.GetAccountVaults()
      }
    })
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    return {
      state
    }
  }
}
</script>

<style lang="scss">

</style>
