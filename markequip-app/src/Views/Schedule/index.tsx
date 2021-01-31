/* eslint-disable @typescript-eslint/no-array-constructor */
import { useEffect, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { toast } from "react-toastify";
import Navbar from "../Navbar";
import Footer from "../Footer";
import Sidebar from "../Sidebar";
import { ISchedule } from "./types";

import "./styles.css";
import { AiFillEdit, AiFillDelete } from "react-icons/ai";
import { BiAddToQueue } from "react-icons/bi";
import { fetchSchedule } from "../../Services/schedule";

export default function Schedule() {
  const [schedulesMorning, setschedulesMorning] = useState<ISchedule[]>([]);
  const [schedulesAfternoon, setschedulesAfternoon] = useState<ISchedule[]>([]);
  const [schedulesNight, setschedulesNight] = useState<ISchedule[]>([]);
  
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
  }, [token]);

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
      <Navbar />
      <Sidebar />
      <div className="container-schedule">
        <div className="conenet-schedule">
          <div className="btn-insert-field">
            <Link to="Horário form/0" className="btn-insert">
              <BiAddToQueue className="icon" />
              Inserir Horario
            </Link>
          </div>
        </div>
        <div className="content-schedule">
          <div className="table-content">
            <h3>
              Horários: Manha
              <button className="btn-schedule btn-insert-schedule">
                <BiAddToQueue className="icon" />
              </button>
            </h3>
            <table className="table-schedule table-schedule-responsive">
              <thead>
                <tr >
                  <th>Inicio</th>
                  <th>Final</th>
                  <th>Ações</th>
                </tr>
              </thead>
              
              <tbody>
              {schedulesMorning.map((schedule) => (
                <tr key={schedule.id}>
                  <td>{schedule.hourInitial}</td>
                  <td>{schedule.hourFinal}</td>
                  <td>
                    <button className="btn-schedule btn-edit">
                      <AiFillEdit className="icon" />
                    </button>
                    <button className="btn-schedule btn-delete">
                      <AiFillDelete className="icon" />
                    </button>
                  </td>
                </tr>
                ))}
              </tbody>
              </table>
          </div>

       
          <div className="table-content">
            <h3>
              Horários: Tarde
              <button className="btn-schedule btn-insert-schedule">
                <BiAddToQueue className="icon" />
              </button>
            </h3>
            <table className="table-schedule table-schedule-responsive">
              <thead>
                <tr>
                  <th>Inicial</th>
                  <th>Final</th>
                  <th>Ações</th>
                </tr>
              </thead>
              <tbody>
              {schedulesAfternoon.map((schedule) => (
                <tr key={schedule.id}>
                  <td>{schedule.hourInitial}</td>
                  <td>{schedule.hourFinal}</td>
                  <td>
                    <button className="btn-schedule btn-edit">
                      <AiFillEdit className="icon" />
                    </button>
                    <button className="btn-schedule btn-delete">
                      <AiFillDelete className="icon" />
                    </button>
                  </td>
                </tr>
                ))}
              </tbody>
            </table>
          </div>
          <div className="table-content">
            <h3>
              Horário: Noite
              <button className="btn-schedule btn-insert-schedule">
                <BiAddToQueue className="icon" />
              </button>
            </h3>
            <table className="table-schedule table-schedule-responsive">
              <thead>
                <tr>
                  <th>Inicial</th>
                  <th>Final</th>
                  <th>Ações</th>
                </tr>
              </thead>
              <tbody>
              {schedulesNight.map((schedule) => (
                <tr key={schedule.id}>
                  <td>{schedule.hourInitial}</td>
                  <td>{schedule.hourFinal}</td>
                  <td>
                    <button className="btn-schedule btn-edit">
                      <AiFillEdit className="icon" />
                    </button>
                    <button className="btn-schedule btn-delete">
                      <AiFillDelete className="icon" />
                    </button>
                  </td>
                </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </>
  );
}
