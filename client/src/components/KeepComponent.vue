<template>
  <div class="KeepComponent m-2 w-100 card bg-dark text-white shadow cursor-pointer" @click="GetKeep()" data-target="#keepDetailsModal" data-toggle="modal">
    <img :src="keep.image" class="card-img" :alt="keep.description">
    <div class="card-img-overlay img-gradient mt-auto p-0">
    </div>
    <div class="card-img-overlay mt-auto p-1 d-flex justify-content-between">
      <div class="card-title my-auto mw-75">
        {{ keep.name }}
      </div>
      <router-link class="profile-link text-right w-25 h-100 mh-100" :to="{name: 'Profile', params: {profileId: keep.creatorId}}">
        <img :src="keep.creator.picture" :alt="keep.creator.name" class="profile-img img-fluid mh-100 shadow">
      </router-link>
    </div>
  </div>
</template>

<script>
import { Keep } from '../models/KeepModel.js'
import { AppState } from '../AppState.js'
import { keepsService } from '../services/KeepsService.js'
export default {
  name: 'KeepComponent',
  setup(props) {
    function GetKeep() {
      // console.log('Got keep:', props.keep.id)
      keepsService.GetKeepById(props.keep.id)
    }
    return {
      AppState,
      GetKeep
    }
  },
  props: { keep: { type: Keep, default: () => new Keep() } },
  components: {}
}
</script>

<style lang="scss">
.keepCard {
  overflow: hidden;
}

// .keepCard img, .profile-link, .img-gradient {
//   transition: transform .2s; /* Animation */
// }

// .keepCard:hover .card-img, .profile-link:hover {
//   transform: scale(1.1);
// }

.card-img-overlay {
  height: 3rem;
}

.img-gradient {
  height: 3.5rem;
  background: rgb(0,0,0);
  background: linear-gradient(0deg, rgba(0,0,0,0.7) 0%, rgba(255,255,255,0) 100%);
  transition: height .2s;
}

// .keepCard:hover .img-gradient {
//   height: 4rem;
// }

.profile-img {
  border-radius: 100%;
}
</style>
