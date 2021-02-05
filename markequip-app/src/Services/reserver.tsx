import axios, { AxiosRequestConfig } from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchReserver(page: any, token:any, name:any){
    return api.get(`api/v1/reservations/asc/12/${page}/?name=${name}`, token);
}

export function fetchReserverUsers(page: any, token:any, name:any){
    return api.get(`api/v1/reservations/users/asc/12/${page}/?name=${name}`, token);
}

export function fetchReserverDate(page: number, token:AxiosRequestConfig, date:string){
    return api.get(`api/v1/reservations/date/asc/12/${page}/?date=${date}`, token);
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

export function cancelReserver(id: number, token: any){
    return api.put('api/v1/reservations/cancel', id, token);
}

