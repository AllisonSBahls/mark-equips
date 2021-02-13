import axios, { AxiosRequestConfig } from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function auth(login: any){
   return api.post('api/v1/auth/login', login);
}

export function validateToken(token: AxiosRequestConfig){
    return api.get('api/v1/auth/validate', token);

}