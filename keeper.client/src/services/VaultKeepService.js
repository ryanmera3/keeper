import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultKeepService {
  async createVaultKeep(vaultId, keepId){
    const res = await api.post(`/api/vaultkeeps`, { vaultId: vaultId, keepId: keepId})
    logger.log('Create vault keep', res.data)
    AppState.vaultKeeps = res.data
  }

  async deleteVaultKeep(vaultKeepId){
    const res = await api.delete(`/api/vaultkeeps/${vaultKeepId}`)
    logger.log('Delete vaultkeep', res.data)
    AppState.vaultKeeps = AppState.vaultKeeps.filter(vk => vk.id !== vaultKeepId)
  }
}
export const vaultKeepService = new VaultKeepService()