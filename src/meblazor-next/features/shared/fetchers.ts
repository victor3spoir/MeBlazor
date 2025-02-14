import { Axios, AxiosError, AxiosRequestConfig } from "axios";
import { apiClient } from "./api-client";


export type FetcherResponse<T> = {
  error?: AxiosError,
  results?: T
}
export class Fetcher<T> {
  _client!: Axios
  route!: string
  constructor(route: string) {
    this._client = apiClient
    this.route = route
  }

  async getAll(requestConfig?: AxiosRequestConfig): Promise<FetcherResponse<T[]>> {

    try {

      const response = await this._client.get<T[]>(this.route, {
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        }, ...requestConfig
      })
      return { results: response.data }
    } catch (err) {
      return { error: (err as AxiosError) }
    }
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