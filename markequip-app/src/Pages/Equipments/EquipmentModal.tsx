import React, { useEffect, useState } from "react";
import "./styles.css";

import Modal from "../../Components/Modal/Modal";
import { findById, register, updateEquipments } from "../../Services/equipment";
import { toast } from 'react-toastify';

export default function EquipmentModal({
  equipmentId,
  openModal,
  onClickClose,
}: any) {
  const [id, setId] = useState(null);
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [number, setNumber] = useState('');

  
  const token = localStorage.getItem("Token");
  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };


  useEffect(() => {
    if (openModal || equipmentId === null) openFormsRegister();
    else loadEquipment();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [equipmentId]);

  async function loadEquipment() {
    try {
      const response = await findById(equipmentId, authorization);
      setId(response.data.id);
      setName(response.data.name);
      setDescription(response.data.description);
      setNumber(response.data.number);
    } catch (err) {
      alert("Erro ao carregar o colaborador");
    }
  }

  async function openFormsRegister() {
    try {
      setId(null);
      setName('');
      setDescription('');
      setNumber('');
    } catch (err) {
      alert("Erro ao abrir o formulário de registro");
    }
  }

  async function saveEquipment(e: any) {
    e.preventDefault();
    try {
      if (equipmentId === null) {
        const data = {
          name,
          description,
          number,
        };
        await register(data, authorization);
        toast.success("Equipamento cadastrado com sucesso");
      } else {
        const data = {
          name,
          description,
          number,
          id: id,
        };
        await updateEquipments(data, authorization);
        toast.success("Equipamento alterado com sucesso");
      }
      onClickClose();
    } catch (err) {
      toast.error("Erro ao salvar o colaborador");
    }
  }

  return (
    <>
      <Modal
        isOpen={Boolean(equipmentId) || openModal}
        onClickClose={onClickClose}>

        <div className="modal-content">
            <h3 className="modal-title">
              {equipmentId === null
                ? "Novo Equipamento"
                : "Informações do Equipamento"}
            </h3>
            <form onSubmit={saveEquipment} className="modal-form">
              <div className="modal-input">
                <div className="modal-two-field">
                  <div className="modal-primary-field">
                    <label className="modal-label-field">Nome: </label>
                    <input className="modal-input-field" value={name} onChange={(e) => setName(e.target.value)}></input>
                  </div>
                  <div  className="modal-secondary-field">
                    <label className="modal-label-field">Tombo: </label>
                    <input className="modal-input-field" value={number} onChange={(e) => setNumber(e.target.value)}></input>
                  </div>
                </div>
                <div className="modal-one-field">
                    <label className="modal-label-field">Description: </label>
                    <textarea className="modal-textarea-field modal-input-field" 
                    value={description} 
                    onChange={(e) => setDescription(e.target.value)}></textarea>
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
