import React, { useEffect, useState } from "react";
import "./styles.css";

import Modal from "../../Components/Modal/Modal";
// import { findById, register, updateEquipments } from "../../Services/equipment";
import { toast } from 'react-toastify';

 export default function EquipmentReserver({equipmentId, onClickClose}){

  async function reserverEquipment() {
    
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
                    <input className="modal-input-field"/>
                  </div>
                  <div  className="modal-primary-field">
                    <label className="modal-label-field">Colaborador: </label>
                    <input className="modal-input-field"></input>
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
