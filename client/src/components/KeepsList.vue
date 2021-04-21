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
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="keepDetailsModalTitle">
            Modal title
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          Keep details here
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="button" class="btn btn-primary">
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState.js'
export default {
  name: 'KeepsList',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps)
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
