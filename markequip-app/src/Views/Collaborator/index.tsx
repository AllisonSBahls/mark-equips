import { useEffect, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import Footer from "../Footer";
import Navbar from "../Navbar";
import "./styles.css";

import { fetchCollaborator, removeCollaborator } from "../../Services/collaborator";

import { AiFillEdit, AiFillDelete, AiOutlineUserAdd } from "react-icons/ai";
import { FaSearch } from "react-icons/fa";
import Sidebar from "../Sidebar";
import { IUsers } from "./types";

export default function Collaborator() {
  const [collaborators, setCollaborators] = useState<IUsers[]>([]);

  const token = localStorage.getItem("Token");

  const history = useHistory();

  useEffect(() => {
    fetchCollaborator({
      headers: {
        Authorization: `Bearer ${token}`,
      },
    }).then((response) => {
      setCollaborators(response.data.list);
    });
  }, [token]);

  async function deleteCollaborator(id: number){
    try{
      await removeCollaborator(id, { 
        headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    setCollaborators(collaborators.filter(collaborator => collaborator.id !== id));

    } catch (err){
      alert("Erro ao deletar")
    }
  }

  async function editCollaborator(id: number){
    try{
      history.push(`colaborador/form/${id}`)

    } catch (err){
      alert("Erro ao Editar o colaborador")
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
            <input type="text" placeholder="Procurar pelo nome"></input>
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
                      onClick={() => deleteCollaborator(collaborator.id)}>
                      <AiFillDelete className="icon" /> Excluir
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      <Footer />
    </>
  );
}