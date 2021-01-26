import './styles.css'
import { FiEdit } from 'react-icons/fi';
import { FaUserAlt } from 'react-icons/fa';

import {ReactComponent as Logo} from './Logo.svg';
export default function Navbar() {
    return (
        <>
            <nav className="main-navbar">
                <h1 className="text-main-navbar">Mark Equip</h1>
               
                <div className="user-navbar">
                <ul >
                    <li>
                        <FaUserAlt/><a href="/#">Allison Bahls</a>

                    </li>

                </ul>
                </div>
            </nav>
            <div className="description-container">
                <Logo className="icon-logo"/>
                <h1>Mark Equips -  Reservar de Equipamentos e Laboratórios</h1>
            </div>
        </>
    )
}