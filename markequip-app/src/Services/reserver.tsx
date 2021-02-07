import axios, { AxiosRequestConfig } from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    responseType: "json"

})

export function fetchReserver(page: any, token:any, name:any, equipment:string){
    return api.get(`api/v1/reservations/asc/12/${page}/?name=${name}&equipment=${equipment}`, token);
}

export function fetchReserverUsers(page: any, token:any, name:any){
    return api.get(`api/v1/reservations/users/asc/12/${page}/?name=${name}`, token);
}

export function fetchReserverDelived(
    page: number, 
    token:AxiosRequestConfig, 
    date:string, 
    name: string, 
    equipment:string, 
    status: number){
    return api.get(`api/v1/reservations/asc/4/${page}/?date=${date}&status=${status}&name=${name}&equipment=${equipment}`, token);
}
export function fetchReserverCollect(   
    page: number, 
    token:AxiosRequestConfig, 
    date:string, 
    status: number){
        return api.get(`api/v1/reservations/asc/4/${page}/?date=${date}&status=${status}`, token);
    }
export function fetchReserverReserved(    
    page: number, 
    token:AxiosRequestConfig, 
    date:string, 
    name: string, 
    equipment:string, 
    status: number){
        return api.get(`api/v1/reservations/asc/4/${page}/?date=${date}&status=${status}&name=${name}&equipment=${equipment}`, token);
    }

export function findById(id: number, token: any){
    return api.get(`api/v1/reservations/${id}`, token);
}

export function reserver(equipment: any, token: any){
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

