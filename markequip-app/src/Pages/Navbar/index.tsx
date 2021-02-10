import "./styles.css";
import { FaUserAlt, FaBars } from "react-icons/fa";
const userName = localStorage.getItem("fullName");
type props = {
  title: string;
};

export default function Navbar({ title }: props) {
  return (
    <>
      <nav className="navbar">
      <input type="checkbox" id="check" />

      <label htmlFor="check" className="checkbtn">
          <FaBars />
        </label>
        <label className="navbar-title">Mark Equip</label>

          <ul className="navbar-menu">
            <li> <a href="/#">Inicio </a></li>
            <li><a href="/#">Reservas</a></li>
            <li><a href="/#">Equipamentos</a></li>
            <li><a href="/#">Colaboradores</a></li>
            <li><a href="/#">Horários</a></li>
            <li className="navbar-menu-logout"><a href="/#">Logout</a></li>
          </ul>
          <ul className="navbar-user">
            <li className="navbar-user-name">
              <FaUserAlt />
              <a href="/#">{userName}Allison Sousa Bahls</a>
            </li>
            <li>
              <FaUserAlt />
              <a href="/#">{userName} Sair</a>
            </li>
          </ul>
      </nav>
      <div className="description-container">
        <h2>Mark Equips - {title}</h2>
      </div>
    </>
  );
}
