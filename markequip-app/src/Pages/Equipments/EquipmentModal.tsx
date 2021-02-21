import React, { useEffect, useState } from "react";
import "./styles.css";

import Modal from "../../Components/Modal/Modal";
import { findById, register, updateEquipments } from "../../Services/equipment";
import { toast } from "react-toastify";
import {SpinnerLoading} from "../../Components/Loading/index"
import { IEquipment } from "./types";
type Props = {
  equipmentId: number;
  openModal: boolean;
  onClickClose: () => void;
  setRefresh: (refresh: number) => void;
};

export default function EquipmentModal({
  equipmentId,
  openModal,
  onClickClose,
  setRefresh
}: Props) {
  const [id, setId] = useState(0);
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [number, setNumber] = useState("");
  const [isLoadingSave, setIsLoadingSave] = useState(false);
  const [saveRefresh, setSaveRefresh] = useState(1);
  const token = localStorage.getItem("Token");
  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  useEffect(() => {
    if (openModal || equipmentId === 0) openFormsRegister();
    else loadEquipment();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [equipmentId]);

  async function loadEquipment() {
      try {    
        if (equipmentId !== 0) {
          const response = await findById(equipmentId, authorization);
          setId(response.data.id);
          setName(response.data.name);
          setDescription(response.data.description);
          setNumber(response.data.number);
        }
      } catch (err) {
        alert("Erro ao carregar o colaborador");
      }
    }


  async function openFormsRegister() {
    try {
      setId(0);
      setName("");
      setDescription("");
      setNumber("");
    } catch (err) {
      alert("Erro ao abrir o formulário de registro");
    }
  }

  async function saveEquipment(e: React.FormEvent) {
    e.preventDefault();
    var intNumber: number = +number;
    try {
      if (equipmentId === 0) {
        const data: IEquipment = {
          name,
          description,
          number: intNumber,
          id: id
        };
        setIsLoadingSave(true);
        await register(data, authorization);
        setSaveRefresh(saveRefresh+1);
        toast.success("Equipamento cadastrado com sucesso");
      
      } else {
        const data: IEquipment = {
          name,
          description,
          number: intNumber,
          id: id,
        };
        setIsLoadingSave(true);
        await updateEquipments(data, authorization);
        toast.success("Equipamento alterado com sucesso");
        setSaveRefresh(saveRefresh+1);
      }
      setRefresh(saveRefresh)
      onClickClose();
      setIsLoadingSave(false);
    } catch (err) {
      setIsLoadingSave(false);
      toast.error("Erro ao salvar o colaborador");
    }
  }

  return (
    <>
      <Modal
        isOpen={Boolean(equipmentId) || openModal}
        onClickClose={onClickClose}
      >
        <div className="modal-content">
          <h3 className="modal-title">
            {equipmentId === 0
              ? "Novo Equipamento"
              : "Informações do Equipamento"}
          </h3>
          <form onSubmit={saveEquipment} className="modal-form">
            <div className="modal-input">
              <div className="modal-two-field">
                <div className="modal-primary-field">
                  <label className="modal-label-field">Nome: </label>
                  <input
                    className="modal-input-field"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                  ></input>
                </div>
                <div className="modal-secondary-field">
                  <label className="modal-label-field">Tombo: </label>
                  <input
                    className="modal-input-field"
                    value={number}
                    onChange={(e) => setNumber(e.target.value)}
                  ></input>
                </div>
              </div>
              <div className="modal-one-field">
                <label className="modal-label-field">Description: </label>
                <textarea
                  className="modal-textarea-field modal-input-field"
                  value={description}
                  onChange={(e) => setDescription(e.target.value)}
                ></textarea>
              </div>
            </div>
            {isLoadingSave ?
                (
                  <button className="modal-btn-success" disabled>
                {equipmentId === 0 ? "Salvando" : "Atualizando"} <SpinnerLoading /> </button>)
                 : (   <button className="modal-btn-success">
                {equipmentId === 0 ? "Salvar" : "Atualizar"}</button>)
                }
          </form>
        </div>
      </Modal>
    </>
  );
}
