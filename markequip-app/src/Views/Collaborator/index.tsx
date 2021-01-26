import Footer from "../Footer";
import Navbar from "../Navbar";
import "./styles.css";


import { AiFillEdit, AiFillDelete, AiOutlineUserAdd, AiFillSave } from "react-icons/ai";
import { FaSearch } from "react-icons/fa";
import Register from "./register";

export default function Collaborator() {

  return (
    <>
      <Navbar />
      <div className="container-collaborators">
        <div className="action-collaborators">
        <div className="btn-insert-field">
            <a href="/#" className="btn-insert">
              <AiOutlineUserAdd className="icon"/>
              Novo Colaborador
            </a>
          </div>

          <div className="title-page-collaborator">
            <label>Lista de Colaboradores</label>
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
              <tr>
                <td>1</td>
                <td>Allison Sousa Bahls</td>
                <td>alison</td>
                <td>Administrador</td>
                <td>
                  <a className="btn-action btn-edit" href="/#">
                    <AiFillEdit className="icon" /> Editar
                  </a>
                  <a className="btn-action btn-delete" href="/#">
                    <AiFillDelete className="icon" /> Excluir
                  </a>
                </td>
              </tr>
              <tr>
                <td>1</td>
                <td>Allison Sousa Bahls</td>
                <td>alison</td>
                <td>Administrador</td>
                <td>
                  <label htmlFor="">
                  <a className="btn-action btn-edit" href="/#">
                    <AiFillEdit className="icon" /> Editar
                  </a>
                  </label>
                  <a className="btn-action btn-delete" href="/#">
                    <AiFillDelete className="icon" /> Excluir
                  </a>
                </td>
              </tr>
              <tr>
                <td>1</td>
                <td>Allison Sousa Bahls</td>
                <td>alison</td>
                <td>Administrador</td>
                <td>
                  <a className="btn-action btn-edit" href="/#">
                    <AiFillEdit className="icon" /> Editar
                  </a>
                  <a className="btn-action btn-delete" href="/#">
                    <AiFillDelete className="icon" /> Excluir
                  </a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <Footer />
    </>
  );
}
