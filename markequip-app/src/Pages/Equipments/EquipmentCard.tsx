export default function EquipmentCard({equipment, onClickInfo}: any) {

  return (
    <>
        <div className="equipment">
          <div className="equipment-title">
            <h4 className="equipment-name">{equipment.name}</h4>
            <h5 className="equipment-tombo">Nº {equipment.number}</h5>
          </div>
          <div className="equipment-description">
            <p className="equipment-description-title">Descrição: </p>
            <p>
              {equipment.description}
            </p>
          </div>
          <div className="equipment-btn-action">
            <button className="equipment-btn-reserver">Reservar</button>
            <button className="equipment-btn-delete">Deletar</button>
            <button className="equipment-btn-edit" onClick={() => onClickInfo(equipment.id)}>Editar</button>
          </div>
        </div>
    </>
  );
}
