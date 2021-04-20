<template>
  <div class="KeepComponent m-2 w-100 card bg-dark text-white shadow">
    <img :src="props.keep.image" class="card-img" :alt="props.keep.description">
    <div class="card-img-overlay p-1 mt-auto d-flex justify-content-between">
      <div class="card-title my-auto mw-75">
        {{ props.keep.name }}
      </div>
      <div class="text-center w-25 h-100">
        <div class="h-100 bg-dark"></div>
      </div>
    </div>
  </div>
</template>

<script>
import { Keep } from '../models/KeepModel.js'
export default {
  name: 'KeepComponent',
  setup(props) {
    return { props }
  },
  props: { keep: { type: Keep, default: () => new Keep() } },
  components: {}
}
</script>

<style lang="scss" scoped>
.card-img-overlay {
  height: 3rem;
}

// .KeepComponent {
//   overflow: hidden;
// }

// .card-img {
//   transition: transform .2s; /* Animation */
// }

// .card-img:hover {
//   transform: scale(1.5);
// }
</style>
