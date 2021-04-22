<template>
  <router-link class="VaultComponent col-2" :to="{name: 'Vault', params: {vaultId: vault.id}}">
    <div class="m-2 p-2 card w-100 bg-dark text-white shadow cursor-pointer">
      <div>
        {{ vault.name }}
      </div>
    </div>
  </router-link>
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
