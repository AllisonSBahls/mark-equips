import axios, { AxiosRequestConfig } from "axios";
import { IReserve } from "../Pages/Reservations/types";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    responseType: "json"

})

export function fetchAllMyReservers(  
    page: number, 
    token:AxiosRequestConfig, 
    date:string, 
    equipment:string, 
    status: number){
    return api.get(`api/v1/reservations/my/asc/5/${page}/?date=${date}&status=${status}&equipment=${equipment}`, token);
}

export function fetchAllMyInUse(  
    page: number, 
    token:AxiosRequestConfig, 
    date:string, 
    equipment:string, 
    status: number){
    return api.get(`api/v1/reservations/my/asc/5/${page}/?date=${date}&status=${status}&equipment=${equipment}`, token);
}


export function fetchReserverDelivered(
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

