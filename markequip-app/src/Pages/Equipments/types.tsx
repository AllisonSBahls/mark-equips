export interface IEquipmentReserver{
     id: number,
     name: string,
     description: string,
     number: number;
     date : Date;
     status : number;
     scheduleId : number;
}

export interface IEquipment{
     id: number,
     name: string,
     description: string,
     number: number;
}