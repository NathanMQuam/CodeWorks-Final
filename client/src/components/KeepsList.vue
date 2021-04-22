<template>
  <div class="KeepsList row">
    <div class="card-columns">
      <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
    </div>
  </div>

  <!-- Modal -->
  <div class="modal fade"
       id="keepDetailsModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="keepDetailsModalTitle"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="keepDetailsModalTitle">
            {{ AppState.activeKeep.name }}
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <div class="d-flex h-100">
            <div class="w-50 h-100">
              <img :src="AppState.activeKeep.image" class="mw-100 w-100">
            </div>
            <div class="w-50 container h-100 flex-grow">
              <div class="row">
                <div class="col-6 offset-3 d-flex justify-content-around">
                  <div>
                    <i class="fa fa-eye" aria-hidden="true"></i>
                    {{ AppState.activeKeep.views }}
                  </div>
                  <div>
                    <i class="fa fa-floppy-o" aria-hidden="true"></i>
                    {{ AppState.activeKeep.keeps }}
                  </div>
                  <div>
                    <i class="fa fa-share" aria-hidden="true"></i>
                    {{ AppState.activeKeep.shares }}
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col">
                  <h2>{{ AppState.activeKeep.name }}</h2>
                </div>
              </div>
              <div class="row">
                <div class="col">
                  {{ AppState.activeKeep.description }}
                </div>
              </div>
              <div class="row mt-auto">
                <div class="col">
                  <div v-if="!state.saveMode" class="d-flex">
                    <button type="button" class="btn btn-primary" @click="toggleSaveMode(true)">
                      Save to Vault
                    </button>
                    <button type="button"
                            class="btn btn-secondary"
                            data-dismiss="modal"
                            aria-label="Close"
                            @click="deleteKeep()"
                            v-if="AppState.account.id === AppState.activeKeep.creatorId"
                    >
                      Delete
                    </button>
                    {{ AppState.activeKeep.creator.name }}
                  </div>
                  <div class="row mh-100" v-else>
                    <div class="col">
                      <button class="btn btn-secondary" @click="toggleSaveMode(false)">
                        Cancel
                      </button>
                      <SaveToVaultComponent :keep="AppState.activeKeep.id" />
                    </div>
                    <!-- <VaultsList class="w-100" :dropdownlist="true" /> -->
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { keepsService } from '../services/KeepsService.js'
import { Keep } from '../models/KeepModel.js'
import { useRoute } from 'vue-router'
export default {
  name: 'KeepsList',
  setup() {
    const route = useRoute()
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      saveMode: false
    })
    async function deleteKeep() {
      console.log('Attempting to delete keep:', AppState.activeKeep.id)
      if (window.confirm('Are you sure you would like to delete this keep? \nWarning: This is permanent!')) {
        await keepsService.DeleteKeep(AppState.activeKeep.id)
        AppState.activeKeep = new Keep()
        console.log(route.name)
        if (route.name === 'Account') {
          keepsService.GetAccountKeeps()
        } else {
          keepsService.GetAllKeeps()
        }
      }
    }
    function toggleSaveMode(toggle) {
      state.saveMode = toggle
      console.log('Set saveMode to', state.saveMode)
    }
    return {
      state,
      AppState,
      deleteKeep,
      toggleSaveMode
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
