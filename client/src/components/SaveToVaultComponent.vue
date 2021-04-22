<template>
  <div class="SaveToVaultComponent" v-if="state.vaults">
    <div v-for="v in state.vaults" :key="v.id">
      <div class="text-dark" @click="saveToVault(v.id)" data-dismiss="modal">
        {{ v.name }}
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { vaultService } from '../services/VaultService.js'
import { AppState } from '../AppState.js'
import { vaultKeepsService } from '../services/VaultKeepsService.js'
import { useRouter } from 'vue-router'
export default {
  name: 'SaveToVaultComponent',
  props: {
    keep: { type: Number, default: null }
  },
  setup(props) {
    const router = useRouter()
    const state = reactive({
      vaults: computed(() => AppState.vaults)
    })
    onMounted(() => {
      vaultService.GetAccountVaults()
    })
    function saveToVault(id) {
      console.log('Attempting to save keep to vault\n', props.keep, id)
      vaultKeepsService.AddKeepToVault(props.keep, id)
      router.push({ name: 'Vault', params: { vaultId: id } })
    }
    return { state, saveToVault }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
