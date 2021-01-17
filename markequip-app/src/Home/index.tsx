import "./styles.css";
import Reservations from "../Reservations";

export default function Home() {
  return (
    <>
      <Reservations />
      <div className="home-container">
        <div className="collaborators-content">
          <h1>Tabela das ultimas reserva dos professores</h1>
        </div>
        <div className="equipments-content">
          <h1>Tabela dos ultimos equipmaentos reservados</h1>
        </div>
      </div>
    </>
  );
}
