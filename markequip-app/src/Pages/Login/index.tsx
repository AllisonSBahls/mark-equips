import "./styles.css";
import {useState} from 'react';
import { useHistory } from "react-router-dom";
import {auth} from '../../Services/api';
import { toast } from 'react-toastify';
import {SpinnerLogin} from '../../Components/Loading/index'
import {  AiFillGithub,  AiFillLinkedin,  AiOutlineUser,  AiFillLock} from "react-icons/ai";

export default function Login() {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const history = useHistory();

  async function login(e: React.FormEvent){
    e.preventDefault();
    const data = {
      userName,
      password,
    };
    
    try{
      setIsLoading(true);
      const  response = await auth(data);
        localStorage.setItem('userName', userName);
        localStorage.setItem('Token', response.data.token);
        localStorage.setItem('fullName', response.data.fullName);
        localStorage.setItem('id', response.data.id);
        history.push('/inicio');

    }catch(error){
      setIsLoading(false);
      toast.error('Usuário ou Senha Inválidos, tente novamente')
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
            {isLoading ? (
            <button type="submit" className="btn btn-second">
            <SpinnerLogin /> Acessando 
            </button> 
              ) : (
                <button type="submit" className="btn btn-second">
                 Acessar
                </button>
              )}
          </form>
        </div>
      </div>
    </div>
  );
}
