function radioAdministrator(){
    return(
      <>
      <label>Administrator</label>
      <input
      type="radio"
      id="administrator"
      name="role"
      value="role"
    ></input>
    </>
    )
  }
  
function radioCollaborator(){
    return(
      <input
      type="radio"
      id="Collaborator"
      name="role"
      value="role"
    ></input>
    );
  }
  
export default  function radioRole(funcao: string){
    if (funcao ==="Administrator"){
      radioAdministrator();
    }else{
      radioCollaborator();
    }
  }
  