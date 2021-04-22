<template>
  <div class="ProfilePage container">
    <div class="row py-4">
      <div class="col-2">
        <img class="rounded img-fluid w-100" :src="state.account.picture" />
      </div>
      <div class="col-9">
        <div>
          <h1>{{ state.account.name }}</h1>
        </div>
        <div>
          <h4>Vaults: {{ state.numVaults }}</h4>
          <h4>Keeps: {{ state.numKeeps }}</h4>
        </div>
      </div>
    </div>
    <h3>Vaults</h3>
    <VaultsList />
    <h3>Keeps</h3>
    <KeepsList />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { useRoute /*, useRouter */ } from 'vue-router'
import { profileService } from '../services/ProfileService'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    // const router = useRouter()
    const state = reactive({
      account: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      numKeeps: computed(() => AppState.keeps.length),
      numVaults: computed(() => AppState.vaults.length)
    })
    onMounted(() => {
      const id = route.params.profileId
      // TODO: Go to account page instead if the profile is your account
      // if (id === state.account.id) {
      // router.push('Account')
      // }
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
