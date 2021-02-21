import axios, { AxiosRequestConfig } from "axios";
import { IUsers } from "../Pages/Collaborator/types";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchCollaborator(page: number, token:AxiosRequestConfig, name:string){
    return api.get(`api/v1/users/asc/10/${page}/?name=${name}`, token);
}

export function findById(id: number, token: AxiosRequestConfig){
    return api.get(`api/v1/users/${id}`, token);
}

export function register(collaborator: IUsers, token: AxiosRequestConfig){
    return api.post('api/v1/users', collaborator, token);
}

export function removeCollaborator(id: number, token:AxiosRequestConfig){
    return api.delete(`api/v1/users/${id}`, token);
}

export function updateCollaborator(collaborator: IUsers, token: AxiosRequestConfig){
    return api.put('api/v1/users/', collaborator, token);
}

