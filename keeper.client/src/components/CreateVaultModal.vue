<template>
  <Modal id="createVault-modal" size="modal-lg">
    <template #modal-body>
      <form @submit.prevent="createVault">

      <div class="container-fluid">
        <div class="row">
          <div class="col-md-12">
              New Vault
          </div>
          <div class="col-md-12 my-2">
            <label for="name" class="form-label">Name</label>
            <input type="text" class="form-control" id="name" placeholder="name"  v-model="vaultData.editable.name" aria-describedby="name">
          </div>

          <div class="col-md-12 my-2">
            <label for="description" class="form-label">Description</label>
            <input type="text" class="form-control" id="description" placeholder="description"  v-model="vaultData.editable.description" aria-describedby="description">

          </div>
            <div class="col-md-1 my-2">
            <label for="title" class="form-label">Prviate?</label>
            <input type="checkbox" class="form-check-input" id="isPrivate" placeholder="isPrivate" v-model="vaultData.editable.isPrivate" :checked="vaultData.editable.isPrivate" aria-describedby="isPrivate">
          </div>
          <div class="col-md-12 d-flex justify-content-end">
            <button class="btn btn-outline-primary" title="Create vault" type="submit" >Create Vault</button>
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
import { vaultService } from "../services/VaultService"
import { Modal } from "bootstrap"
export default {
  setup() {
    const vaultData = reactive({editable: {} })
    return {
      vaultData,
      async createVault(){
        try {
          await vaultService.createVault(vaultData.editable)
          vaultData.editable = {}
          Modal.getOrCreateInstance(document.getElementById("createVault-modal")).hide()
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