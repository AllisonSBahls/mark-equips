import { useEffect, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import Footer from "../Footer";
import Navbar from "../Navbar";
import "./styles.css";

import { fetchCollaborator } from "../../Services/collaborator";

import { AiFillEdit, AiFillDelete, AiOutlineUserAdd } from "react-icons/ai";
import { FaSearch, FaTasks } from "react-icons/fa";
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
            <a href="/#" className="btn-insert">
              <AiOutlineUserAdd className="icon" />
              Novo Colaborador
            </a>
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
                    <a className="btn-action btn-edit" href="/#">
                      <AiFillEdit className="icon" /> Editar
                    </a>
                    <a className="btn-action btn-delete" href="/#">
                      <AiFillDelete className="icon" /> Excluir
                    </a>
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
