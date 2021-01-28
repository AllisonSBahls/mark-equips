import axios from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function auth(login: any){
   return api.post('api/v1/auth/login', login);
}