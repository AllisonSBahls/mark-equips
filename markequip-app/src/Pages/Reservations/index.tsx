import { useEffect, useState } from "react";
import { fetchReserverDate } from "../../Services/reserver";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";
import ReservationsCard from "./ReservationsCard";
import "./styles.css";
import { IReserver } from "./types";
import {toast} from "react-toastify"
export default function Reservations() {
  const [reservations, setReservations] = useState<IReserver[]>([]);
  const [pageA, setPageA] = useState<number>(1);
  const [dateReserved, setDate] = useState<string>('');

  const token = localStorage.getItem('Token');

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  }

  useEffect(() => {
    fetchReservationsDate();
  })

  async function fetchReservationsDate(){
    try{
    const response = await fetchReserverDate(pageA, authorization, dateReserved)
    setReservations(response.data.list);
    console.log(reservations)
  }catch(err){
    toast.error("Erro ao listar as reservas")
  }
  }

  return (
  <>
    <Navbar/>
    <Sidebar/>
    
    <div className="reserver-container">
      <div className="reserver-content">
        <h3>Reservados para hoje</h3>
        <div className="reserver-today">
          <ReservationsCard />
        </div>
      </div>
      <div className="reserver-content">
        <h3>Reservados para os proximos dias</h3>
        <div className="reserver-today">
        <ReservationsCard />
        </div>
      </div>
    </div>
  </>
  );
}
