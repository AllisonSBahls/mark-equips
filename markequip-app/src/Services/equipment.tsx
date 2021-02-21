import axios, { AxiosRequestConfig } from "axios";
import { IEquipment } from "../Pages/Equipments/types";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchEquipment(page: number, token:AxiosRequestConfig, name:string){
    return api.get(`api/v1/equipments/asc/10/${page}/?name=${name}`, token);
}

export function findById(id: number, token: AxiosRequestConfig){
    return api.get(`api/v1/equipments/${id}`, token);
}

export function register(equipment: IEquipment, token: AxiosRequestConfig){
    return api.post('api/v1/equipments', equipment, token);
}

export function removeEquipment(id: number, token:AxiosRequestConfig){
    return api.delete(`api/v1/equipments/${id}`, token);
}

export function updateEquipments(equipments: IEquipment, token: AxiosRequestConfig){
    return api.put('api/v1/equipments/', equipments, token);
}

