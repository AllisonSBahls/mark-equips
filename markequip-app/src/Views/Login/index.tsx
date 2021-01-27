import "./styles.css";
import {useState} from 'react';
import { useHistory } from "react-router-dom";
import {api} from '../../Services/Api';

import {  AiFillGithub,  AiFillLinkedin,  AiOutlineUser,  AiFillLock} from "react-icons/ai";

export default function Login() {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const history = useHistory();

  async function login(e: React.FormEvent){
    e.preventDefault();
    const data = {
      userName,
      password,
    };
    
    try{
      const  response = await api.post('api/v1/auth/login', data);
        localStorage.setItem('userName', userName);
        localStorage.setItem('Token', response.data.token);
        history.push('/colaboradores');

    }catch(error){
      alert('Erro ao logar, tente novamente')
    }
}

  return (
    <div className="container">
      <div className="content first-content">
        <div className="first-column">
          <h2 className="title title-primary">Mark Equips</h2>
          <p className="description description-primary">
            Reservas de Equipamentos e Laboratórios
          </p>
          <p className="description">Contatos</p>
          <div className="social-media">
            <ul className="list-social-media">
              <a className="link-social-media" href="/#">
                <li className="item-social-media">
                  <AiFillGithub />
                </li>
              </a>

              <a className="link-social-media" href="/#">
                <li className="item-social-media">
                  <AiFillLinkedin />
                </li>
              </a>
            </ul>
          </div>
        </div>
        <div className="second-column">
          <h2 className="title title-secundary">Sign In</h2>
          <p className="description description-second">
            Acesse com seu usuário e senha
          </p>
          <form onSubmit={login} className="form">
           
            <label className="label-input">
              <AiOutlineUser className="icon-modify" />
              <input 
                type="text" 
                placeholder="Usuário" 
                value={userName}
                onChange={e => setUserName(e.target.value)}/>
            </label>
           
            <label className="label-input">
              <AiFillLock />
              <input 
                type="password" 
                placeholder="Senha" 
                value={password}
                onChange={e => setPassword(e.target.value)}/>
            </label>
           
            <button type="submit" className="btn btn-second">
              Acessar
            </button>
          </form>
        </div>
      </div>
    </div>
  );
}
