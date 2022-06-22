<template>
  <div class="container-fluid">
    <div class="row h-50">
      <div class="col-md-12 my-2">
        <button class="btn btn-outline-primary mdi mdi-plus" title="create vault" data-bs-toggle="modal" data-bs-target="#createVault-modal"></button> Vaults: {{myVaults.length}}  
      </div>
      <div class="col-md-12 d-flex" >
        
        <div class="row">
          <div class="col-md-2" style="width:18rem"  v-for="v in myVaults" :key="v.id"> 
            <div class="card m-2 sizing bg-dark action vault-bg " title="Click to open vault" @click="routerLink(v.id)">
              <div class="card-body d-flex align-items-end justify-content-between">
                {{v.name}}
              <i class="mdi mdi-star text-success" title="This is a private vault" v-if="v.isPrivate"></i>
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

  .vault-bg {
    background: url(../assets/img/photo-1582139329536-e7284fece509.avif);
  }
</style>
