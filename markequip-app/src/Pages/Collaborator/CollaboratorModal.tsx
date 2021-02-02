import React, { useEffect, useState } from "react";
import { toast } from "react-toastify";
import "./styles.css";

import {register, findById, updateCollaborator} from "../../Services/collaborator";
import Modal from "../../Components/Modal/Modal";

export default function CollaboratorModal({
  collaboratorId,
  onClickClose,
  openModal,
}: any) {
  const [id, setId] = useState(null);
  const [fullName, setFullName] = useState("");
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("");

  const token = localStorage.getItem("Token");
  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  useEffect(() => {
    if (openModal || collaboratorId === null) openFormsRegister();
    else loadCollaborator();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [collaboratorId]);

  async function loadCollaborator() {
    try {
      const response = await findById(collaboratorId, authorization);
      setId(response.data.id);
      setFullName(response.data.fullName);
      setUserName(response.data.userName);
      setRole(response.data.role);
    } catch (err) {
      alert("Erro ao carregar o colaborador");
    }
  }

  async function openFormsRegister() {
    try {
      setId(null);
      setFullName("");
      setUserName("");
      setPassword("");
      setRole("");
    } catch (err) {
      alert("Erro ao abrir o formulário de registro");
    }
  }

  async function saveCollaborator(e: any) {
    e.preventDefault();
    try {
      if (collaboratorId === null) {
        const data = {
          fullName,
          userName,
          password,
          role,
        };
        await register(data, authorization);
        toast.success("Colaborador cadastrado com sucesso");
      } else {
        const data = {
          fullName,
          userName,
          password,
          role,
          id: id,
        };
        await updateCollaborator(data, authorization);
        toast.success("Colaborador alterado com sucesso");
      }
      onClickClose();
    } catch (err) {
      toast.error("Erro ao salvar o colaborador");
    }
  }

  function onValueChange(event: any) {
    setRole(event.target.value);
  }
  
  return (
    <>
      <Modal
        isOpen={Boolean(collaboratorId) || openModal}
        onClickClose={onClickClose}>
        <div className="register-container">
          <div className="register">
            <h3 className="subtitle">
              {collaboratorId === null
                ? "Registrar Colaborador"
                : "Informações do Colaborador"}
            </h3>
            <form onSubmit={saveCollaborator} className="form-collaborator">
              <div className="collaborator">
                <div className="input-field input-name">
                  <label>Nome: </label>
                  <input
                    value={fullName}
                    onChange={(e) => setFullName(e.target.value)}
                    type="text"
                    className="input"
                    placeholder="Insira o nome completo"
                  ></input>
                </div>
                <div className="user">
                  <div className="input-field input-user">
                    <label>Usuário: </label>
                    <input
                      value={userName}
                      onChange={(e) => setUserName(e.target.value)}
                      type="text"
                      className="input"
                      placeholder="Insira o usuário"
                    ></input>
                  </div>
                  <div className="input-field input-password">
                    <label>Senha: </label>
                    <input
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      type="password"
                      disabled ={collaboratorId === null ? false : true}
                      className="input"
                      placeholder="Insira a senha"
                    ></input>
                  </div>
                </div>
              </div>
              <div className="roles">
                <h4>Função</h4>
                <div className="radio">
                  {collaboratorId === null ? (
                    <>
                      <label>Colaborador</label>
                      <input
                        type="radio"
                        name="role"
                        value="collaborator"
                        checked={role === "collaborator"}
                        onChange={onValueChange}
                      />
                      <label>Administrador</label>
                      <input
                        type="radio"
                        name="role"
                        value="administrator"
                        checked={role === "administrator"}
                        onChange={onValueChange}
                      />
                    </>
                  ) : (
                    <input
                      value={role}
                      onChange={(e) => setRole(e.target.value)}
                      type="text"
                      disabled
                      className="input"
                      placeholder="Insira o nome completo"
                    ></input>
                  )}
                </div>
              </div>
              <div className="form-button">
                <input
                  type="submit"
                  className="button-save"
                  value={collaboratorId === null ? "Salvar" : "Atualizar"}
                ></input>
              </div>
            </form>
          </div>
        </div>
      </Modal>
    </>
  );
}
