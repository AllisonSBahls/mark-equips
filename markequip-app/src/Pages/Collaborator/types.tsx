export interface IUsers {
    id: number;
    fullName:string;
    userName:string;
    password:string;
    roles:string;
}

export interface IUserLogin{
    userName: string;
    password: string;
}