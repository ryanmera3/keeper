import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class VaultService {

  async getVaultById(id){
    const res = await api.get(`/api/vaults/${id}`)
    logger.log('Vault by Id', res.data)
    AppState.vault = res.data
  }

  async createVault(){
    const res = await api.post(`/api/vaults`)
    logger.log('Create vault', res.data)
    AppState.myVaults 
  }

  async getKeepsByVaultId(vaultId){
    const res = await api.get(`/api/vaults/${vaultId}/keeps`)
    logger.log('Get keeps by vault id', res.data)
    AppState.keeps = res.data
  }

  async createVault(vault){
    const res = await api.post(`/api/vaults`, vault)
    logger.log('Create vault', res.data)
    AppState.vaults.push(res.data)
  }

  async deleteVault(vaultId){
    const res = await api.delete(`/api/vaults/${vaultId}`)
    logger.log('Deleted vault', res.data)
    AppState.vaults = AppState.vaults.filter(v => v.id !== vaultId)
  }
}

export const vaultService = new VaultService()