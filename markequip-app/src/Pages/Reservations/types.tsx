import { IUsers } from "../Collaborator/types";
import { IEquipment } from "../Equipments/types";
import { ISchedule } from "../Schedule/types";

export interface IReserver{
    id: number;
    date: Date;
    userId: number;
    user: IUsers;
    equipmentId: number;
    equipment: IEquipment;
    numberEquip: number;
    status: number;
    scheduleId: number;
    schedule: ISchedule;
}

export enum StatusReserver {
    RESERVED = 1,
    USING = 2,
    FINISHED = 3,
    CANCELED = 4
}