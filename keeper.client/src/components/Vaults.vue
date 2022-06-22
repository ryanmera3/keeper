<template>
<div class="col-md-3 d-flex justify-content-center" @click="routerLink">
  <div>
    <p>
      {{vault.name}}
      {{vault.description}}
    </p>
  </div>
  </div>

</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed } from 'vue'
export default {
  props:{vault: {type: Object, required: true}},
  setup(props) {
    return {
      routerLink(){
        router.push({
          name:"Vault",
          params: {vaultId: props.vault.id}
        })
      },
      activeVault: computed(()=> AppState.activeVault),
      vaults: computed(()=> AppState.vaults),
      myVaults: computed(()=> AppState.myVaults)
    }
  }
}
</script>

<style scoped lang = "scss">

</style>
