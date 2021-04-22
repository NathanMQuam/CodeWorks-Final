<template>
  <div class="CreateKeepComponent">
    <div class="cursor-pointer p-2 px-4" data-target="#createKeepModal" data-toggle="modal">
      <i class="fa fa-plus" aria-hidden="true"></i>
    </div>

    <div class="modal fade"
         id="createKeepModal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="createKeepModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-lg" role="document">
        <form class="modal-content" @submit.prevent="createKeep">
          <div class="modal-header">
            <h5 class="modal-title" id="createKeepModalLabel">
              New Keep
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="form-group">
              <label>Keep Title</label>
              <input v-model="state.newKeep.name"
                     type="text"
                     class="form-control"
                     placeholder="Keep Title"
                     required
                     minlength="3"
                     name="keepTitle"
              >
            </div>
            <label>Image URL</label>
            <div class="form-group">
              <input v-model="state.newKeep.image"
                     type="text"
                     class="form-control"
                     placeholder="url"
                     required
                     minlength="10"
                     name="keepImageUrl"
              >
            </div>
            <div class="form-group">
              <label>Keep Description</label>
              <textarea v-model="state.newKeep.description" name="keepDescription" class="w-100" rows="5" placeholder="Keep description..."></textarea>
            </div>
            <!-- <textarea class="w-100" disabled alt="Coming soon"></textarea>
              <small class="form-text text-muted">* Separate tags with a comma</small>
              <div class="bg-dark">
                <img src="https://placehold.it/200x200">
              </div> -->
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">
              Cancel
            </button>
            <button type="submit" class="btn btn-primary" data-dismiss="modal">
              Publish
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService.js'
import { Keep } from '../models/KeepModel.js'
export default {
  name: 'CreateKeepComponent',
  setup() {
    const state = reactive({
      newKeep: computed(() => new Keep())
    })
    async function createKeep() {
      console.log('Attempting to create keep:', state.newKeep)
      await keepsService.CreateKeep(state.newKeep)
      state.newKeep = new Keep()
      keepsService.GetAccountKeeps()
    }
    return { state, createKeep }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
