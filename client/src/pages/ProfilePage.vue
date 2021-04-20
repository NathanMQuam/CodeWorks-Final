<template>
  <div class="ProfilePage container">
    <div class="row">
      <div class="col">
        <div class="text-center p-1">
          <img class="rounded" :src="state.activeProfile.picture" :alt="state.activeProfile.email" />
          <p>{{ state.activeProfile.email }}</p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h4>Vaults</h4>
      </div>
      <div class="col-3" v-for="vault in state.vaults" :key="vault.id">
        <div class="card p-2 my-1 shadow">
          <p>{{ vault.name }}</p>
          <p>{{ vault.description }}</p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h4>Keeps</h4>
      </div>
      <div class="col-3" v-for="keep in state.keeps" :key="keep.id">
        <div class="card shadow my-1">
          <p>{{ keep.name }}</p>
          <p>{{ keep.description }}</p>
          <img class="img-fluid" :src="keep.image">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    })
    onMounted(() => {
      const id = route.params.profileId
      profileService.GetProfileById(id)
      profileService.GetUsersKeeps(id)
      profileService.GetUsersVaults(id)
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
