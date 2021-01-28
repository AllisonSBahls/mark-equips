import axios from "axios";

export const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
})

export function register(collaborator: any, token: any){
    return api.post('api/v1/users', collaborator, token);
}

export function fetchCollaborator(token:any){
    return api.get('api/v1/users/asc/7/1', token);
}
