import { useEffect, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { toast } from 'react-toastify';
import { IUsers } from "./types";
import Navbar from "../Navbar";
import Footer from "../Footer";
import Sidebar from "../Sidebar";
import SearchInput from "../../Helpers/SearchInput";

import "./styles.css";
import { fetchCollaborator, removeCollaborator } from "../../Services/collaborator";
import { AiFillEdit, AiFillDelete, AiOutlineUserAdd } from "react-icons/ai";
import { FaSearch } from "react-icons/fa";

export default function Collaborator() {
  const [collaborators, setCollaborators] = useState<IUsers[]>([]);
  const [totalResult, setTotalResult] = useState();
  const [page] = useState(1);
  const [pageB, setPageB] = useState(2);
  const [name, setName] = useState('');

  const token = localStorage.getItem("Token");

  const authorization={
    headers: {
      Authorization: `Bearer ${token}`,
    },
  }

  const history = useHistory();

  useEffect(() => {
      fetchCollaborators();
      // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [token, name]);

  
  async function fetchCollaborators() {
    try{
      const response = await fetchCollaborator(page, authorization, name)
      setCollaborators(response.data.list);
      setPageB(page+1);
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

  async function editCollaborator(id: number){
    try{
      history.push(`colaborador/form/${id}`)
    } catch (err){
      toast.error("Erro ao editar o Colaborador")
    }
  }


  return (
    <>
      <Navbar />
      <Sidebar />

      <div className="container-collaborators">
        <div className="action-collaborators">
          <div className="field-search">
            <FaSearch className="icon icon-search" />
            <SearchInput value ={name} onChange={(search:any) => {setName(search)}}/>
          </div>

          <div className="btn-insert-field">
            <Link to="colaborador/form/0" className="btn-insert">
              <AiOutlineUserAdd className="icon" />
              Novo Colaborador
            </Link>
            <a href="/#" className="btn-insert btn-responsive">
              <AiOutlineUserAdd />
            </a>
          </div>
        </div>
        <div className="collaborators-content">
          <table className="table-colaborators table-responsive">
            <thead>
              <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Usuário</th>
                <th>Função</th>
                <th>Ações</th>
              </tr>
            </thead>
            <tbody>
              {collaborators.map((collaborator) => (
                <tr key={collaborator.id}>
                  <td>{collaborator.id}</td>
                  <td>{collaborator.fullName}</td>
                  <td>{collaborator.userName}</td>
                  <td>{collaborator.roles}</td>
                  <td>
                    <button onClick={() => editCollaborator(collaborator.id)} className="btn-action btn-edit">
                      <AiFillEdit className="icon" /> Editar
                    </button>
                    <button 
                      className="btn-action btn-delete"
                      onClick= {() => {
                        if(window.confirm(`Você tem certeza que deseja remover o Colaborador: ${collaborator.fullName}`))
                            {deleteCollaborator(collaborator.id)}
                        }}>
                      <AiFillDelete className="icon" /> Excluir
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <button 
          className="btn-action btn-delete" 
          type="button"
          onClick={fetchMoreCollaborators}>
            {totalResult === collaborators.length ? 'Fim da Página' : 'Carregar mais'}
          </button>
        </div>
      </div>
      <Footer />
    </>
  );
}
