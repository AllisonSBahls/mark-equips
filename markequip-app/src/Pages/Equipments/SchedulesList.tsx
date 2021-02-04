import { useEffect, useState } from "react";
import { ISchedule } from "../Schedule/types";
import { checkIsSelected } from "./helpers";
import { IEquipment } from "./types";

type Props = {
  schedules: ISchedule[];
  equipments: IEquipment[];
  isSelected: ISchedule[];
  dateReservation: string;
  onSelectSchedules: (schedules: ISchedule) => void;
};

export function ScheduleList({ equipments, schedules, isSelected, onSelectSchedules, dateReservation }: Props) {
  const [equipmentNotAvaliable, setEquipmentNotAvaliable] = useState<number[]>(
    []
  );
  const notAvalaiable: number[] = [];

  useEffect(() => {
      const timer = setTimeout(() => {
        equipmentScheduleAvaliable();
      }, 700);
      return () => clearTimeout(timer);
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [equipments, dateReservation]);


  async function equipmentScheduleAvaliable() {
    if (equipments.length > 0) {
      for (let i = 0; i < equipments.length; i++) {
        var dateSchedule = new Date(equipments[i].date);
        const data = dateSchedule.toLocaleDateString();
        
        var dateReserver = new Date(`${dateReservation}T00:00:00`);
        const dateConvert = dateReserver.toLocaleDateString();

        if (data === dateConvert && equipments[i].status === 1) {
          notAvalaiable.push(equipments[i].scheduleId);
        }
      }
      setEquipmentNotAvaliable(notAvalaiable);
    }
  }

  return (
    <>
    <div className="equipment-schedule">
      {schedules.map((schedule) => 
        schedule.period === "Manhã" ? (
          <div key={schedule.id}   
            className={`${
              equipmentNotAvaliable.includes(schedule.id) || dateReservation === ''
                ? "schedule-disabled"
                : ""
            }`}
          >
            <div 
              className={`equipment-card 
                  ${checkIsSelected(isSelected, schedule) && !equipmentNotAvaliable.includes(schedule.id) && dateReservation !== ''? 
                    "selected" : "" }`}
                     onClick={() => {
                       if(!equipmentNotAvaliable.includes(schedule.id) && dateReservation !== '')
                        {
                          onSelectSchedules(schedule)
                        }
                      }
                    }>
              <p className="equipment-schedule-period">{schedule.period}</p>
              <p className="equipment-schedule-hourInitial">
                {schedule.hourInitial} - {schedule.hourFinal}
              </p>
            </div>
           </div>
        ) : null
      )}
      
    </div>
    <div className="equipment-schedule">
      {schedules.map((schedule) =>
        schedule.period === "Tarde" ? (
          <div
            key={schedule.id}
            className={`${
              equipmentNotAvaliable.includes(schedule.id) || dateReservation === ''
                ? "schedule-disabled"
                : ""
            }`}
          >
            <div
              className={`equipment-card ${
                checkIsSelected(isSelected, schedule) &&
                !equipmentNotAvaliable.includes(schedule.id) && dateReservation !== ''
                  ? "selected"
                  : ""
              }`}
              onClick={() => {
                if(!equipmentNotAvaliable.includes(schedule.id) && dateReservation !== '')
                 {
                   onSelectSchedules(schedule)
                 }
               }
             }>
              <p className="equipment-schedule-period">{schedule.period}</p>
              <p className="equipment-schedule-hourInitial">
                {schedule.hourInitial} - {schedule.hourFinal}
              </p>
            </div>
          </div>
        ) : null
      )}
    </div>
    <div className="equipment-schedule">
      {schedules.map((schedule) =>
        schedule.period === "Noite" ? (
          <div
            key={schedule.id}
            className={`${
              equipmentNotAvaliable.includes(schedule.id) || dateReservation === ''
                ? "schedule-disabled"
                : ""
            }`}
          >
            <div
              className={`equipment-card ${
                checkIsSelected(isSelected, schedule) &&
                !equipmentNotAvaliable.includes(schedule.id) && dateReservation !== ''
                  ? "selected"
                  : ""
              }`}
              onClick={() => {
                if(!equipmentNotAvaliable.includes(schedule.id) && dateReservation !== '')
                 {
                   onSelectSchedules(schedule)
                 }
               }
             }> 
              <p className="equipment-schedule-period">{schedule.period}</p>
              <p className="equipment-schedule-hourInitial">
                {schedule.hourInitial} - {schedule.hourFinal}
              </p>
            </div>
          </div>
        ) : null
      )}
    </div>
    
    </>
  );
}
