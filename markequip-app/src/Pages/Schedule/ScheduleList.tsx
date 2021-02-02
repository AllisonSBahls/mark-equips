import { AiFillEdit, AiFillDelete } from "react-icons/ai";
import { BiAddToQueue } from "react-icons/bi";

export default function ScheduleList({morning, afternoon, night, onClickInfo, onClickOpenModal} : any){
    return(
        <div className="content-schedule">
        <div className="table-content">
          <h3>
            Horários: Manha
            <button className="btn-schedule btn-insert-schedule" onClick={() => onClickOpenModal(true)}>
              <BiAddToQueue className="icon" />
            </button>
          </h3>
          <table className="table-schedule table-schedule-responsive">
            <thead>
              <tr >
                <th>Inicio</th>
                <th>Final</th>
                <th>Ações</th>
              </tr>
            </thead>
            
            <tbody>
            {morning.map((schedule) => (
              <tr key={schedule.id}>
                <td>{schedule.hourInitial}</td>
                <td>{schedule.hourFinal}</td>
                <td>
                  <button className="btn-schedule btn-edit" onClick={() => onClickInfo(schedule.id)}>
                    <AiFillEdit className="icon" />
                  </button>
                  <button className="btn-schedule btn-delete">
                    <AiFillDelete className="icon" />
                  </button>
                </td>
              </tr>
              ))}
            </tbody>
            </table>
        </div>

     
        <div className="table-content">
          <h3>
            Horários: Tarde
            <button className="btn-schedule btn-insert-schedule" onClick={() => onClickOpenModal(true)}>
              <BiAddToQueue className="icon" />
            </button>
          </h3>
          <table className="table-schedule table-schedule-responsive">
            <thead>
              <tr>
                <th>Inicial</th>
                <th>Final</th>
                <th>Ações</th>
              </tr>
            </thead>
            <tbody>
            {afternoon.map((schedule) => (
              <tr key={schedule.id}>
                <td>{schedule.hourInitial}</td>
                <td>{schedule.hourFinal}</td>
                <td>
                  <button className="btn-schedule btn-edit"  onClick={() => onClickInfo(schedule.id)}>
                    <AiFillEdit className="icon" />
                  </button>
                  <button className="btn-schedule btn-delete">
                    <AiFillDelete className="icon" />
                  </button>
                </td>
              </tr>
              ))}
            </tbody>
          </table>
        </div>
        <div className="table-content">
          <h3>
            Horário: Noite
            <button className="btn-schedule btn-insert-schedule" onClick={() => onClickOpenModal(true)} >
              <BiAddToQueue className="icon" />
            </button>
          </h3>
          <table className="table-schedule table-schedule-responsive">
            <thead>
              <tr>
                <th>Inicial</th>
                <th>Final</th>
                <th>Ações</th>
              </tr>
            </thead>
            <tbody>
            {night.map((schedule) => (
              <tr key={schedule.id}>
                <td>{schedule.hourInitial}</td>
                <td>{schedule.hourFinal}</td>
                <td>
                  <button className="btn-schedule btn-edit"  onClick={() => onClickInfo(schedule.id)}>
                    <AiFillEdit className="icon" />
                  </button>
                  <button className="btn-schedule btn-delete">
                    <AiFillDelete className="icon" />
                  </button>
                </td>
              </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    )
}