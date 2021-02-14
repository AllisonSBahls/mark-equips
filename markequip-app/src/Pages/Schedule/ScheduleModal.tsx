import { useEffect, useState } from "react";
import Modal from "../../Components/Modal/Modal";
import { findById, register, updateSchedule } from "../../Services/schedule";
import { toast } from "react-toastify";
import { ISchedule } from "./types";

type Props = {
  scheduleId: number;
  openModal: boolean;
  refresh: (refresh: number) => void;
  onClickClose: () => void;
}

export default function ScheduleModal({scheduleId, openModal, refresh, onClickClose}: Props){
    const[id, setId] = useState(0);
    const[period, setPeriod] = useState('');
    const[hourInitial, setHourInitial] = useState('');
    const[hourFinal, setHourFinal] = useState('');
    const token = localStorage.getItem("Token");
    const[refreshFetch, setRefreshFetch] = useState(1);

    const authorization = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
  
    useEffect(() => {
      if (openModal || scheduleId === 0) openFormsRegister();
      else loadSchedule();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [scheduleId]);
  
    async function loadSchedule() {
      try {
        const response = await findById(scheduleId, authorization);
        setPeriod(response.data.period);
        setHourInitial(response.data.hourInitial);
        setHourFinal(response.data.hourFinal);
      } catch (err) {
        alert("Erro ao carregar o horário");
      }
    }
  
    async function openFormsRegister() {
      try {
        setId(0);
        setPeriod("");
        setHourInitial("");
        setHourFinal("");
      } catch (err) {
        alert("Erro ao abrir o formulário de registro");
      }
    }
  
    async function saveSchedule(e: any) {
      e.preventDefault();
      var period;
      if(hourInitial >= '05:00' && hourInitial <= '12:00'){
        period = "Manhã"
      } else if(hourInitial > '12:00' && hourInitial <= '18:00'){
        period = "Tarde"
      } else{
        period = "Noite"
      }
      try {
        
        if (scheduleId === 0) {
          const data: ISchedule = {
            period,
            hourInitial,
            hourFinal,
            id: id
          };
          await register(data, authorization);
          setRefreshFetch(refreshFetch + 1);
          toast.success("Colaborador cadastrado com sucesso");
        } else {
          const data: ISchedule = {
            period,
            hourInitial,
            hourFinal,
            id: id,
          };
          await updateSchedule(data, authorization);
          setRefreshFetch(refreshFetch + 1);
          toast.success("Colaborador alterado com sucesso");
        }
        refresh(refreshFetch);
        onClickClose();
      } catch (err) {
        toast.error("Erro ao salvar o colaborador");
      }
    }
    return(
      <>
      <Modal
      isOpen={Boolean(scheduleId) || openModal } 
      onClickClose={onClickClose}>

      <div className="register-container">
          <div className="register">
            <h3 className="subtitle">
              {scheduleId === 0
                ? "Inserir Horário"
                : "Informações do Horário"}
            </h3>
            <form onSubmit={saveSchedule} className="form-collaborator">
              <div className="collaborator">
                {scheduleId !== 0 ? (
                <div className="input-field input-name">
                  <label>Periodo: </label>
                  <input
                    value={period}
                    onChange={(e) => setPeriod(e.target.value)}
                    type="text"
                    disabled
                    className="input"
                    placeholder="Insira o nome completo"
                  ></input>
                </div> 
                ) : (null)} 
                <div className="user">
                  <div className="input-field input-user">
                    <label>Horário Inicial: </label>
                    <input
                      value={hourInitial}
                      onChange={(e) => setHourInitial(e.target.value)}
                      type="time"
                      min="06:00" max="22:00"
                      className="input"
                      placeholder="Insira o usuário"
                    ></input>
                  </div>
                  <div className="input-field input-password">
                    <label>Horario Final: </label>
                    <input
                      value={hourFinal}
                      onChange={(e) => setHourFinal(e.target.value)}
                      type="time"
                      min="07:00" max="23:00"
                      className="input"
                      placeholder="Insira a senha"
                    ></input>
                  </div>
                </div>
              </div>
              <div className="form-button">
                <input
                  type="submit"
                  className="button-save"
                  value={scheduleId === 0 ? "Salvar" : "Atualizar"}
                ></input>
              </div>
            </form>
          </div>
        </div>

      </Modal>
      </>
)
}
