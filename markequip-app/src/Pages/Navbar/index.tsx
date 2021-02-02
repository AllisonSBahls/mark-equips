import './styles.css'
import { FaUserAlt } from 'react-icons/fa';
const userName = localStorage.getItem('userName');

export default function Navbar() {
    return (
        <>
            <nav className="main-navbar">
                <h1 className="text-main-navbar">Mark Equip</h1>
               
                <div className="user-navbar">
                <ul >
                    <li>
                        <FaUserAlt/><a href="/#">{userName?.toUpperCase()}</a>
                    </li>

                </ul>
                </div>
            </nav>
            <div className="description-container">
                <h1>Mark Equips -  Reservar de Equipamentos e Laboratórios</h1>
            </div>
        </>
    )
}