import { IReserver } from "./types";

import "./styles.css";

type Props = {
  reserver: IReserver;
  revokeReserver: () => void;
  deliverEquipment: () => void;
};

export default function ReservedCard({ reserver, revokeReserver, deliverEquipment }: Props) {
  
  return (
    <>
      <div className="reserver-card">
        <p className="reserver-collaborator">{reserver.user.fullName}</p>
        <p className="reserver-equipment">{reserver.equipment.name}</p>
        <div className="reserver-info">
          <p className="reserver-date">{reserver.date}</p>
          <p className="reserver-schedules">
            {reserver.schedule.hourInitial} - {reserver.schedule.hourFinal}
          </p>
        </div>
        <div className="reserver-btn">
          <button className="reserver-btn-deliver" onClick={() => deliverEquipment()}>Entregar</button>
          <button
            className="reserver-btn-cancel"
            onClick={() => {
              if (
                window.confirm(
                  `Você tem certeza que deseja cancelar a reserva: ${reserver.id}`
                )
              ) {
                revokeReserver();
              }
            }}
          >
            Cancelar
          </button>
        </div>
      </div>
    </>
  );
}
