import React, { useEffect, useState } from "react";
import "./styles.css";

import Modal from "../../Components/Modal/Modal";
// import { findById, register, updateEquipments } from "../../Services/equipment";
import { toast } from 'react-toastify';
import { IUsers } from "../Collaborator/types";
import { findById } from "../../Services/equipment";

 export default function EquipmentReserver({equipmentId, onClickClose}){

  const [collaborators, setColalborators] = useState<IUsers[]>([]);
  const [equipment, setEquipment] = useState('');
  const [user, setUser] = useState('');
  const [date, setDate] = useState('');
  const [schedules, Schedules] = useState([]);

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
  })

  async function reserverEquipment() {
  }

  async function loadEquipment(){
    if(equipmentId != null){
      try{
      const response = await findById(equipmentId, authorization)
      setEquipment(response.data.name)
      } catch(err){
        toast.error("Erro ao selecionar o equipamento")
      }
    } 
  }

  async function loadColaborator(){
  }

  async function fetchCollaborators(){
  }

  async function loadSchedulesAvaliableForEquipment(){
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
                <div className="modal-two-field">
                  <div className="modal-primary-field">
                    <label className="modal-label-field">Equipamento: </label>
                    <input className="modal-input-field" defaultValue={equipment}/>
                  </div>
                  <div  className="modal-secondary-field">
                    <label className="modal-label-field">Colaborador: </label>
                    <input className="modal-input-field" defaultValue={fullName}></input>
                  </div>
                </div>
                <h4 className="equipment-reserver-title">Selecione todos horários que desejar para reservar o equipamento</h4>
                <div className="equipment-reserver-schedule">
                  <div className="equipment-schedule">
                    <div className="equipment-card schedule-morning">
                      <p className="equipment-schedule-period">Manhã</p>
                      <p className="equipment-schedule-hourInitial">08:00 - 09:00</p>
                    </div>
                  </div>
                  <div className="equipment-schedule">
                    <div className="equipment-card schedule-afternoon">
                      <p className="equipment-schedule-period">Tarde</p>
                      <p className="equipment-schedule-hourInitial">13:00 - 14:00</p>
                    </div>
                  </div>
                  <div className="equipment-schedule">
                    <div className="equipment-card schedule-night">
                      <p className="equipment-schedule-period">Noite</p>
                      <p className="equipment-schedule-hourInitial">22:00 - 24:00</p>
                    </div>
                  </div>
                </div>

              </div>
              <input
                className="modal-btn-success"
                type="submit"
                value={equipmentId === null ? "Salvar" : "Atualizar"}>
                </input>
            </form>
        </div>

      </Modal>
    </>
   );
 }
