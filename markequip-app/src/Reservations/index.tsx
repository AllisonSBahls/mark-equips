import './styles.css';

export default function Reservations() {
    return (
        <div className="reservations-container">
            <table className="table table-responsive">
                <thead>
                    <tr>
                        <th>Colaborador</th>
                        <th>Equipamento</th>
                        <th>Data da Reserva</th>
                        <th>Recebimento</th>
                        <th>Ação</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Allison Sousa Bahls</td>
                        <td>Laboratorio de Informática</td>
                        <td>15/01/2021</td>
                        <td>08:00 - 09:00</td>
                        <td>Guardar</td>

                    </tr>
                    <tr>
                        <td>Allison Sousa Bahls</td>
                        <td>Laboratorio de Informática</td>
                        <td>15/01/2021</td>
                        <td>08:00 - 09:00</td>
                        <td>Finalizar</td>

                    </tr>
                    <tr>
                        <td>Allison Sousa Bahls</td>
                        <td>Laboratorio de Informática</td>
                        <td>15/01/2021</td>
                        <td>08:00 - 09:00</td>
                        <td>Finalizar</td>

                    </tr>
                </tbody>
            </table>
        </div>
    );
}