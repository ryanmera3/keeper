<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 mt-5">
        <h1 class="d-flex justify-content-between">
          {{vault.name}}
          <div >
            <button class="btn btn-outline-danger" v-if="vault.creatorId == account.id" @click.stop="deleteVault(vault.id)">Delete Vault</button>
          </div>
          </h1>
          <h5>
           Keeps: {{keeps.length}}
          </h5>
      </div>
      <div class="col-md-12 d-flex  mt-2">
        <div class="row">
          <div class="col-md-2" style="width:18rem" v-for=" k in vaultKeeps" :key="k.id">
            <div class="card m-2 bg-dark sizing action" data-bs-toggle="modal" data-bs-target="#keep-modal" @click.stop="setActive(k)">
              <div class="card-body d-flex align-items-end justify-content-between " v-bind:style="{ backgroundImage: `url(${k.img})` }">
                {{k.name}}
              <button class="btn btn-outline-danger mdi mdi-delete " title="Remove keep from vault" @click.stop="deleteVaultKeep(k.vaultKeepId)"></button>
                </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { accountService } from "../services/AccountService"
import { vaultService } from "../services/VaultService"
import { useRoute, useRouter } from "vue-router"
import { logger } from "../utils/Logger"
import { Modal } from "bootstrap"
import Pop from "../utils/Pop"
import { keepService } from "../services/KeepService"
import { vaultKeepService } from "../services/VaultKeepService"
export default {
  name: 'VaultPage',
  setup() {

      const route = useRoute()
      const router = useRouter()
      onMounted(async ()=>{
        try {
          await vaultService.getVaultById(route.params.id)
          await vaultService.getKeepsByVaultId(route.params.id)
          
        } catch (error) {
          router.push({
          name: "Home"
        })
        }
      })
    return {
      route,
      router,
        vault: computed(() => AppState.vault),
        keeps: computed(()=> AppState.keeps),
        account: computed(()=> AppState.account),
        vaultKeeps: computed(()=> AppState.vaultKeeps),
      async deleteVault(id){
        try {
          if(await Pop.confirm()){

          await vaultService.deleteVault(id)
          Pop.toast('Vault deleted', 'success')
          router.push({
          name: "Home"
        })
          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error, 'error')
        }
      },
      async setActive(keep) {
        try {
          AppState.activeKeep = keep
          await keepService.getKeepById(keep.id)
        } catch (error) {
          logger.error(error)
          Modal.getOrCreateInstance(document.getElementById("keep-modal")).hide()
          Pop.toast(error, 'error')
        }
      },
      async deleteVaultKeep(vaultKeepId){
        try {
          if(await Pop.confirm()){
          await vaultKeepService.deleteVaultKeep(vaultKeepId)
          Modal.getOrCreateInstance(document.getElementById("keep-modal")).hide()
          Pop.toast('Vault keep was deleted', 'success')
          }
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style scoped>
.sizing {
  height: 200px;
  
}
</style>
