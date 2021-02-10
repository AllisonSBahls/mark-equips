import axios from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchEquipment(page: any, token:any, name:any){
    return api.get(`api/v1/equipments/asc/10/${page}/?name=${name}`, token);
}

export function findById(id: number, token: any){
    return api.get(`api/v1/equipments/${id}`, token);
}

export function register(equipment: any, token: any){
    return api.post('api/v1/equipments', equipment, token);
}

export function removeEquipment(id: number, token:any){
    return api.delete(`api/v1/equipments/${id}`, token);
}

export function updateEquipments(equipments: any, token: any){
    return api.put('api/v1/equipments/', equipments, token);
}

