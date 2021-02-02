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

export function register(schedule: any, token: any){
    return api.post('api/v1/schedules', schedule, token);
}

export function removeSchedule(id: number, token:any){
    return api.delete(`api/v1/schedules/${id}`, token);
}

export function updateSchedule(schedule: any, token: any){
    return api.put('api/v1/users/', schedule, token);
}

