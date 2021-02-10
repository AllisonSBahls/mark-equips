import Navbar from "../Navbar";
import ReservationsList from "../Reservations/ReserverList";

import "./styles.css";

export default function Home() {
  return (
    <>
      <Navbar title={"Reserva de Equipamentos e Laboratórios"} />
      <div className="home-container">
        <div className="home-content">

          <div className="home-user">
            <div className="home-user-info">
              <p>Bem vindo Allison Sousa Bahls ao painel de Administrador do Mark Equips.
              </p>
              <p>Voce pode gerenciar as reservas solicitadas pelos colaboradores, bem como gerenciar equipamentos, horários
                  e colaboradores</p>
            </div>
          </div>
          <div className="home-btn">
            <button className="home-btn-reserve">Reserva Equipamento</button>
            <button className="home-btn-reserved">Ver todas de Reservas</button>
          </div>
        </div>
        <div className="home-reserver-today">
          <ReservationsList />
        </div>
      </div>
    </>
  );
}
