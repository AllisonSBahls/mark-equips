import { ISchedule } from "../Schedule/types";

export function checkIsSelected(selectSchedules: ISchedule[], schedules: ISchedule){
    return selectSchedules.some(item => item.id === schedules.id);
}