<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center container-fluid">
    <div class="row">
      <Vaults v-for="v in myVaults" :key="v.id" :vault="v"/>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { useRoute, useRouter } from "vue-router"
import {vaultService} from "../services/VaultService"
import { AppState } from "../AppState"
export default {
  name: 'Home',
  setup(){
    const route = useRoute()
    const router = useRouter()
    onMounted(async () => {
      await vaultService.getMyVaults()
    })
    return{
      router,
      route,
      activeVault: computed(()=> AppState.activeVault),
      vaults: computed(()=> AppState.vaults),
      myVaults: computed(()=> AppState.myVaults)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card{
    width: 50vw;
    > img{
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
