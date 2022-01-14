<template>
  <div class=" flex-grow-1 d-flex flex-column align-items-center justify-content-center container-fluid">
    <div class="masonry-with-columns">
      <Keeps v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { useRoute, useRouter } from "vue-router"
import {keepService} from "../services/KeepService"
import { AppState } from "../AppState"
import { accountService } from "../services/AccountService"
export default {
  name: 'Home',
  setup(){
    const route = useRoute()
    const router = useRouter()
    onMounted(async() => {
      await keepService.getAllKeeps()
    })

    return{
      router,
      route,
      account: computed(()=>AppState.account),
      keeps: computed(()=> AppState.keeps),
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

body {
  margin: 0;
  padding: 1rem;
}

.masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    background: #EC985A;
    color: white;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  } 

}









</style>
