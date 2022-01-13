import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class KeepService {

  async getAllKeeps(){
    const res = await api.get(`/api/keeps`)
    logger.log('Get all keeps', res.data)
    AppState.keeps = res.data
  }

  async getKeepById(id){
    const res = await api.get(`/api/keeps/${id}`)
    logger.log('Get Keep by Id', res.data)
    AppState.activeKeep = res.data
  }

  async createKeep(keep){
    const res = await api.post(`/api/keeps`, keep)
    logger.log('Create Keep', res.data)
    AppState.keeps.push(res.data)
  }

  async editKeep(keep){
    const res = await api.put(`/api/keeps/${id}`, keep)
    logger.log('Edit Keep', res.data)
    AppState.activeKeep = res.data
  }

  async deleteKeep(keepId){
    const res = await api.delete('api/albums/' + keepId)
    logger.log("Deleted keep")
    AppState.keeps = AppState.keeps.filter(k => k.id !== keepId)
  }

}

export const keepService = new KeepService()