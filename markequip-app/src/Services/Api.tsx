import axios from "axios";

const API_URL = "https://localhost:";

export default function fetchReservations(){
    return axios(`${API_URL}/reservations/asc/10/1`);
}