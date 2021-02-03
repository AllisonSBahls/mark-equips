import React, { useEffect, useState } from "react";
import "./styles.css";

import Modal from "../../Components/Modal/Modal";
// import { findById, register, updateEquipments } from "../../Services/equipment";
import { toast } from 'react-toastify';
import { IUsers } from "../Collaborator/types";
import { findById } from "../../Services/equipment";
import { fetchSchedule } from "../../Services/schedule";
import { ISchedule } from "../Schedule/types";
import { checkIsSelected } from "./helpers";
import { ScheduleList } from "./SchedulesList";

 export default function EquipmentReserver({equipmentId, onClickClose}: any ){
  const [schedules, setSchedules] = useState<ISchedule[]>([]);

  const [selectSchedules, setSelectSchedules] = useState<ISchedule[]>([]);


  
  const [collaborators, setColalborators] = useState<IUsers[]>([]);
  const [equipment, setEquipment] = useState('');
  const [user, setUser] = useState('');
  const [date, setDate] = useState('');

  const token = localStorage.getItem('Token')
  const fullName = localStorage.getItem('fullName')!
  const id = localStorage.getItem('id')

  const authorization ={
    headers : {
      Authorization : `Bearer ${token}`
    }
  }

  useEffect(() => {
    loadEquipment();
    fetchScheduleEquipment();
  }, [equipmentId])

  async function reserverEquipment() {
  }

  async function loadEquipment(){
      try{
        if(equipmentId != null){
          const response = await findById(equipmentId, authorization)
          setEquipment(response.data.name)
        }  
    } catch(err){
        toast.error("Erro ao selecionar o equipamento")
      
    } 
  }

  async function fetchScheduleEquipment() {
    try {
      const response = await fetchSchedule(authorization);
      setSchedules(response.data);

    } catch (error) {
      toast.error("Erro ao listar os horarios da manhã" + error);
    }
  }

  const handleSelectSchedules = (schedule : ISchedule) => {
    const isAlreadySelected = checkIsSelected(selectSchedules, schedule);
    if (isAlreadySelected){
      const selected = selectSchedules.filter(item => item.id !== schedule.id);
      setSelectSchedules(selected)
    } else{
      setSelectSchedules(previous => [...previous, schedule]);
    }
  }


  return (
    <>
      <Modal
        isOpen={Boolean(equipmentId)}
        onClickClose={onClickClose}>

        <div className="modal-content">
            <h3 className="modal-title">
              {equipmentId === null
                ? "Novo Equipamento"
                : "Informações do Equipamento"}
            </h3>
            <form onSubmit={reserverEquipment} className="modal-form">
              <div className="modal-input">
              <div className="modal-one-field">
                    <label className="modal-label-field">Usuário: </label>
                    <input className="modal-input-field" disabled defaultValue={fullName}></input>
                </div>
                <div className="modal-two-field">
                  <div className="modal-primary-field">
                    <label className="modal-label-field">Equipamento: </label>
                    <input className="modal-input-field"  defaultValue={equipment}/>
                  </div>
                  <div  className="modal-secondary-field">
                    <label className="modal-label-field">Data da Reserva: </label>
                    <input type="date" className="modal-input-field" defaultValue={date}></input>
                  </div>
                </div>
                <h4 className="equipment-reserver-title">Selecione os horários que desejar e disponiveis para reservar.</h4>
                <div className="equipment-reserver-schedule">

                  <div className="equipment-schedule">
                  {schedules.map((schedules =>  (
                    schedules.period ==="Manhã" ?
                    <ScheduleList
                      key={schedules.id}
                      isSelected={checkIsSelected(selectSchedules, schedules)}
                      onSelectSchedules={handleSelectSchedules}
                      schedule={schedules}
                    />  
                   : null
                  )))}
                  </div>

                  <div className="equipment-schedule">
                    {schedules.map((schedules =>  (
                    schedules.period ==="Tarde" ?
                    <ScheduleList
                      key={schedules.id}
                      isSelected={checkIsSelected(selectSchedules, schedules)}
                      onSelectSchedules={handleSelectSchedules}
                      schedule={schedules}
                    />  
                   : null
                  )))} 
                  </div>

                  <div className="equipment-schedule">
                    {schedules.map((schedules =>  (
                    schedules.period ==="Noite" ?
                    <ScheduleList
                      key={schedules.id}
                      isSelected={checkIsSelected(selectSchedules, schedules)}
                      onSelectSchedules={handleSelectSchedules}
                      schedule={schedules}
                    />  
                   : null
                  )))} 
                  </div>

                </div>
              </div>
              <input
                className="modal-btn-success"
                type="submit"
                value="Reservar">
                </input>
            </form>
        </div>

      </Modal>
    </>
   );
 }
