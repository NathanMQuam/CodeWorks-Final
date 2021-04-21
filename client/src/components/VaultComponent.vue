<template>
  <div class="VaultComponent">
    vault
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
