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
            class="col-6 text-center d-flex flex-column justify-content-between"
          >
          <div class="row flex-column">
              <div class="col-md-12">
          <p>
            <i class="mdi mdi-eye" title="total views">
              {{activeKeep.views}}
              </i> 
              | 
              <i class="mdi mdi-alpha-k-box" title="total keeps">
                {{activeKeep.keeps}}
                </i>
          </p>
          <h3>
            {{activeKeep.name}}
          </h3>
          <p class="my-2">{{activeKeep.description}}</p>
          </div>
          </div>
            <div class="row">

              <div class="col-md-12 d-flex align-items-center">
          <button id="dropwdown" class="btn btn-outline-success dropdown-toggle" type="button" data-bs-toggle="dropdown" v-if="route.name == 'Home'">
            Add to Vault
          </button>
          <ul class="dropdown-menu scrollable">
            <li class="action" v-for="v in myVaults" :key="v.id" @click="createVaultKeep(v.id)">
              <h6>{{v.name}}</h6>
            </li>
          </ul>
          
          <button class="mdi mdi-delete btn btn-outline-danger mx-2" title="Delete keep" v-if="activeKeep.creator?.id == account.id" @click="deleteKeep(activeKeep.id)"></button>
          <img class="rounded-pill sizing mx-2 action" :src="activeKeep.creator?.picture" alt="" :title="activeKeep.creator?.name" @click="routerlink">
          <p class="m-0">{{activeKeep.creator?.name}}</p>

            </div>
              

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
import { logger } from "../utils/Logger"
import { keepService } from "../services/KeepService"
import { Modal } from "bootstrap"
import Pop from "../utils/Pop"
import { router } from "../router"
import { useRoute, useRouter } from "vue-router"
import { vaultKeepService } from "../services/VaultKeepService"
export default {
  setup() {
    const route = useRoute()
    const router = useRouter()
    return {
      route,
      router,
        routerLink() {
        router.push({
          name: "Profile",
          params: { id: activeKeep.creator?.id }
        })
          Modal.getOrCreateInstance(document.getElementById("keep-modal")).hide()
      },
      async createVaultKeep(vaultId){
        try {
          await vaultKeepService.createVaultKeep(vaultId, this.activeKeep.id)
          Modal.getOrCreateInstance(document.getElementById("keep-modal")).hide()
          Pop.toast('Keep added to vault', 'success')
        } catch (error) {
          logger.log(error)
        }
      },
      
      async deleteKeep(id){
        try {
          if(await Pop.confirm()){

          await keepService.deleteKeep(id)
          Modal.getOrCreateInstance(document.getElementById("keep-modal")).hide()
          Pop.toast('Keep deleted', 'success')
          }
        } catch (error) {
          logger.log(error)
        }
      },
      activeKeep: computed(()=> AppState.activeKeep),
      account: computed(()=> AppState.account),
      myVaults: computed(()=> AppState.myVaults),
      vaultKeeps: computed(()=> AppState.vaultKeeps),
      isVaultPage: computed(()=>  {
        route.name == "Vault"
      }),
      isHomePage: computed(()=> {
        route.path === "Home" ? true : false
      })
    }
  }
}
</script>


<style lang="scss" scoped>
.sizing {
  height: 50px;
}

.dropdown-menu {
    max-height: 280px;
    overflow-y: auto;
}
</style>