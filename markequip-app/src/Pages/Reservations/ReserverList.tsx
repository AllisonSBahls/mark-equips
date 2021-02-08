import { useEffect, useState } from "react";
import { cancelReserver, deliverReserver, fetchReserverCollect, fetchReserverDelived, fetchReserverReserved, finishReserver } from "../../Services/reserver";
import ReservedCard from "./ReservedCard";
import "./styles.css";
import { IReserver, ReserveStatus } from "./types";
import {toast} from "react-toastify"
import DeliveredCard from "./DeliveredCard";
import ColletedCard from "./ColletedCard";
import SearchInput from "../../Components/Debounced/SearchInput";

export default function ReservationsList() {
  const [reservationsDelivered, setReservationsDelivered] = useState<IReserver[]>([]);
  const [reserved, setReserved] = useState<IReserver[]>([]);
  const [statusUpdate, setStatusUpdate] = useState<number>(1);
  const [totalResult, setTotalResult] = useState<number>(0);
  const [reservationsCollected, setReservationsCollected] = useState<IReserver[]>([]);
  const [pageA] = useState<number>(1);
  const [pageB, setPageB] = useState<number>(2);

  var today = new Date();
  const [date] = useState<string>(today.toLocaleDateString('en-CA'));
  const [nameReserved, SetNameReserved] = useState<string>('');
  const [nameUsing, SetNameUsing] = useState<string>('');
  const [equipmentReserved, SetEquipmentReserved] = useState<string>('');
  const [equipmentUsing, SetEquipmentUsing] = useState<string>('');
  const [statusCollect] = useState<ReserveStatus>(ReserveStatus.FINISHED);
  const [statusDelivered] = useState<ReserveStatus>(ReserveStatus.USING);
  const [statusReserved] = useState<ReserveStatus>(ReserveStatus.RESERVED);

  const token = localStorage.getItem('Token')!;

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  }

  useEffect(() => {
    fetchReserved();
    fetchDelivered();
    fetchReservationsCollect();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, statusUpdate, nameReserved, nameUsing, equipmentReserved, equipmentUsing])

  async function fetchReserved(){
    try{
    const response = await fetchReserverReserved(pageA, authorization, date, nameReserved, equipmentReserved, statusReserved)
    setReserved(response.data.list);
  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
}

async function fetchMoreReserved() {
  try{
    const response = await fetchReserverReserved(pageB, authorization,  date, nameReserved, equipmentReserved, statusReserved)
    setTotalResult(response.data.totalResults);
    setReserved([...reserved, ...response.data.list]);
    setPageB(pageB+1);
  }catch(err){
    toast.error("Erro ao listar os Colaboradores")
  } 
}

async function fetchDelivered(){
  try{
  const response = await fetchReserverDelived(pageA, authorization, date, nameUsing, equipmentUsing, statusDelivered)
  setReservationsDelivered(response.data.list);
  
}catch(err){
  toast.error("Erro ao listar as reservas")
}
}

async function fetchMoreDelivered() {
  try{
    const response = await fetchReserverDelived(pageB, authorization,  date, nameUsing, equipmentUsing, statusReserved)
    setTotalResult(response.data.totalResults);
    setReservationsDelivered([...reserved, ...response.data.list]);
    setPageB(pageB+1);
  }catch(err){
    toast.error("Erro ao listar os Colaboradores")
  } 
}
  async function fetchReservationsCollect(){
    try{
    const response = await fetchReserverCollect(pageA, authorization, date, statusCollect)
    setReservationsCollected(response.data.list);
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
    <div className="reserver-container">
      <div className="reserver-action">
        <div className="reserver-action-search"></div>
      </div>
      <div className="reserver-content">
        <div className="reserver-content-action">
          <h3>Reservados para hoje</h3>
        <div className="reserver-content-search">
            <label>Colaborador: </label><SearchInput value ={nameReserved} onChange={(search: string) => {SetNameReserved(search)}}/>
            <label>Equipamento: </label><SearchInput value ={equipmentReserved} onChange={(search: string) => {SetEquipmentReserved(search)}}/>
        </div>
        </div>
        <div className="reserver-today">
          {reserved.map((reserver) => (
          <ReservedCard 
            key={reserver.id}
            revokeReserver={() => revokeReserver(reserver.id)}
            deliverEquipment={() => deliverEquipment(reserver.id, reserver.equipment.name)}
            reserver = {reserver}/>
          ))}
          
        </div>
        <div>
            <button   
            onClick={fetchMoreReserved}>
            {totalResult === reserved.length ? 'Fim da Página' : 'Carregar mais'}
            </button>
            <button   
            onClick={fetchMoreReserved}>
            Ver todos
            </button>
          </div>
      </div>
      <div className="reserver-content">
        <h3>Em uso
        <SearchInput className="reserver-search-name" value ={nameUsing} onChange={(search: string) => {SetNameUsing(search)}}/>
        <SearchInput className="reserver-search-equipment" value ={equipmentUsing} onChange={(search: string) => {SetEquipmentUsing(search)}}/>
        </h3>
        <div className="reserver-today">
        {reservationsDelivered.map((reserver) => (
          <DeliveredCard 
            key={reserver.id}
            collectEquipment={() => collectEquipment(reserver.id, reserver.equipment.name)}
            reserver = {reserver}/>
          ))}
        </div>
        <button   
            onClick={fetchMoreDelivered}>
            {totalResult === reserved.length ? 'Fim da Página' : 'Carregar mais'}
            </button>
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
