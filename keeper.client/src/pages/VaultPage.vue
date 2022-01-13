<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 mx-4 mt-5">
        <h1>
          {{vault.name}}
          </h1>
          <h5>
           Keeps: {{keeps.length}}
          </h5>
      </div>
      <div class="col-md-12 d-flex mx-3 mt-2">
        <div class="row">
          <div class="col-md-2" style="width:18rem" v-for=" k in keeps" :key="k.id">
            <div class="card m-2 bg-dark sizing action" data-bs-toggle="modal" data-bs-target="#keep-modal" @click.stop="setActive(k)">
              <div class="card-body d-flex align-items-end" v-bind:style="{ backgroundImage: `url(${k.img})` }">
                {{k.name}}
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
export default {
  name: 'VaultPage',
  setup() {
      const route = useRoute()
      const router = useRouter()
      onMounted(async ()=>{
        await vaultService.getVaultById(route.params.id)
        await vaultService.getKeepsByVaultId(route.params.id)
      })
    return {
      route,
      router,
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
      vault: computed(() => AppState.vault),
      keeps: computed(()=> AppState.keeps)
    }
  }
}
</script>

<style scoped>
.sizing {
  height: 200px;
  
}
</style>
