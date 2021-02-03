import { ISchedule } from "../Schedule/types"

type Props = {
    isSelected: Boolean;
    schedule: ISchedule;
    onSelectSchedules:  (schedule: ISchedule) => void;
}

export function ScheduleList({isSelected, schedule, onSelectSchedules}: Props ){
    
    return( 
        <div className={`equipment-card ${isSelected ? 'selected' : ''}`} onClick={() => onSelectSchedules(schedule)}>
            <p className="equipment-schedule-period">{schedule.period}</p>
            <p className="equipment-schedule-hourInitial">{schedule.hourInitial} - {schedule.hourFinal}</p>
        </div>
  )
}
