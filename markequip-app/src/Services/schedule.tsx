import axios, { AxiosRequestConfig } from 'axios';
import { ISchedule } from '../Pages/Schedule/types';

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function fetchSchedule(token:AxiosRequestConfig){
    return api.get(`api/v1/schedules`, token);
}

export function findById(id: number, token: AxiosRequestConfig){
    return api.get(`api/v1/schedules/${id}`, token);
}

export function register(schedule: ISchedule, token: AxiosRequestConfig){
    return api.post('api/v1/schedules', schedule, token);
}

export function removeSchedule(id: number, token:AxiosRequestConfig){
    return api.delete(`api/v1/schedules/${id}`, token);
}

export function updateSchedule(schedule: ISchedule, token: AxiosRequestConfig){
    return api.put('api/v1/users/', schedule, token);
}

