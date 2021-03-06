import { useEffect, useState } from "react";
import { toast } from 'react-toastify';
import { IUsers } from "./types";
import Navbar from "../Navbar";
import Footer from "../Footer";
import SearchInput from "../../Components/Debounced/SearchInput";

import "./styles.css";
import { fetchCollaborator, removeCollaborator } from "../../Services/collaborator";
import { AiOutlineUserAdd } from "react-icons/ai";
import { FaSearch } from "react-icons/fa";
import CollaboratorList from "./CollaboratorsList";
import CollaboratorModal from "./CollaboratorModal";
import IsLoading from "../../Components/Loading";

export default function Collaborator() {
  const [collaborators, setCollaborators] = useState<IUsers[]>([]);
  const [totalResult, setTotalResult] = useState();
  const [page] = useState(1);
  const [pageB, setPageB] = useState(2);
  const [name, setName] = useState('');
  const [openModal, setOpenModal] = useState(false);
  const [collaboratorId, setCollaboratorId] = useState(0);
  const [isLoading, setIsLoading] = useState(false)
  const token = localStorage.getItem("Token");

  const authorization={
    headers: {
      Authorization: `Bearer ${token}`,
    },
  }

  useEffect(() => {
      fetchCollaborators();
      // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, name]);

  
  async function fetchCollaborators() {
    try{
      const response = await fetchCollaborator(page, authorization, name)
      setCollaborators(response.data.list);
      setPageB(page+1);
      setIsLoading(true);
    }catch(err){
      toast.error("Erro ao listar os Colaboradores")
    } 
  }

  async function fetchMoreCollaborators() {
    try{
      const response = await fetchCollaborator(pageB, authorization, name)
      setTotalResult(response.data.totalResults);
      setCollaborators([...collaborators, ...response.data.list]);
      setPageB(pageB+1);
    }catch(err){
      toast.error("Erro ao listar os Colaboradores")
    } 
}
  async function deleteCollaborator(id: number){
    try{
      await removeCollaborator(id, authorization);
      setCollaborators(collaborators.filter(collaborator => collaborator.id !== id));
      toast.success("Colaborador deletado com Sucesso")

    } catch (err){
      toast.error("Erro ao Deletar o Colaborador")
    }
  }

  return (
    <>
      <Navbar title={"Colaboradores"}/>
      <div className="container-collaborators">
        <div className="action-collaborators">
          <div className="field-search">
            <FaSearch className="icon icon-search" />
            <SearchInput value ={name} onChange={(search:string) => {setName(search)}}/>
          </div>

          <div className="btn-insert-field">
            <button onClick={() => setOpenModal(true)} className="btn-insert">
              <AiOutlineUserAdd className="icon" />
              Novo Colaborador
            </button>
          </div>
        </div>

        <div className="collaborators-content">
          {isLoading ? (
        <CollaboratorList 
          collaborators={collaborators}
          deleteCollaborator={deleteCollaborator}
          onClickInfo={setCollaboratorId}
        />
        ) : (<IsLoading/>)}

        <button 
        className="btn-action btn-more-list" 
        type="button"
        onClick={fetchMoreCollaborators}>
          {totalResult === collaborators.length ? 'Fim da Página' : 'Carregar mais'}
        </button>
      </div>
      </div>
      <Footer />
      <CollaboratorModal 
        collaboratorId={collaboratorId}
        openModal ={openModal}
        onClickClose={() => [setCollaboratorId(0), setOpenModal(false)]}
        />
    </>
  );
}
