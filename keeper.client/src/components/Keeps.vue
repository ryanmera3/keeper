<template>
  <div >
    <div class="card action d-flex justify-content-end" data-bs-toggle="modal" data-bs-target="#keep-modal" @click.stop="setActive">
      <!-- <div class="card-body contain d-flex flex-column justify-content-end rounded" v-bind:style="{ backgroundImage: `url(${keep.img})` }"> -->
        <img :src="keep.img" alt="" class="img-fluid">
        <span class="position-absolute d-flex justify-content-between w-100 p-2">
          
        <h5 class="d-flex align-items-center justify-content-between mx-2 text-white shadow" title="Keep name">{{keep.name}}
        </h5>
        <img :src="keep.creator.picture" alt="" class="w-25 rounded-pill action mb-2" :title="keep.creator?.name" @click="routerLink">
        </span>
      </div>
    <!-- </div> -->
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
  min-height:250px;
}
.contain{
  object-fit: contain;
}
.shadow{
  text-shadow: 1.5px 1.5px #000000;
}

</style>
