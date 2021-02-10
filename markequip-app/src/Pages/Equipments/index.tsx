import Navbar from "../Navbar";
import EquipmentCard from "./EquipmentCard";
import "./styles.css";

import { useEffect, useState } from "react";
import { fetchEquipment, removeEquipment } from "../../Services/equipment";
import { IEquipment } from "./types";
import { toast } from 'react-toastify'
import { FaSearch } from "react-icons/fa";
import SearchInput from "../../Components/Debounced/SearchInput";
import EquipmentModal from "./EquipmentModal";
import EquipmentReserver from "./EquipmentReserver";
import IsLoading from "../../Components/Loading";

export default function Equipment() {

  const [equipments, SetEquipments] = useState<IEquipment[]>([]);
  const [totalResult, setTotalResult] = useState(0);
  const [page] = useState(1);
  const [pageB, setPageB] = useState(2);
  const [name, setName] = useState('');
  const [equipmentId, setEquipmentId] = useState(null);
  const [openModal, setOpenModal] = useState(false);
  const [equipmentReserver, setEquipmentReserver] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  //Render the equipments list every time that save or update
  const [refresh, setRefresh] = useState(0);
  const token = localStorage.getItem('Token');

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  }

  useEffect(() => {
    fetchEquipmentsCard();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, name, refresh])


  async function fetchEquipmentsCard() {
    try {
      const response = await fetchEquipment(page, authorization, name);
      setTotalResult(response.data.totalResults)
      SetEquipments(response.data.list);
      setPageB(page + 1);

      setIsLoading(true);
    } catch (err) {
      toast.error("Erro ao listar os Colaboradores")
    }
  }

  async function fetchMoreEquipments() {
    try {
      const response = await fetchEquipment(pageB, authorization, name)
      setTotalResult(response.data.totalResults);
      SetEquipments([...equipments, ...response.data.list]);
      setPageB(pageB + 1);
    } catch (err) {
      toast.error("Erro ao listar os Colaboradores")
    }
  }

  async function deleteEquipment(id: number) {
    try {
      await removeEquipment(id, authorization);
      SetEquipments(equipments.filter(equipments => equipments.id !== id));
      toast.success("Colaborador deletado com Sucesso")

    } catch (err) {
      toast.error("Erro ao Deletar o Colaborador")
    }
  }

  return (
    <>
      <Navbar title={"Equipamentos e Laboratórios"} />
      <div className="equipment-container">
        <div className="equipment-content">
          <div className="equipment-content-action">
            <h3>Total de equipamentos e laboratórios: {totalResult}  </h3>
            <div className="equipment-content-search">
              <div className="field-search">
                <FaSearch className="icon icon-search" />
                <SearchInput value={name} onChange={(search: string) => { setName(search) }} />
              </div>
              <button onClick={() => setOpenModal(true)} className="equipment-btn-insert">Cadastrar</button>
            </div>
          </div>

          {isLoading ? (
          <div className={`equipment-content-cards ${totalResult < 5 ? "equipment-justify" : ""}`}>
            {equipments.map(equipment => (
              <EquipmentCard
                key={equipment.id}
                equipment={equipment}
                onClickInfo={setEquipmentId}
                onClickReserver={setEquipmentReserver}
                deleteEquipment={deleteEquipment} />
            ))}
          </div>
          ) : (
            <IsLoading/>
            )}


        </div>

        <button
          className="btn-action btn-more-list"
          type="button"
          onClick={fetchMoreEquipments}>
          {totalResult === equipments.length ? 'Fim da Página' : 'Carregar mais'}
        </button>
      </div>
      <EquipmentModal
        equipmentId={equipmentId}
        openModal={openModal}
        setRefresh={setRefresh}
        onClickClose={() => [setEquipmentId(null), setOpenModal(false)]} />

      <EquipmentReserver
        equipmentId={equipmentReserver}
        onClickClose={() => [setEquipmentReserver(null), setOpenModal(false)]} />
    </>

  );
}
