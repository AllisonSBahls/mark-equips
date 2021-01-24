import "./styles.css";
import {
  AiFillGithub,
  AiFillLinkedin,
  AiOutlineUser,
  AiFillLock,
} from "react-icons/ai";
export default function Login() {
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
          <form action="" className="form">
            <label className="label-input">
              <AiOutlineUser className="icon-modify" />
              <input type="text" placeholder="Usuário" />
            </label>
            <label className="label-input">
              <AiFillLock />
              <input type="password" placeholder="Senha" />
            </label>
            <button className="btn btn-second">Acessar</button>
          </form>
        </div>
      </div>
    </div>
  );
}
