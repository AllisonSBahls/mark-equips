import axios, { AxiosRequestConfig } from "axios";
import { IReserve } from "../Pages/Reservations/types";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    responseType: "json"

})

export function fetchReserver(page: number, token:AxiosRequestConfig, name:string, equipment:string){
    return api.get(`api/v1/reservations/asc/12/${page}/?name=${name}&equipment=${equipment}`, token);
}

export function fetchReserverUsers(page: number, token:AxiosRequestConfig, name:string){
    return api.get(`api/v1/reservations/users/asc/12/${page}/?name=${name}`, token);
}

export function fetchReserverDelived(
    page: number, 
    token:AxiosRequestConfig, 
    date:string, 
    name: string, 
    equipment:string, 
    status: number){
    return api.get(`api/v1/reservations/asc/5/${page}/?date=${date}&status=${status}&name=${name}&equipment=${equipment}`, token);
}
export function fetchReserverReserved(    
    page: number, 
    token:AxiosRequestConfig, 
    date:string, 
    name: string, 
    equipment:string, 
    status: number){
        return api.get(`api/v1/reservations/asc/5/${page}/?date=${date}&status=${status}&name=${name}&equipment=${equipment}`, token);
    }

export function findById(id: number, token: AxiosRequestConfig){
    return api.get(`api/v1/reservations/${id}`, token);
}

export function reserver(equipment: IReserve, token: AxiosRequestConfig){
    return api.post('api/v1/reservations', equipment, token);
}

export function cancelReserver(id: number, token: AxiosRequestConfig){
    return api.patch(`api/v1/reservations/cancel/${id}`,id , token);
}
export function deliverReserver(id: number, token: AxiosRequestConfig){
    return api.patch(`api/v1/reservations/deliver/${id}`, id, token);
}
export function finishReserver(id: number, token: AxiosRequestConfig){
    return api.patch(`api/v1/reservations/collect/${id}`, id, token);
}

