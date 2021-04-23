<template>
  <div class="CreateVaultComponent">
    <div class="cursor-pointer p-2" data-target="#createVaultModal" data-toggle="modal">
      <i class="fa fa-plus" aria-hidden="true"></i>
    </div>

    <div class="modal fade"
         id="createVaultModal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="createVaultModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-lg" role="document">
        <form class="modal-content" @submit.prevent="createVault()">
          <div class="modal-header">
            <h5 class="modal-title" id="createVaultModalLabel">
              New Vault
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="form-group">
              <label>Vault Title</label>
              <input v-model="state.newVault.name" type="text" class="form-control" placeholder="Vault Title">
            </div>
            <div class="form-group">
              <label>Vault Description</label>
              <textarea v-model="state.newVault.description" class="w-100" rows="5" placeholder="Vault description..."></textarea>
            </div>
            <div class="form-group form-check">
              <input v-model="state.newVault.isPrivate" type="checkbox" class="form-check-input" id="exampleCheck1">
              <label class="form-check-label" for="exampleCheck1">Make vault private?</label>
              <small class="form-text text-muted">Private vaults can only be seen by you</small>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">
              Cancel
            </button>
            <button type="submit" class="btn btn-primary">
              Create
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { Vault } from '../models/VaultModel.js'
import { vaultService } from '../services/VaultService.js'
export default {
  name: 'CreateVaultComponent',
  setup() {
    const state = reactive({
      newVault: computed(() => new Vault())
    })
    async function createVault() {
      console.log('Attempting to create vault:', state.newVault)
      await vaultService.CreateVault(state.newVault)
      state.newVault = computed(() => new Vault())
      vaultService.GetAccountVaults()
    }
    return { state, createVault }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
