import React, { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";

import "./styles.css";

import Footer from "../Footer";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";

import { register, findById, updateCollaborator } from "../../Services/collaborator";

export default function Register() {
  const [id, setId] = useState(null);
  const [fullName, setFullName] = useState('');
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('');

  const {collaboratorId} = useParams<any>();
  const history = useHistory();
  const token = localStorage.getItem("Token");
  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  useEffect(() => {
    if (collaboratorId === '0') return;
    else loadCollaborator();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, collaboratorId);

  async function loadCollaborator() {
    try {
      const response = await findById(
        collaboratorId,
        authorization
      );
      setId(response.data.id);
      setFullName(response.data.fullName);
      setUserName(response.data.userName);
      setRole(response.data.role);

    } catch (err) {
      alert("Erro ao carregar o colaborador");
      history.push("/colaboradores");
    }
  }

  async function saveCollaborator(e: any) {
    e.preventDefault();

    const data = {
      fullName,
      userName,
      password,
      role,
      id
    };

    try {
      if(collaboratorId === '0'){
        await register(data, authorization);
      }else{
        data.id = id;
        await updateCollaborator(data, authorization)
      }
      history.push("/colaboradores");
    } catch (err) {
      alert("Usuário já existe");
    }
  }

  function RoleCheck() {
    if (role === "Administrator")
      return (
        <>
          <label>Colaborador</label>
          <input
            type="radio"
            id="collaborator"
            name="role"
            value="collaborator"
            onChange={(e) => setRole("collaborator")}
          />
          <label>Administrador</label>
          <input
            type="radio"
            id="administrator"
            checked={true}
            name="role"
            value="administrator"
            onChange={(e) => setRole("administrator")}
          />
        </>
      );
    return(
      <>
      <label>Colaborador</label>
                <input
                  type="radio"
                  checked={true}
                  id="collaborator"
                  name="role"
                  value="collaborator"
                  onChange={e => setRole('collaborator')}/>
                <label>Administrador</label>
                <input
                  type="radio"
                  id="administrator"
                  name="role"
                  value="administrator"
                  onChange={e => setRole('administrator')}/> 
      </>
    )
  }

  return (
    <>
      <Navbar />
      <Sidebar />

      <div className="background-effect"></div>
      <div className="register-container">
        <div className="register">
          <h3 className="subtitle">{collaboratorId === '0' ? 'Registrar Colaborador' : 'Informações do Colaborador'}</h3>
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
                    className="input"
                    placeholder="Insira a senha"
                  ></input>
                </div>
              </div>
            </div>
            <div className="roles">
              <h4>Função</h4>
              <div className="radio">
                <RoleCheck />
              </div>
            </div>
            <div className="form-button">
              <input
                type="submit"
                className="button-save"
                value={collaboratorId === '0' ? 'Salvar' : 'Atualizar'}
              ></input>
            </div>
          </form>
        </div>
      </div>
      <Footer />
    </>
  );
}
