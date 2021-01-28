import axios from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchCollaborator(token:any){
    return api.get('api/v1/users/asc/10/1', token);
}

export function findById(id: number, token: any){
    return api.get(`api/v1/users/${id}`, token);
}

export function register(collaborator: any, token: any){
    return api.post('api/v1/users', collaborator, token);
}

export function removeCollaborator(id: number, token:any){
    return api.delete(`api/v1/users/${id}`, token);
}

export function updateCollaborator(collaborator: any, token: any){
    return api.put('api/v1/users/', collaborator, token);
}

