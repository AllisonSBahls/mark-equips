import {useState} from 'react';
import {useHistory} from 'react-router-dom';

import "./styles.css";

import Footer from "../Footer";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";

import {register} from "../../Services/collaborator"

export default function Register(){

  const[fullName, setFullName] = useState('');
  const[userName, setUserName] = useState('');
  const[password, setPassword] = useState('');
  const[role, setRole] = useState('');

  const history = useHistory();

  async function createNewCollaborator(e:any){
    e.preventDefault();

    const data ={
      fullName,
      userName,
      password,
      role,
    }
    const token = localStorage.getItem('Token');

    try{
      await register(data, {
        headers:{
          Authorization: `Bearer ${token}`
        }
      });
      history.push('/colaboradores');
    }
    catch (err){
      alert("Usuário já existe")
    }

  }

    return(
        <>
        <Navbar />
        <Sidebar/>
        
        <div className="background-effect">
        </div>
        <div className="register-container">
        <div className="register">
          <h3 className="subtitle">Registrar Colaborador</h3>
          <form onSubmit={createNewCollaborator} className="form-collaborator">
            <div className="collaborator">
              <div className="input-field input-name">
                <label>Nome: </label>
                <input
                  value={fullName}
                  onChange={e => setFullName(e.target.value)}
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
                  onChange={e => setUserName(e.target.value)}
                  type="text"
                  className="input"
                  placeholder="Insira o usuário"
                ></input>
              </div>
              <div className="input-field input-password">
                <label>Senha: </label>
                <input
                  value={password}
                  onChange={e => setPassword(e.target.value)}
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
                <label>Colaborador</label>
                <input
                  type="radio"
                  id="collaborator"
                  name="role"
                  value="collaborator"
                  onChange={e => setRole('collaborator')}
                />
                <label>Administrador</label>
                <input
                  type="radio"
                  id="administrator"
                  name="role"
                  value="administrator"
                  onChange={e => setRole('administrator')}
                />
              </div>
            </div>
            <div className="form-button">
              <input type="submit" className="button-save" value="Salvar"></input>
            </div>
          </form>
        </div>
      </div>
     <Footer />
    </>
    );
}
