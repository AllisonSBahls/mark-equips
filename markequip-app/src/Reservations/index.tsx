import "./styles.css";

export default function Reservations() {
  return (
    <>
      <div className="container">
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
                <th>Ação</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Allison Sousa Bahls</td>
                <td>Laboratorio de Informática</td>
                <td>15/01/2021</td>
                <td>08:00 </td>
                <td>09:00 </td>
                <td>Guardar</td>
              </tr>
              <tr>
                <td>Allison Sousa Bahls</td>
                <td>Laboratorio de Informática</td>
                <td>15/01/2021</td>
                <td>08:00 </td>
                <td>09:00 </td>

                <td>Finalizar</td>
              </tr>
              <tr>
                <td>Allison Sousa Bahls</td>
                <td>Laboratorio de Informática</td>
                <td>15/01/2021</td>
                <td>08:00 </td>
                <td>09:00 </td>
                <td>Finalizar</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
}
