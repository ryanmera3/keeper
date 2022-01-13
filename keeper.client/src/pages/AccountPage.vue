<template>
  <div class="container-fluid">
    <div class="row h-50">
      <div class="col-md-12 my-2">
        Vaults <button class="btn btn-outline-primary mdi mdi-plus" title="create vault"></button>
      </div>
      <div class="col-md-12 d-flex" >
        <div class="row">
          <div class="col-md-2" style="width:18rem"  v-for="v in myVaults" :key="v.id"> 
            <div class="card m-2 sizing bg-dark" @click="routerLink(v.id)">
              <div class="card-body d-flex align-items-end">
                {{v.name}}
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-12 my-2">
        Keeps <button class="btn btn-outline-primary mdi mdi-plus" title="create keep" data-bs-toggle="modal" data-bs-target="#createKeep-modal"></button>
      </div>
           <div class="col-md-12 d-flex">
        <div class="row">
          <div class="col-md-2" style="width:18rem" v-for=" k in myKeeps" :key="k.id">
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
import { useRoute, useRouter } from "vue-router"
import { keepService } from "../services/KeepService"
export default {
  name: 'Account',
  setup() {
    const route = useRoute()
    const router = useRouter()
    onMounted(async()=>{
      await accountService.getMyVaults()
    })
    return {
    routerLink(id) {
        router.push({
          name: "Vault",
          params: { id: id }
        })
      },
      account: computed(() => AppState.account),
      myVaults: computed(()=> AppState.myVaults),
      myKeeps: computed(()=> AppState.myKeeps)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
.sizing {
  height: 200px;
}
</style>
