export default function EquipmentCard({
  equipment,
  onClickInfo,
  deleteEquipment,
  onClickReserver
}: any) {
  return (
    <>
      <div className="equipment">
        <div className="equipment-title">
          <h4 className="equipment-name">{equipment.name}</h4>
          <h5 className="equipment-tombo">Nº {equipment.number}</h5>
        </div>
        <div className="equipment-description">
          <p>{equipment.description}</p>
        </div>
        <div className="equipment-btn-action">
          <button className="equipment-btn-reserver" onClick={() => onClickReserver(equipment.id)}>Reservar</button>
          {/* <button
            className="equipment-btn-delete"
            onClick={() => {
              if (window.confirm(`Você tem certeza que deseja remover o(a): ${equipment.name}`)) { 
                deleteEquipment(equipment.id); 
              }
            }}>
            Deletar
          </button> */}
          {/* <button
            className="equipment-btn-edit"
            onClick={() => onClickInfo(equipment.id)}
          >
            Editar
          </button> */}
        </div>
      </div>
    </>
  );
}
