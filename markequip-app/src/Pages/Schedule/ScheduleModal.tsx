import { useEffect, useState } from "react";
import Modal from "../../Components/Modal/Modal";
import { findById, register, updateSchedule } from "../../Services/schedule";
import { toast } from "react-toastify";

export default function ScheduleModal({scheduleId, openModal,onClickClose}: any){
    const[id, setId] = useState(null);
    const[period, setPeriod] = useState('');
    const[hourInitial, setHourInitial] = useState('');
    const[hourFinal, setHourFinal] = useState('');
    const token = localStorage.getItem("Token");
    const authorization = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
  
    useEffect(() => {
      if (openModal || scheduleId === null) openFormsRegister();
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
        setId(null);
        setPeriod("");
        setHourInitial("");
        setHourFinal("");
      } catch (err) {
        alert("Erro ao abrir o formulário de registro");
      }
    }
  
    async function saveSchedule(e: any) {
      e.preventDefault();
      try {
        if (scheduleId === null) {
          const data = {
            period,
            hourInitial,
            hourFinal,
          };
          await register(data, authorization);
          toast.success("Colaborador cadastrado com sucesso");
        } else {
          const data = {
            period,
            hourInitial,
            hourFinal,
            id: id,
          };
          await updateSchedule(data, authorization);
          toast.success("Colaborador alterado com sucesso");
        }
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
              {scheduleId === null
                ? "Inserir Horário"
                : "Informações do Horário"}
            </h3>
            <form onSubmit={saveSchedule} className="form-collaborator">
              <div className="collaborator">
                <div className="input-field input-name">
                  <label>Periodo: </label>
                  <input
                    value={period}
                    onChange={(e) => setPeriod(e.target.value)}
                    type="text"
                    className="input"
                    placeholder="Insira o nome completo"
                  ></input>
                </div>
                <div className="user">
                  <div className="input-field input-user">
                    <label>Horário Inicial: </label>
                    <input
                      value={hourInitial}
                      onChange={(e) => setHourInitial(e.target.value)}
                      type="text"
                      className="input"
                      placeholder="Insira o usuário"
                    ></input>
                  </div>
                  <div className="input-field input-password">
                    <label>Horario Final: </label>
                    <input
                      value={hourFinal}
                      onChange={(e) => setHourFinal(e.target.value)}
                      type="text"
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
                  value={scheduleId === null ? "Salvar" : "Atualizar"}
                ></input>
              </div>
            </form>
          </div>
        </div>

      </Modal>
      </>
)
}
