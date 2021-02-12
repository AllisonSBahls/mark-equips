import { Link } from "react-router-dom";
import Footer from "../Footer";
import Navbar from "../Navbar";
import ReservationsList from "../Reservations/ReserverList";

import "./styles.css";

export default function Home() {

  const name = localStorage.getItem("fullName");
  const role = localStorage.getItem("role")

  return (
    <>
      <Navbar title={"Reserva de Equipamentos e Laboratórios"} />
      <div className="home-container">
        <div className="home-content">

          <div className="home-user">
            <div className="home-user-info">
              <p>Bem vindo {name} ao painel de {role === "Administrator" ? 'Administrador' : 'Colaborador'} do Mark Equips.
              </p>
              <p>Voce pode gerenciar as reservas solicitadas pelos colaboradores, bem como gerenciar equipamentos, horários
                  e colaboradores</p>
            </div>
          </div>
          <div className="home-btn">
            <Link to="/equipamentos" className="home-btn-reserve">
             Reserva Equipamento</Link>
            <Link to="/reservas" className="home-btn-reserved">Ver todas de Reservas</Link>
          </div>
        </div>
        <div className="home-reserver-today">
          <ReservationsList />
        </div>
      </div>
      <Footer />
    </>
  );
}
