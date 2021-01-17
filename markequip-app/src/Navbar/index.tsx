import './styles.css'
import { FiEdit } from 'react-icons/fi';
import { FaUserAlt } from 'react-icons/fa';


import {ReactComponent as Logo} from './Logo.svg';
export default function Navbar() {
    return (
        <>
            <nav className="main-navbar">
                <h1 className="text-main-navbar">Mark Equip</h1>
                <ul className="menu-main-navbar">
                    <li>
                        <a href="/#">Ínicio</a>
                    </li>
                    <li>
                        <a href="/#">Reservas</a>
                    </li>
                    <li>
                        <a href="/#">Equipamentos</a>
                    </li>
                    <li>
                        <a href="/#">Colaboradores</a>
                    </li>
                    <li>
                        <a href="/#">Horários</a>
                    </li>
                    <li>
                        <a href="/#">Relatórios</a>
                    </li>

                </ul>
                <div className="user-navbar">
                <ul >
                    <li>
                        <FaUserAlt/><a href="/#">Allison Bahls</a>

                    </li>

                </ul>
                </div>
            </nav>
            <div className="description-container">
                <Logo />
                <h1>Mark Equips -  Reservar de Equipamentos e Laboratórios</h1>
                <a className="btn-make-reserver" href="/#">
                        <FiEdit className="icon-btn-reserver"/>Fazer uma reserva</a>
            </div>
        </>
    )
}