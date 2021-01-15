import './styles.css'
import {ReactComponent as Logo} from './Logo.svg';
export default function Navbar() {
    return (
        <>
            <nav className="main-navbar">
                <h1 className="text-main-navbar">Mark Equip</h1>
                <ul className="menu-main-navbar">
                    <li>
                        <a href="#">Ínicio</a>
                    </li>
                    <li>
                        <a href="#">Equipamentos</a>
                    </li>
                    <li>
                        <a href="#">Reservas</a>
                    </li>
                    <li>
                        <a href="#">Gerenciar</a>
                    </li>
                    <li>
                        <a href="#">Relatórios</a>
                    </li>
                </ul>
            </nav>
            <div className="description-container">
                <Logo />
                <h1>Mark Equips -  Reservar de Equipamentos e Laboratórios</h1>
            </div>
        </>
    )
}