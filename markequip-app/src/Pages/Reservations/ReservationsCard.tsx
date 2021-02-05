import "./styles.css";

export default function ReservationsCard() {
  return (
    <>
      <div className="reserver-card">
        <p className="reserver-collaborator">Allison Sousa Bahls</p>
        <p className="reserver-equipment">Projetor Dell 2V</p>
        <div className="reserver-info">
          <p className="reserver-date">04/02/2021</p>
          <p className="reserver-schedules">10:00-12:00</p>
        </div>
        <div className="reserver-btn">
          <button className="reserver-btn-deliver">Entregar</button>
          <button className="reserver-btn-take">Recolher</button>
          <button className="reserver-btn-cancel">Cancelar</button>
        </div>
      </div>
     </>
  );
}
