import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class VaultService {

  async getMyVaults(){
    const res = await api.get(`/Account/vaults`)
    logger.log('Get my vaults', res.data)
    AppState.myVaults = res.data
  }

  async getVaultById(id){
    const res = await api.get(`/vaults/${id}`)
    logger.log('Vault by Id', res.data)
    AppState.vault = res.data
  }

  async createVault(){
    const res = await api.post(`/api/vaults`)
    logger.log('Create vault', res.data)
    AppState.myVaults 
  }
}

export const vaultService = new VaultService()