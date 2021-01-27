import axios from "axios";

export const api = axios.create({
    baseURL: 'https://localhost:44396',
})

export function auth(login: any){
   return api.post('api/v1/auth/login', login);
}

