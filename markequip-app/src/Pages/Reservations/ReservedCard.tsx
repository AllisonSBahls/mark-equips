import { IReserver, ReserveStatus } from "./types";

import "./styles.css";
import { roleValidate } from "../../auth";

type Props = {
  reserver: IReserver;
  revokeReserver: () => void;
  deliverEquipment: () => void;
  collectEquipment: () => void;
};

export default function ReservedCard({
  reserver,
  revokeReserver,
  deliverEquipment,
  collectEquipment,
}: Props) {
 var date = new Date(reserver.date).toLocaleDateString();
  return (
    <>
      <div className={`${reserver.status === ReserveStatus.RESERVED ? "reserver-card-reserved" : "reserver-card-inuse"}`}>
        <p className="reserver-collaborator">{reserver.user.fullName}</p>
        <p className="reserver-equipment">{reserver.equipment.name}</p>
        <div className="reserver-info">
          <p className="reserver-date">{date}</p>
          <p className="reserver-schedules">
            {reserver.schedule.hourInitial} - {reserver.schedule.hourFinal}
          </p>
        </div>

        {roleValidate() === "Administrator" ? (<> 
        <div className="reserver-btn">
          {reserver.status === ReserveStatus.RESERVED ? (
            <button
              className="reserver-btn-deliver"
              onClick={() => deliverEquipment()}>
              Entregar
            </button>
          ) : (
            <button
              className="reserver-btn-deliver"
              onClick={() => collectEquipment()}>
              Coletar
            </button>
          )}
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
            }}>
            X
          </button>
        </div>
        </>) : (null)}
      </div>
    </>
  );
}
