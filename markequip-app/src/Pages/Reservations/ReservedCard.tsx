import { IReserver } from "./types";
import { toast } from "react-toastify";
import { cancelReserver, deliverReserver } from "../../Services/reserver";

import "./styles.css";

type Props = {
  reserver: IReserver;
  token: string;
};

export default function ReservedCard({ reserver, token }: Props) {

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };


  async function revokeReserver(id: number) {
    try {
      await cancelReserver(id, authorization);
      toast.success(`Reserva cancelado com sucesso ${reserver.id}`);
    } catch (err) {
      toast.error(`Erro ao cancelar a reserva`);
    }
  }

  async function deliverEquipment(id: number) {
    try {
      await deliverReserver(id, authorization);
      toast.success(`${reserver.equipment.name} entregue`);
    } catch (err) {
      toast.error(`Erro ao entregar o equipamento `);
    }
  }

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
          <button className="reserver-btn-deliver" onClick={() => deliverEquipment(reserver.id)}>Entregar</button>
          <button
            className="reserver-btn-cancel"
            onClick={() => {
              if (
                window.confirm(
                  `Você tem certeza que deseja cancelar a reserva: ${reserver.id}`
                )
              ) {
                revokeReserver(reserver.id);
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
