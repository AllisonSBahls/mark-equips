import {IReserver} from "./types";

import "./styles.css";

type Props = {
  reserver: IReserver;
 
}

export default function ColletedCard({reserver}: Props) {
  return (
    <>
      <div className="reserver-card">
        <p className="reserver-collaborator">{reserver.user.fullName}</p>
        <p className="reserver-equipment">{reserver.equipment.name}</p>
        <div className="reserver-info">
          <p className="reserver-date">{reserver.date}</p>
          <p className="reserver-schedules">{reserver.schedule.hourInitial} - {reserver.schedule.hourFinal}</p>
        </div>

      </div>
     </>
  );
}
