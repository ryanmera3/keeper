import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  vaults: [],
  vault: {},
  keeps: [],
  vaultKeeps:[],
  profileVaults: [],
  profileKeeps:[],
  activeKeep: {},
  activeVault: {},
  myVaults: []
})
