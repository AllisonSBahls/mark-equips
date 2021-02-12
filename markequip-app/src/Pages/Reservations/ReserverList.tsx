import { useEffect, useState } from "react";
import { cancelReserver, deliverReserver, fetchReserverDelivered, fetchReserverReserved, finishReserver } from "../../Services/reserver";
import ReservedCard from "./ReservedCard";
import "./styles.css";
import { IReserver, ReserveStatus } from "./types";
import {toast} from "react-toastify"
import SearchInput from "../../Components/Debounced/SearchInput";
import IsLoading from "../../Components/Loading";

export default function ReservationsList() {
  const [inUse, setInUse] = useState<IReserver[]>([]);
  const [reserved, setReserved] = useState<IReserver[]>([]);
  const [statusUpdate, setStatusUpdate] = useState<number>(1);
  const [totalResult, setTotalResult] = useState<number>(0);
  const [totalResultInUse, setTotalResultInUse] = useState<number>(0);
  const [pageA] = useState<number>(1);
  const [pageB, setPageB] = useState<number>(2);
  const [pageInUse] = useState<number>(1);
  const [pageBInUse, setPageBInUse] = useState<number>(2);

  var today = new Date();
  const [date] = useState<string>(today.toLocaleDateString('en-CA'));
  const [nameReserved, SetNameReserved] = useState<string>('');
  const [nameUsing, SetNameUsing] = useState<string>('');
  const [equipmentReserved, SetEquipmentReserved] = useState<string>('');
  const [equipmentUsing, SetEquipmentUsing] = useState<string>('');
  const [statusinUse] = useState<ReserveStatus>(ReserveStatus.USING);
  const [statusReserved] = useState<ReserveStatus>(ReserveStatus.RESERVED);
  const [isLoading, setIsLoading] = useState(false);

  const token = localStorage.getItem('Token')!;

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  }

  useEffect(() => {
   fetchReserved();
    fetchInUse();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, statusUpdate, nameReserved, nameUsing, equipmentReserved, equipmentUsing])

  async function fetchReserved(){
    try{
    const response = await fetchReserverReserved(pageA, authorization, date, nameReserved, equipmentReserved, statusReserved)
    setTotalResult(response.data.totalResults);
    setReserved(response.data.list);
    setPageB(pageA+1);
    setIsLoading(true);
  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
}

async function fetchMoreReserved() {
  try{
    const response = await fetchReserverReserved(pageB, authorization,  date, nameReserved, equipmentReserved, statusReserved)
    setReserved([...reserved, ...response.data.list]);
    setTotalResult(response.data.totalResults);
    setPageB(pageB+1);
    setIsLoading(true);

  }catch(err){
    toast.error("Erro ao listar os Colaboradores")
  } 
}

async function fetchInUse(){
  try{
  const response = await fetchReserverDelivered(pageInUse, authorization, '', nameUsing, equipmentUsing, statusinUse)
  setTotalResultInUse(response.data.totalResults);
  setInUse(response.data.list);
  setPageBInUse(pageInUse + 1);
  setIsLoading(true);
}catch(err){
  toast.error("Erro ao listar as reservas")
}
}

async function fetchMoreInUse() {
  try{
    const response = await fetchReserverDelivered(pageBInUse, authorization, '', nameUsing, equipmentUsing, statusinUse)
    setInUse([...inUse, ...response.data.list]);
    setTotalResultInUse(response.data.totalResults);
    setPageBInUse(pageBInUse+1);
    setIsLoading(true);

  }catch(err){
    toast.error("Erro ao listar os Colaboradores")
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
      toast.success(`${equipment} Recolhido`);
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
      {/* Listagem dos equipamentos reservados esperando o usuário buscar */}
      <div className="reserver-content">
        <div className="reserver-content-action">
          <h3>Reservados para hoje: {totalResult}</h3>
        <div className="reserver-content-search">
            <label>Colaborador: </label><SearchInput value ={nameReserved} onChange={(search: string) => {SetNameReserved(search)}}/>
            <label>Equipamento: </label><SearchInput value ={equipmentReserved} onChange={(search: string) => {SetEquipmentReserved(search)}}/>
        </div>
        </div>
        <div className="reserver-today">
        {!isLoading ? 
          (<IsLoading/>) : 
            reserved.length > 0 ?
          ( <>
          {reserved.map((reserver) => (
          <ReservedCard 
            key={reserver.id}
            revokeReserver={() => revokeReserver(reserver.id)}
            deliverEquipment={() => deliverEquipment(reserver.id, reserver.equipment.name)}
            collectEquipment = {() => collectEquipment(reserver.id, reserver.equipment.name)}
            reserver = {reserver}/>
            ))}
            </>
           ) : (<div>Nenhuma reserva para hoje</div>)}
          
        </div>
        <div className="reserver-btn-action">
            <button  className="reserver-btn-loading"
            onClick={fetchMoreReserved}>
            {totalResult === reserved.length ? 'Fim da Página' : 'Carregar mais'}
            </button>
          </div>
      </div>

      {/* Listagem dos equipamentos que já foram entregues ao cliente e estão em uso */}
      <div className="reserver-content">
        <div className="reserver-content-action">
          <h3>Em uso: {totalResultInUse}</h3>
        <div className="reserver-content-search">
            <label>Colaborador: </label><SearchInput value ={nameUsing} onChange={(search: string) => {SetNameUsing(search)}}/>
            <label>Equipamento: </label><SearchInput value ={equipmentUsing} onChange={(search: string) => {SetEquipmentUsing(search)}}/>
        </div>
        </div>--
        <div className="reserver-today">
        {!isLoading ? 
          (<IsLoading/>) : 
          inUse.length > 0 ?
          ( <>
          {inUse.map((reserver) => (
          <ReservedCard 
            key={reserver.id}
            revokeReserver={() => revokeReserver(reserver.id)}
            deliverEquipment={() => deliverEquipment(reserver.id, reserver.equipment.name)}
            collectEquipment = {() => collectEquipment(reserver.id, reserver.equipment.name)}
            reserver = {reserver}/>
          ))}
           </>
          ) : (<div>Nenhuma equipamento em uso</div>)}
          
        </div>
        <div className="reserver-btn-action">
            <button  className="reserver-btn-loading"
            onClick={fetchMoreInUse}>
            {totalResultInUse === inUse.length ? 'Fim da Página' : 'Carregar mais'}
            </button>
          </div>
      </div>
    </div>
  </>
  );
}
