<template>
  <div class="col-md-3 d-flex m-0 pt-3 mb-3">
    <div class="card sizing action" data-bs-toggle="modal" data-bs-target="#keep-modal" @click.stop="setActive">
      <div class="card-body contain d-flex flex-column justify-content-end rounded" v-bind:style="{ backgroundImage: `url(${keep.img})` }">
        <h5 class="d-flex align-items-center justify-content-between mx-2 text-white darken-2 " title="Keep name">{{keep.name}}

        <img :src="keep.creator.picture" alt="" class="w-25 rounded-pill" :title="keep.creator?.name" @click="routerLink">
        </h5>
      </div>
    </div>
  </div>

</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed } from 'vue'
import { keepService } from "../services/KeepService"
import { logger } from "../utils/Logger"
import { Modal } from "bootstrap"
import Pop from "../utils/Pop"
import { useRouter } from "vue-router"
export default {
  props:{keep: {type: Object, required: true}},
  setup(props) {
    const router = useRouter()
    return {
        routerLink() {
        router.push({
          name: "Profile",
          params: { id: props.keep.creator?.id }
        })
          Modal.getOrCreateInstance(document.getElementById("keep-modal")).hide()
      },
       async setActive() {
        try {
          AppState.activeKeep = props.keep
          await keepService.getKeepById(props.keep.id)
        } catch (error) {
          logger.error(error)
          Modal.getOrCreateInstance(document.getElementById("keep-modal")).hide()
          Pop.toast(error, 'error')
        }
      },
      keeps: computed(()=> AppState.keeps),
      myKeeps: computed(()=> AppState.myKeeps)
    }
  }
}
</script>

<style scoped lang="scss">

.sizing{
  height:250px;
}
.contain{
  object-fit: contain;
}

</style>
