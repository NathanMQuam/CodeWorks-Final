<template>
  <div class="ProfilePage">
    <img class="rounded" :src="state.activeProfile.picture" :alt="state.activeProfile.email" />
    <p>{{ state.activeProfile.email }}</p>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState.js'
// import { useRoute } from 'vue-router'
export default {
  name: 'ProfilePage',
  setup() {
    // const route = useRoute()
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile)
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
