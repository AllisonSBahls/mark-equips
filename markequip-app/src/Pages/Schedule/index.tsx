/* eslint-disable @typescript-eslint/no-array-constructor */
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import Navbar from "../Navbar";
import { ISchedule } from "./types";

import "./styles.css";
import { BiAddToQueue } from "react-icons/bi";
import { fetchSchedule } from "../../Services/schedule";
import ScheduleList from "./ScheduleList";
import ScheduleModal from "./ScheduleModal";

export default function Schedule() {
  const [schedulesMorning, setschedulesMorning] = useState<ISchedule[]>([]);
  const [schedulesAfternoon, setschedulesAfternoon] = useState<ISchedule[]>([]);
  const [schedulesNight, setschedulesNight] = useState<ISchedule[]>([]);
  const [scheduleId, setScheduleId] = useState(0);
  const [openModal, setOpenModal] = useState(false);
  const [refresh, setRefresh] = useState(0);

  let morning = new Array();
  let afternoon = new Array();
  let night = new Array();
  const token = localStorage.getItem("Token");

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  useEffect(() => {
    findSchedules();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, refresh]);

  async function findSchedules() {
    try {
      const response = await fetchSchedule(authorization);
      for(let i =0; i < response.data.length; i++){
        if(response.data[i].period === "Manhã"){
          morning.push(response.data[i]);
        }
        if(response.data[i].period === "Tarde"){
          afternoon.push(response.data[i]);
        }
        if(response.data[i].period === "Noite"){
          night.push(response.data[i]);
        }
      }
      setschedulesMorning(morning);
      setschedulesAfternoon(afternoon);
      setschedulesNight(night);

    } catch (error) {
      toast.error("Erro ao listar os horarios da manhã" + error);
    }
  }

  return (
    <>
      <Navbar title={"Horários"}/>
      <div className="container-schedule">
        <div className="conenet-schedule">
          <div className="btn-insert-field">
            <button onClick={()=>setOpenModal(true)} className="btn-insert" >
              <BiAddToQueue className="icon" />
              Inserir Horario
            </button>
          </div>
        </div>
          <ScheduleList 
          morning={schedulesMorning}
          afternoon={schedulesAfternoon}
          night={schedulesNight}
          onClickInfo={setScheduleId}
          onClickOpenModal={setOpenModal}/>
      </div>

        <ScheduleModal
          scheduleId={scheduleId}
          openModal={openModal}
          refresh = {setRefresh}
          onClickClose={() => [setScheduleId(0), setOpenModal(false)]}
          />

    </>
  );
}