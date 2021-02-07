import { useEffect, useState } from "react";
import { cancelReserver, deliverReserver, fetchReserverCollect, fetchReserverDelived, fetchReserverReserved, finishReserver } from "../../Services/reserver";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";
import ReservedCard from "./ReservedCard";
import "./styles.css";
import { IReserver, ReserveStatus } from "./types";
import {toast} from "react-toastify"
import DeliveredCard from "./DeliveredCard";
import ColletedCard from "./ColletedCard";

export default function Reservations() {
  const [reservations, setReservations] = useState<IReserver[]>([]);
  const [reservationsDelivered, setReservationsDelivered] = useState<IReserver[]>([]);
  const [reserved, setReserved] = useState<IReserver[]>([]);
  const [statusUpdate, setStatusUpdate] = useState<number>(1);
  const [totalResult, setTotalResult] = useState<number>(0);
  const [reservationsCollected, setReservationsCollected] = useState<IReserver[]>([]);
  const [pageA, setPageA] = useState<number>(1);
  const [pageB, setPageB] = useState<number>(2);

  var today = new Date();
  const [date, setDate] = useState<string>(today.toLocaleDateString('en-CA'));
  const [name, SetName] = useState<string>('');
  const [equipment, SetEquipment] = useState<string>('');
  const [statusCollect, SetStatusCollect] = useState<ReserveStatus>(ReserveStatus.FINISHED);
  const [statusDelivered, SetStatusDelivered] = useState<ReserveStatus>(ReserveStatus.USING);
  const [statusReserved, SetStatusReserved] = useState<ReserveStatus>(ReserveStatus.RESERVED);

  const token = localStorage.getItem('Token')!;

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  }

  useEffect(() => {
    fetchReservationsReserved();
    fetchReservationsDelivered();
    fetchReservationsCollect();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, statusUpdate])

  async function fetchReservationsReserved(){
    try{
    const response = await fetchReserverReserved(pageA, authorization, date, name, equipment, statusReserved)
    setReserved(response.data.list);
  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
}

async function fetchMoreReserved() {
  try{
    const response = await fetchReserverCollect(pageB, authorization,  date, name, equipment, statusReserved)
    setTotalResult(response.data.totalResults);
    setReserved([...reserved, ...response.data.list]);
    setPageB(pageB+1);
  }catch(err){
    toast.error("Erro ao listar os Colaboradores")
  } 
}
  async function fetchReservationsCollect(){
    try{
    const response = await fetchReserverCollect(pageA, authorization, date, name, equipment, statusCollect)
    setReservationsCollected(response.data.list);
  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
  }

  async function fetchReservationsDelivered(){
    try{
    const response = await fetchReserverDelived(pageA, authorization, date, name, equipment, statusDelivered)
    setReservationsDelivered(response.data.list);
    
  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
  }
  
  async function revokeReserver(id: number) {
    try {
      await cancelReserver(id, authorization);
      toast.success(`Reserva ${id} cancelado com sucesso`);
      setStatusUpdate(statusUpdate+1)
    } catch (err) {
      toast.error(`Erro ao cancelar a reserva`);
    }
  }

  async function deliverEquipment(id: number, equipment: string) {
    try {
      await deliverReserver(id, authorization);
      setStatusUpdate(statusUpdate+1)
      toast.success(`${equipment} entregue`);

    }
     catch (err) {
      toast.error(`Erro ao entregar o equipamento `);
    }
  }

  async function  collectEquipment(id: number, equipment: string){
    try{
      await finishReserver(id, authorization);
      toast.success(`${equipment} devolvido`);
      setStatusUpdate(statusUpdate+1)

    }
    catch (err) {
      toast.error(`Erro ao recolher o equipamento `);
    }
  }

  return (
  <>
    <Navbar/>
    <Sidebar/>
    
    <div className="reserver-container">
      <div className="reserver-action">
        <div className="reserver-action-search"></div>
      </div>
      <div className="reserver-content">
        <h3>Reservados para hoje</h3>
        <div className="reserver-today">
          {reserved.map((reserver) => (
          <ReservedCard 
            key={reserver.id}
            revokeReserver={() => revokeReserver(reserver.id)}
            deliverEquipment={() => deliverEquipment(reserver.id, reserver.equipment.name)}
            reserver = {reserver}/>
          ))}
          <div>
            <button   
            onClick={fetchMoreReserved}>
            {totalResult === reserved.length ? 'Fim da Página' : 'Carregar mais'}
            Carregar mais</button>
          </div>
        </div>
      </div>
      <div className="reserver-content">
        <h3>Em uso</h3>
        <div className="reserver-today">
        {reservationsDelivered.map((reserver) => (
          <DeliveredCard 
            key={reserver.id}
            collectEquipment={() => collectEquipment(reserver.id, reserver.equipment.name)}
            reserver = {reserver}/>
          ))}
        </div>
      </div>

      <div className="reserver-content">
        <h3>Últimos Devolvidos</h3>
        <div className="reserver-today">
        {reservationsCollected.map((reserver) => (
          <ColletedCard 
            key={reserver.id}
            reserver = {reserver}/>
          ))}
        </div>
      </div>
    </div>
  </>
  );
}
