<template>
  <div class="VaultComponent">
    <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}">
      vault
    </router-link>
  </div>
</template>

<script>
import { Vault } from '../models/VaultModel.js'
export default {
  name: 'VaultComponent',
  setup() {
    return {}
  },
  props: { vault: { type: Vault, default: () => new Vault() } },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
