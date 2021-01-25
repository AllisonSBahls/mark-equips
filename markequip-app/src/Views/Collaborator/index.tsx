import Footer from "../Footer";
import Navbar from "../Navbar";
import "./styles.css";

import { AiFillEdit, AiFillDelete } from "react-icons/ai";

export default function Collaborator() {
  return (
    <>
      <Navbar />
      <div className="container-collaborators">
        <div className="action-collaborators">
          <div className="field-search">
            <h3>Buscar: </h3>
            <input type="text"></input>
          </div>
          <div>
            <a href="/#" className="btn-insert">Novo Colaborador</a>
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
