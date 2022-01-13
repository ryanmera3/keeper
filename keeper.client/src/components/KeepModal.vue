<template>
  <Modal id="keep-modal" size="modal-xl">
    <template #modal-body>
      <div class="container-fluid">
        <div class="text-end">
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="row">
          <div class="col-6">
            <img
              
              class="w-100 object-fit-cover rounded"
              :src="activeKeep.img"
              alt=""
            />
          </div>
          <div
            class="col-6 text-center d-flex flex-column justify-content-center"
          >
          <p>
            {{activeKeep.views}} | {{activeKeep.keeps}}
          </p>
          <h3>
            {{activeKeep.name}}
          </h3>
          <p>{{activeKeep.description}}</p>
          <div class="d-flex justify-content-between">

          <button class="btn btn-outline-success">
            Add to Vault
          </button>
          <button class="mdi mdi-delete btn btn-outline-danger" title="Delete keep" v-if="activeKeep.creator?.id == account.id"></button>
          <img class="rounded-pill sizing" :src="activeKeep.creator?.picture" alt="" :title="activeKeep.creator?.name">
          </div>
          </div>
        </div>
      </div>
    </template>
  </Modal>
</template>


<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      activeKeep: computed(()=> AppState.activeKeep),
      account: computed(()=> AppState.account)
    }
  }
}
</script>


<style lang="scss" scoped>
.sizing {
  height: 50px;
}
</style>