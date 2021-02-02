import React, { useEffect, useState } from "react";
import "./styles.css";

import Modal from "../../Helpers/Modal/Modal";
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
    else loadCollaborator();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [equipmentId]);

  async function loadCollaborator() {
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

  async function saveCollaborator(e: any) {
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
        onClickClose={onClickClose}
      >
        <div className="register-container">
          <div className="register">
            <h3 className="subtitle">
              {equipmentId === null
                ? "Registrar Colaborador"
                : "Informações do Colaborador"}
            </h3>
            <form onSubmit={saveCollaborator} className="form-collaborator">
              <div className="collaborator">
                <div className="input-field input-name">
                  <div className="user">
                  <div className="input-field input-user">
                    <label>Nome: </label>
                    <input
                      value={name}
                      onChange={(e) => setDescription(e.target.value)}
                      type="text"
                      className="input"
                      placeholder="Insira o usuário"
                    ></input>
                  </div>
                  <div className="input-field input-password">
                    <label>Tombo: </label>
                    <input
                      value={number}
                      onChange={(e) => setNumber(e.target.value)}
                      type="text"
                      disabled={equipmentId === null ? false : true}
                      className="input"
                      placeholder="Insira a senha"
                    ></input>
                  </div>
                </div>
                <label>Descrição: </label>
                  <textarea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    className="input"
                    placeholder="Insira o nome completo"
                  ></textarea>
                </div>
              </div>
              <div className="form-button">
                <input
                  type="submit"
                  className="button-save"
                  value={equipmentId === null ? "Salvar" : "Atualizar"}
                ></input>
              </div>
            </form>
          </div>
        </div>
      </Modal>
    </>
  );
}
