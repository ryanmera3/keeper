<template>
  <div class="col-md-3 d-flex m-0 pt-3">
    <div class="card sizing action" data-bs-toggle="modal" data-bs-target="#keep-modal" @click="setActive">
      <div class="card-body contain d-flex flex-column justify-content-end rounded" v-bind:style="{ backgroundImage: `url(${keep.img})` }">
        <h6 class="d-flex align-items-center justify-content-between mx-2 text-white darken-2 ">{{keep.name}}

        <img :src="keep.creator.picture" alt="" class="w-25 rounded-pill">
        </h6>
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
export default {
  props:{keep: {type: Object, required: true}},
  setup(props) {
    
    return {
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
