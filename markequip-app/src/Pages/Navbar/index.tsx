import "./styles.css";
import { FaUserAlt, FaBars } from "react-icons/fa";
import { Link, useHistory } from "react-router-dom";
const userName = localStorage.getItem("fullName");
type props = {
  title: string;
};

export default function Navbar({ title }: props) {
  
  const history = useHistory();


  function logout(){
    localStorage.clear();
    history.push('/')
  }

  return (
    <>
      <nav className="navbar">
      <input type="checkbox" id="check" />

      <label htmlFor="check" className="checkbtn">
          <FaBars />
        </label>
        <label className="navbar-title">Mark Equip</label>

          <ul className="navbar-menu">
            <li> <Link to="/inicio">Inicio </Link></li>
            <li><Link to="/reservas">Reservas</Link></li>
            <li><Link to="/equipamentos">Equipamentos</Link></li>
            <li><Link to="/colaboradores">Colaboradores</Link></li>
            <li><Link to="/horarios">Horários</Link></li>
            <li className="navbar-menu-logout"><a href="/#">Logout</a></li>
          </ul>
          <ul className="navbar-user">
            <li className="navbar-user-name">
              <FaUserAlt />
              <a href="/#">{userName}</a>
            </li>
            <li >
            <a href="/#" className="navbar-user-logout" type="button" onClick={logout}>
             Sair
            </a>
            </li>
          </ul>
      </nav>
      <div className="description-container">
        <h2>Mark Equips - {title}</h2>
      </div>
    </>
  );
}
