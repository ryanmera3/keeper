import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class ProfileService {
  async getVaultsByProfileId(profileId){
    const res = await api.get(`/api/profiles/${profileId}/vaults`)
    logger.log('Get vaults by profile id', res.data)
    AppState.profileVaults = res.data
  }
  async getKeepsByProfileId(profileId){
    const res = await api.get(`/api/profiles/${profileId}/keeps`)
    logger.log('Get keeps by profile id', res.data)
    AppState.profileKeeps = res.data
  }

  async getUserProfile(profileId){
    const res = await api.get(`/api/profiles/${profileId}`)
    logger.log('Get user profile', res.data)
    AppState.user = res.data
  }
}

export const profileService = new ProfileService()