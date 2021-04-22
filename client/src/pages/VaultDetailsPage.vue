<template>
  <div class="VaultDetailsPage container">
    <div class="row">
      <div class="col d-flex justify-content-left">
        <h2 class="my-auto">
          {{ state.activeVault.name }}
        </h2>
        <div class="cursor-pointer p-3" @click="deleteVault()" v-if="state.activeVault.creatorId === state.account.id">
          <i class="fa fa-lg fa-trash-o" aria-hidden="true"></i>
        </div>
      </div>
    </div>
    <KeepsList />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { vaultService } from '../services/VaultService'
import { useRoute, useRouter } from 'vue-router'
import { Vault } from '../models/VaultModel.js'
export default {
  name: 'VaultDetailsPage',
  setup() {
    const route = useRoute()
    const router = useRouter()
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account)
    })
    onMounted(() => {
      AppState.activeVault = new Vault()
      vaultService.GetVaultById(route.params.vaultId)
      vaultService.GetKeepsByVaultId(route.params.vaultId)
    })
    function deleteVault() {
      console.log('Attempting to delete vault:', state.activeVault.id)
      vaultService.DeleteVault(state.activeVault.id)
      AppState.activeVault = new Vault()
      router.back()
    }
    return {
      state,
      deleteVault
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
