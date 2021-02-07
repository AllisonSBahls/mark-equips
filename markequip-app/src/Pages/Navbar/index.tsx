import "./styles.css";
import { FaUserAlt } from "react-icons/fa";
const userName = localStorage.getItem("FullName");
type props = {
  title: string;
};

export default function Navbar({ title }: props) {
  return (
    <>
      <nav className="navbar">
        <h1 className="navbar-title">Mark Equip</h1>

        <div className="navbar-menu">
          <ul>
            <a href="/#">
              <li>Inicio</li>
            </a>
            <a href="/#">
              <li>Reservas</li>
            </a>
            <a href="/#">
              <li>Equipamentos</li>
            </a>
            <a href="/#">
              <li>Colaboradores</li>
            </a>
            <a href="/#">
              <li>Horários</li>
            </a>
          </ul>
        </div>
        <div className="user-navbar">
          <ul>
            <li>
              <FaUserAlt />
              <a href="/#">{userName?.toUpperCase()}</a>
            </li>
          </ul>
        </div>
      </nav>
      <div className="description-container">
        <h2>Mark Equips - {title}</h2>
      </div>
    </>
  );
}
