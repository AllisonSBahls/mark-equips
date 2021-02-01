import { AiFillEdit, AiFillDelete } from "react-icons/ai";
import { BiAddToQueue } from "react-icons/bi";

export function ScheduleListMorning({ morning, onClickInfo}: any) {
  return (
        <tr key={morning.id}>
          <td>{morning.hourInitial}</td>
          <td>{morning.hourFinal}</td>
          <td>
            <button className="btn-schedule btn-edit" onClick={onClickInfo}>
              <AiFillEdit className="icon" />
            </button>
            <button className="btn-schedule btn-delete">
              <AiFillDelete className="icon" />
            </button>
          </td>
        </tr>
  )
};

export function ScheduleListAfternoon({ afternoon, onClickInfo }: any) {
    return (
        <tr key={afternoon.id}>
          <td>{afternoon.hourInitial}</td>
          <td>{afternoon.hourFinal}</td>
          <td>
            <button className="btn-schedule btn-edit" onClick={onClickInfo}>
              <AiFillEdit className="icon" />
            </button>
            <button className="btn-schedule btn-delete">
              <AiFillDelete className="icon" />
            </button>
          </td>
        </tr>
    );
};

export function ScheduleListNight({ night, onClickInfo}: any) {
    return (
        <tr key={night.id}>
          <td>{night.hourInitial}</td>
          <td>{night.hourFinal}</td>
          <td>
            <button className="btn-schedule btn-edit" onClick={onClickInfo}>
              <AiFillEdit className="icon" />
            </button>
            <button className="btn-schedule btn-delete">
              <AiFillDelete className="icon" />
            </button>
          </td>
        </tr>
  );
}
