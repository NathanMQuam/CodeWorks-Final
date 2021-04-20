<template>
  <div class="VaultDetailsPage container">
    <div class="row">
      <div class="col text-center">
        {{ state.activeVault.name }}
      </div>
    </div>
    <div class="row">
      <div class="col-3" v-for="keep in state.keeps" :key="keep.id">
        <div class="card">
          {{ keep.name }}
          <img :src="keep.image">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { vaultService } from '../services/VaultService'
import { useRoute } from 'vue-router'
export default {
  name: 'VaultDetailsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps)
    })
    onMounted(() => {
      vaultService.GetVaultById(route.params.vaultId)
      vaultService.GetKeepsByVaultId(route.params.vaultId)
    })
    return {
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
