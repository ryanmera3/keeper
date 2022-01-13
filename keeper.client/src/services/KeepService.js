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

}

export const keepService = new KeepService()