<template>

</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { useRoute, useRouter } from "vue-router"
export default {
  name: 'ProfilePage',
  setup(){
    const route = useRoute()
    const router = useRouter()
    onMounted(async() => {

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
