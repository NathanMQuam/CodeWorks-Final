<template>
  <div class="KeepComponent m-2 w-100">
    <div class="card shadow p-1">
      <div class="w-100 d-flex justify-content-between">
        <div class="text-center w-50">
          Test Card Text
        </div>
        <div class="text-center w-25">
          <div class="h-100 bg-dark"></div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { Keep } from '../models/KeepModel.js'
export default {
  name: 'KeepComponent',
  setup() {
    return {}
  },
  props: { keep: { type: Keep, default: () => new Keep() } },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
