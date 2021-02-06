import axios, { AxiosRequestConfig } from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchReserver(page: any, token:any, name:any, equipment:string){
    return api.get(`api/v1/reservations/asc/12/${page}/?name=${name}&equipment=${equipment}`, token);
}

export function fetchReserverUsers(page: any, token:any, name:any){
    return api.get(`api/v1/reservations/users/asc/12/${page}/?name=${name}`, token);
}

export function fetchReserverDelived(page: number, token:AxiosRequestConfig, date:string){
    return api.get(`api/v1/reservations/delivered/asc/3/${page}/?date=${date}`, token);
}
export function fetchReserverCollect(page: number, token:AxiosRequestConfig, date:string){
    return api.get(`api/v1/reservations/collect/asc/3/${page}/?date=${date}`, token);
}
export function fetchReserverReserved(page: number, token:AxiosRequestConfig, date:string){
    return api.get(`api/v1/reservations/reserved/asc/3/${page}/?date=${date}`, token);
}

export function findById(id: number, token: any){
    return api.get(`api/v1/reservations/${id}`, token);
}

export function reserver(equipment: any, token: any){
    return api.post('api/v1/reservations', equipment, token);
}

export function removeReserver(id: number, token:any){
    return api.delete(`api/v1/reservations/${id}`, token);
}

export function cancelReserver(id: number, token: AxiosRequestConfig){
    return api.patch(`api/v1/reservations/cancel/${id}`, token);
}
export function deliverReserver(id: number, token: AxiosRequestConfig){
    return api.patch(`api/v1/reservations/deliver/${id}`, token);
}
export function finishReserver(id: number, token: AxiosRequestConfig){
    return api.patch(`api/v1/reservations/collect/${id}`, token);
}

