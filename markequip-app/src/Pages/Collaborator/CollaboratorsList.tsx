import { AiFillEdit, AiFillDelete } from "react-icons/ai";

export default function CollaboratorList({collaborators, deleteCollaborator, onClickInfo}: any){
    
  return(
        <table className="table table-responsive">
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
                  <button onClick={() => onClickInfo(collaborator.id)} className="btn-action btn-edit" >
                    <AiFillEdit className="icon" /> Editar
                  </button>
                  <button 
                    className="btn-action btn-delete"
                    onClick= {() => {
                      if(window.confirm(`Você tem certeza que deseja remover o Colaborador: ${collaborator.fullName}`))
                          {deleteCollaborator(collaborator.id)}
                      }}>
                    <AiFillDelete className="icon" /> Excluir
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

    );
}