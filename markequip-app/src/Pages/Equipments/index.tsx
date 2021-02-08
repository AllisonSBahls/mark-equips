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

export default function Equipment() {

  const [equipments, SetEquipments] = useState<IEquipment[]>([]);
  const [totalResult, setTotalResult] = useState(0);
  const [page] = useState(1);
  const [pageB, setPageB] = useState(2);
  const [name, setName] = useState('');
  const [equipmentId, setEquipmentId] = useState(null);
  const [openModal, setOpenModal] = useState(false);
  const [equipmentReserver, setEquipmentReserver] = useState(null);

  const token = localStorage.getItem('Token');

  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`
    }
  }

  useEffect(() => {
    fetchEquipmentsCard();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, name, equipmentId, openModal])


  async function fetchEquipmentsCard() {
    try {
      const response = await fetchEquipment(page, authorization, name);
      setTotalResult(response.data.totalResults)
      SetEquipments(response.data.list);
      setPageB(page + 1);
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
            <h3>Equipamentos e Laboratórios: </h3>
            <div className="equipment-content-search">
              <div className="field-search">
                <FaSearch className="icon icon-search" />
                <SearchInput value={name} onChange={(search: string) => { setName(search) }} />
              </div>
              <button onClick={() => setOpenModal(true)} className="equipment-btn-insert">Novo</button>
            </div>
          </div>
        <div className={`equipment-content ${totalResult < 4 ? "equipment-justify" : ""}`}>
          <div className="equipment">
            <div className="equipment-title">
              <h4 className="equipment-name">Projetor</h4>
              <h5 className="equipment-tombo">Nº 2312</h5>
            </div>
            <div className="equipment-description">
              <p>Porta HDMI, VGA saida de som, qualidade</p>
            </div>
            <div className="equipment-btn-action">
              <button className="equipment-btn-reserver" >Reservar</button>
              {/* <button
            className="equipment-btn-delete"
            onClick={() => {
              if (window.confirm(`Você tem certeza que deseja remover o(a): ${equipment.name}`)) { 
                deleteEquipment(equipment.id); 
              }
            }}>
            Deletar
          </button> */}
              {/* <button
            className="equipment-btn-edit"
            onClick={() => onClickInfo(equipment.id)}
          >
            Editar
          </button> */}
            </div>
          </div>
          {equipments.map(equipment => (
            <EquipmentCard
              key={equipment.id}
              equipment={equipment}
              onClickInfo={setEquipmentId}
              onClickReserver={setEquipmentReserver}
              deleteEquipment={deleteEquipment} />
          ))}
        </div>
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
        onClickClose={() => [setEquipmentId(null), setOpenModal(false)]} />

      <EquipmentReserver
        equipmentId={equipmentReserver}
        onClickClose={() => [setEquipmentReserver(null), setOpenModal(false)]} />
    </>

  );
}
