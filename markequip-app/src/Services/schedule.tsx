import axios from 'axios';

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchSchedule(token:any){
    return api.get(`api/v1/schedules`, token);
}

export function findById(id: number, token: any){
    return api.get(`api/v1/schedules/${id}`, token);
}

export function register(collaborator: any, token: any){
    return api.post('api/v1/schedules', collaborator, token);
}

export function removeSchedule(id: number, token:any){
    return api.delete(`api/v1/schedules/${id}`, token);
}

export function updateCollaborator(collaborator: any, token: any){
    return api.put('api/v1/users/', collaborator, token);
}

