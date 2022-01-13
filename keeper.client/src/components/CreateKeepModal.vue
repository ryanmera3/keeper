<template>
  <Modal id="createKeep-modal" size="modal-lg">
    <template #modal-body>
      <form @submit.prevent="createKeep">

      <div class="container-fluid">
        <div class="row">
          <div class="col-md-12">
              New Keep
          </div>
          <div class="col-md-12 my-2">
            <label for="name" class="form-label">Name</label>
            <input type="text" class="form-control" id="name" placeholder="name"  v-model="keepData.editable.name" aria-describedby="name">
          </div>
          <div class="col-md-12 my-2">
            <label for="title" class="form-label">Img Url</label>
            <input type="text" class="form-control" id="img" placeholder="img" v-model="keepData.editable.img" aria-describedby="img">
          </div>
          <div class="col-md-12 my-2">
            <label for="description" class="form-label">Description</label>
            <input type="text" class="form-control" id="description" placeholder="description"  v-model="keepData.editable.description" aria-describedby="description">

          </div>
          <div class="col-md-12 d-flex justify-content-end">
            <button class="btn btn-outline-primary" title="Create keep" type="submit" >Create Keep</button>
          </div>
        </div>
      </div>
      </form>
    </template>
  </Modal>
</template>


<script>
import { computed, reactive } from '@vue/reactivity'
import { AppState } from '../AppState'
import { logger } from "../utils/Logger"
import { keepService } from "../services/KeepService"
import { Modal } from "bootstrap"
export default {
  setup() {
    const keepData = reactive({editable: {} })
    return {
      keepData,
      async createKeep(){
        try {
          await keepService.createKeep(keepData.editable)
          keepData.editable = {}
          Modal.getOrCreateInstance(document.getElementById("createKeep-modal")).hide()
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.sizing {
  height: 50px;
}
</style>