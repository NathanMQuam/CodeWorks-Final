<template>
  <div class="home container">
    <div class="row">
      <div class="col-3" v-for="keep in state.keeps" :key="keep.id">
        <!-- V-For -->
        <KeepComponent class="keepCard" :keep="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState.js'
export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      keepsService.GetAllKeeps()
    })
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    return {
      state
    }
  }
}
</script>

<style lang="scss">
.keepCard {
  overflow: hidden;
}

.keepCard img {
  transition: transform .2s; /* Animation */
}

.keepCard:hover img {
  transform: scale(1.1);
}
</style>
