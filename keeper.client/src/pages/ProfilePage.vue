<template>
  <div class="container-fluid">
    <div class="row h-50">
      <div class="col-md-12 my-4" style="height:15rem">
        <div class="row ms-2">
          <div class="col-md-1">
            <img :src="profile.picture" alt="">
          </div>
          <div class="col-md-11 d-flex flex-column">
            <div class="row ">
              <div class="col-md-12">
                {{profile.name}}
              </div>
            </div>
            <div class="row my-3">
              <div class="col-md-12">
                <p>
                  Vaults: {{profileVaults.length}} 
                </p>
              </div>
              <div class="col-md-12">
                <p>
                  Keeps: {{profileKeeps.length}} 
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-12 my-2 ms-2">
        Vaults <button class="btn btn-outline-primary mdi mdi-plus" title="create vault" data-bs-toggle="modal" data-bs-target="#createVault-modal" v-if="account.id == route.params.id"></button>
      </div>
      <div class="col-md-12 d-flex" >
        <div class="row">
          <div class="col-md-2" style="width:18rem" v-for="v in profileVaults" :key="v.id"> 
            <div class="card m-2 bg-dark sizing action" title="Click to open vault" style="" @click="routerLink(v.id)">
              <div class="card-body d-flex align-items-end ">
                {{v.name}}
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-12 my-2 ms-2">
        Keeps <button class="btn btn-outline-primary mdi mdi-plus" title="create keep" data-bs-toggle="modal" data-bs-target="#createKeep-modal" v-if="account.id == route.params.id"></button>
      </div>
      <div class="col-md-12 d-flex">
        <div class="row">
          <div class="col-md-2" style="width:18rem" v-for=" k in profileKeeps" :key="k.id">
            <div class="card m-2 bg-dark sizing action" title="Click to open keep" data-bs-toggle="modal" data-bs-target="#keep-modal" @click.stop="setActive(k)">
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
import { computed, onMounted } from "@vue/runtime-core"
import { useRoute, useRouter } from "vue-router"
import { AppState } from "../AppState"
import {profileService} from "../services/ProfileService"
import { keepService } from "../services/KeepService"
import { logger } from "../utils/Logger"
import { Modal } from "bootstrap"
import Pop from "../utils/Pop"
import { accountService } from "../services/AccountService"
export default {
  name: 'ProfilePage',
  setup(){
    const route = useRoute()
    const router = useRouter()
    onMounted(async() => {
        await profileService.getUserProfile(route.params.id)
        await profileService.getVaultsByProfileId(route.params.id),
        await profileService.getKeepsByProfileId(route.params.id)
        await accountService.getAccount()
    })

    return{
      routerLink(id) {
        router.push({
          name: "Vault",
          params: { id: id }
        })
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
      router,
      route,
      keeps: computed(()=> AppState.keeps),
      activeVault: computed(()=> AppState.activeVault),
      vaults: computed(()=> AppState.vaults),
      profileVaults: computed(() => AppState.profileVaults),
      profileKeeps: computed(()=> AppState.profileKeeps),
      profile: computed(()=> AppState.profile),
      account: computed(()=> AppState.account)
    }
  }
}
</script>

<style lang="scss" scoped>
.sizing {
  height: 200px;
  
}
</style>