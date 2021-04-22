<template>
  <div class="VaultsList row">
    <VaultComponent v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState.js'
export default {
  name: 'VaultsList',
  setup() {
    const state = reactive({
      vaults: computed(() => AppState.vaults)
    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
