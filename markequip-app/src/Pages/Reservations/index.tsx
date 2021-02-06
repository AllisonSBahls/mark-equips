import { useEffect, useState } from "react";
import { fetchReserverCollect, fetchReserverDelived, fetchReserverReserved, reserver } from "../../Services/reserver";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";
import ReservedCard from "./ReservedCard";
import "./styles.css";
import { IReserver, StatusReserver } from "./types";
import {toast} from "react-toastify"
import DeliveredCard from "./DeliveredCard";
import ColletedCard from "./ColletedCard";

export default function Reservations() {
  const [reservations, setReservations] = useState<IReserver[]>([]);
  const [reservationsDelivered, setReservationsDelivered] = useState<IReserver[]>([]);
  const [reserved, setReserved] = useState<IReserver[]>([]);
  const [reservationsCollected, setReservationsCollected] = useState<IReserver[]>([]);
  const [reservationsCancel, setReservationsCancel] = useState<IReserver[]>([]);
  const [pageA, setPageA] = useState<number>(1);
  const [dateReserved, setDate] = useState<string>('');

  const token = localStorage.getItem('Token')!;

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  }

  useEffect(() => {
    fetchReservationsReserved();
    fetchReservationsCollect();
    fetchReservationsDelivered();
  }, [token])

  async function fetchReservationsReserved(){
    try{
    const response = await fetchReserverReserved(pageA, authorization, dateReserved)
    setReserved(response.data.list);
    console.log(reserved)
    setPageA(pageA + 1)
  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
}

  async function fetchReservationsCollect(){
    try{
    const response = await fetchReserverCollect(pageA, authorization, dateReserved)
    setReservationsCollected(response.data.list);
    setPageA(pageA + 1)

  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
  }

  async function fetchReservationsDelivered(){
    try{
    const response = await fetchReserverDelived(pageA, authorization, dateReserved)
    setReservationsDelivered(response.data.list);
    setPageA(pageA + 1)
    
  }catch(err){
    toast.error("Erro ao listar as reservas")
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
            reserver = {reserver}
            token={token}/>
          ))}
        </div>
      </div>
      <div className="reserver-content">
        <h3>Em uso</h3>
        <div className="reserver-today">
        {reservationsDelivered.map((reserver) => (
          <DeliveredCard 
            key={reserver.id}
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
