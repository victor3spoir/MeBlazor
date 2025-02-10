import { Axios } from "axios";
import { apiClient } from "./api-client";


export class Fetcher<T> {
  _client!: Axios
  route!: string
  constructor(route: string) {
    this._client = apiClient
    this.route = route
  }

  async getAll(): Promise<T[]> {
    return (await this._client.get<T[]>(this.route, {
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json"
      }
    })).data
  }

  async delete(id: string) {
    const response = await this._client.delete(`${this.route}/${id}`)
    return response.data
  }

  async create(data: any) {
    return await this._client.post(this.route, data, {
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json"
      }
    })
  }

}