import {IReserver} from "./types";

import "./styles.css";

type Props = {
  reserver: IReserver;
  collectEquipment: () => void;

}

export default function DeliveredCard({reserver, collectEquipment}: Props) {
  const date = new Date(reserver.date);

  return (
    <>
      <div className="reserver-card">
        <p className="reserver-collaborator">{reserver.user.fullName}</p>
        <p className="reserver-equipment">{reserver.equipment.name}</p>
        <div className="reserver-info">
          <p className="reserver-date">{date.toLocaleDateString()}</p>
          <p className="reserver-schedules">{reserver.schedule.hourInitial} - {reserver.schedule.hourFinal}</p>
        </div>
        <div className="reserver-btn">
          <button className="reserver-btn-take" onClick={() => collectEquipment()}>Recolher</button>
        </div>
      </div>
     </>
  );
}
