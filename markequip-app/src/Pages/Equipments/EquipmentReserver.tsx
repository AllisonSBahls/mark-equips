import React, { useEffect, useState } from "react";
import "./styles.css";

import Modal from "../../Components/Modal/Modal";
import { toast } from "react-toastify";
import { findById } from "../../Services/equipment";
import { fetchSchedule } from "../../Services/schedule";
import { ISchedule } from "../Schedule/types";
import { checkIsSelected } from "./helpers";
import { ScheduleList } from "./SchedulesList";
import { IEquipment } from "./types";
import { reserver } from "../../Services/reserver";
import { IReserve, IReserver } from "../Reservations/types";

type Props = {
  equipmentId: number | null,
  onClickClose: () => void;
}

export default function EquipmentReserver({ equipmentId, onClickClose }: Props) {
  const [schedules, setSchedules] = useState<ISchedule[]>([]);
  const [equipmentReservations, setEquipmentReservations] = useState<IEquipment[]>([]);
  const [selectSchedules, setSelectSchedules] = useState<ISchedule[]>([]);
  var datas = new Date();
  const [date, setDate] = useState(datas.toLocaleDateString('en-CA'));
  const [nameEquipment, setNameEquipment] = useState("");
  
  const token = localStorage.getItem("Token");
  const fullName = localStorage.getItem("fullName")!;
  const Iduser = localStorage.getItem("id");
  
  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  useEffect(() => {
    loadEquipment();
    fetchScheduleEquipment();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [equipmentId]);

  async function reserverEquipment(e: React.FormEvent) {
    e.preventDefault();
    try {
      if(Iduser !== null && equipmentId !== null){
        const response = selectSchedules.map(async (schedule) => {
          const scheduleId = schedule.id;
          const userId: number = +Iduser;
          const data: IReserve = {
            userId,
            equipmentId,
            date,
            scheduleId,
          };
          await reserver(data, authorization);
        });
      await Promise.all(response);
      toast.success("Reservar realizada");
      setSelectSchedules([]);
      onClickClose();
    }
    } catch (err) {
      toast.error("Erro ao fazer a reserva");
    }
  }

  async function loadEquipment() {
    try {
      if (equipmentId != null) {
        const response = await findById(equipmentId, authorization);
        setNameEquipment(response.data.name)
        setEquipmentReservations(response.data.reservations);
      }
    } catch (err) {
      toast.error("Erro ao selecionar o equipamento");
    }
  }

  async function fetchScheduleEquipment() {
    try {
      const response = await fetchSchedule(authorization);
      setSchedules(response.data);
    } catch (error) {
      toast.error("Erro ao listar os horarios da manhã" + error);
    }
  }

  const handleSelectSchedules = (schedule: ISchedule) => {
    const isAlreadySelected = checkIsSelected(selectSchedules, schedule);
    if (isAlreadySelected) {
      const selected = selectSchedules.filter(
        (item) => item.id !== schedule.id
      );
      setSelectSchedules(selected);
    } else {
      setSelectSchedules((previous) => [...previous, schedule]);
    }
  };

  return (
    <>
      <Modal isOpen={Boolean(equipmentId)} onClickClose={onClickClose}>
        <div className="modal-content">
          <h3 className="modal-title">
            {equipmentId === null
              ? "Novo Equipamento"
              : "Informações do Equipamento"}
          </h3>
          <form onSubmit={reserverEquipment} className="modal-form">
            <div className="modal-input">
              <div className="modal-one-field">
                <label className="modal-label-field">Usuário: </label>
                <input
                  className="modal-input-field"
                  disabled
                  value={fullName}
                ></input>
              </div>
              <div className="modal-two-field">
                <div className="modal-primary-field">
                  <label className="modal-label-field">Equipamento: </label>
                  <input
                    className="modal-input-field"
                    value={nameEquipment}
                    onChange={(e) => setNameEquipment(e.target.value)}
                  />
                </div>
                <div className="modal-secondary-field">
                  <label className="modal-label-field">Data da Reserva: </label>
                  <input
                    type="date"
                    className="modal-input-field"
                    value={date}
                    onChange={(e) => setDate(e.target.value)}
                  ></input>
                </div>
              </div>
              <h4 className="equipment-reserver-title">
                Selecione os horários que desejar e disponiveis para reservar.
              </h4>
              <div className="equipment-reserver-schedule">
                <ScheduleList
                  schedules={schedules}
                  isSelected={selectSchedules}
                  onSelectSchedules={handleSelectSchedules}
                  dateReservation={date}
                  equipments={equipmentReservations}
                />
              </div>
            </div>
            <input
              className="modal-btn-success"
              type="submit"
              value="Reservar"
            ></input>
          </form>
        </div>
      </Modal>
    </>
  );
}
