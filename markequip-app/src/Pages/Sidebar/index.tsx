import "./styes.css";

import { FaBars, FaTimes, FaQrcode, FaBookmark } from "react-icons/fa";
import { BsPeopleFill } from "react-icons/bs";
import { RiProjector2Fill } from "react-icons/ri";
import { AiFillSchedule } from "react-icons/ai";



export default function Sidebar() {
  return (
    <>
      <input type="checkbox" id="check"></input>
      <label htmlFor="check">
        <i id="btn">
          <FaBars />
        </i>
        <i id="cancel">
          <FaTimes/>
        </i>
      </label>
      <div className="sidebar">
        <header>Dashboard</header>
        <a href="/#" >
          <i>
            <FaQrcode />
          </i>
          <span>Inicio</span>
        </a>
        <a href="/#">
          <i>
            {" "}
            <FaBookmark />
          </i>
          <span>Reservas</span>
        </a>
        <a href="/#">
          <i>
            <RiProjector2Fill />
          </i>
          <span>Equipamentos</span>
        </a>
        <a href="/#">
          <i>
            <BsPeopleFill />
          </i>
          <span>Colaboradores</span>
        </a>
        <a href="/#">
          <i>
            <AiFillSchedule />
          </i>
          <span>Horários</span>
        </a>

      </div>
    </>
  );
}
