<template>
  <div class="KeepsList row">
    <div class="card-columns">
      <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
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
