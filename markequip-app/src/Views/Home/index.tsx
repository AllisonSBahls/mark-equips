import "./styles.css";
import {BsFillBookmarksFill} from "react-icons/bs";
import {AiTwotoneEdit} from "react-icons/ai";
import {MdCancel} from "react-icons/md";


export default function Home() {
  return (
    <>
      <div className="container-">
        <div className="text-reserver">
          <h1>
            Escolha o status da reserva para ser exibida na tabela abaixo.
          </h1>
        </div>
        <div className="btn-status-reservations">
          <a href="/#" className="">
            Reservados
          </a>
          <a href="/#" className="">
            Em Uso
          </a>
          <a href="/#" className="">
            Finalizados
          </a>
        </div>

        <div className="reservations-container">
          <div className="title-table-reservations">
            Lista dos Equipamentos e Laboratórios Reservados
          </div>
          <table className="table table-responsive">
            <thead>
              <tr>
                <th>Colaborador</th>
                <th>Equipamento</th>
                <th>Data da Reserva</th>
                <th>Hora de Retirada</th>
                <th>Hora de Devolução</th>
                <th></th>

              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Allison Sousa Bahls</td>
                <td>Laboratorio de Informática</td>
                <td>15/01/2021</td>
                <td>08:00 </td>
                <td>09:00 </td>
                <td className="btn-action">
                  <a className="btn-action-delivered" href="/#">
                    <BsFillBookmarksFill /> Entregar
                  </a>
                  <a className="btn-action-edit" href="/#">
                    <AiTwotoneEdit /> Editar
                  </a>  
                  <a className="btn-action-cancel" href="/#">
                   <MdCancel className="icon-cancel"/> Cancelar
                  </a>  
                </td>
              </tr>
              <tr>
                <td>Allison Sousa Bahls</td>
                <td>Laboratorio de Informática</td>
                <td>15/01/2021</td>
                <td>08:00 </td>
                <td>09:00 </td>

                <td className="btn-action">
                  <a className="btn-action-delivered" href="/#">
                    <BsFillBookmarksFill /> Entregar
                  </a>
                  <a className="btn-action-edit" href="/#">
                    <AiTwotoneEdit /> Editar
                  </a>  
                  <a className="btn-action-cancel" href="/#">
                    <MdCancel /> Cancelar
                  </a>  
                </td>              </tr>
              <tr>
                <td>Allison Sousa Bahls</td>
                <td>Laboratorio de Informática</td>
                <td>15/01/2021</td>
                <td>08:00 </td>
                <td>09:00 </td>
                <td className="btn-action">
                  <a className="btn-action-delivered" href="/#">
                    <BsFillBookmarksFill /> Entregar
                  </a>
                  <a className="btn-action-edit" href="/#">
                    <AiTwotoneEdit /> Editar
                  </a>  
                  <a className="btn-action-cancel" href="/#">
                    <MdCancel /> Cancelar
                  </a>  
                </td>              </tr>
            </tbody>
          </table>
        </div>

        <div className="home-container">
          <div className="collaborators-content">
            <h1>Ultimas reservas realizadas</h1>
            <table className="table table-responsive">
              <thead>
                <tr>
                  <th>Colaborador</th>
                  <th>Equipamento</th>
                  <th>Ultima Solicitação</th>
                  <th>Data de Retirada</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>Allison Sousa Bahls</td>
                  <td>Laboratorio de Informática</td>
                  <td>15/01/2021</td>
                  <td>15/01/2021</td>
                </tr>
                <tr>
                  <td>Allison Sousa Bahls</td>
                  <td>Laboratorio de Informática</td>
                  <td>15/01/2021</td>
                  <td>15/01/2021</td>
                </tr>
              </tbody>
            </table>
          </div>
          <div className="equipments-content">
            <h1>Equipamentos mais reservados</h1>
            <table className="table table-responsive">
              <thead>
                <tr>
                  <th>Item</th>
                  <th>Total</th>
                  <th>Ultima vez retirado</th>
                </tr>
                
              </thead>
              <tbody>
                <tr>
                  <td>Laboratorio de Informática</td>
                  <td>15</td>
                  <td>15/01/2021</td>
                </tr>
                <tr>
                  <td>Laboratorio de Informática</td>
                  <td>15</td>
                  <td>15/01/2021</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </>
  );
}
