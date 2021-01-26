import "./styles.css";
import Footer from "../Footer";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";

export default function Register(){
    return(
        <>
        <Navbar />
        <Sidebar/>
        <div className="background-effect">
        </div>
        <div className="register-container">
        <div className="register">
          <h3 className="subtitle">Registrar Colaborador</h3>
          <form className="form-collaborator">
            <div className="collaborator">
              <div className="input-field input-name">
                <label>Nome: </label>
                <input
                  type="text"
                  className="input"
                  placeholder="Insira o nome completo"
                ></input>
              </div>
              <div className="user">
              <div className="input-field input-user">
                <label>Usuário: </label>
                <input
                  type="text"
                  className="input"
                  placeholder="Insira o usuário"
                ></input>
              </div>
              <div className="input-field input-password">
                <label>Senha: </label>
                <input
                  type="text"
                  className="input"
                  placeholder="Insira a senha"
                ></input>
              </div>
              </div>
            </div>
            <div className="roles">
              <h4>Função</h4>
              <div className="radio">
                <label>Colaborador</label>
                <input
                  type="radio"
                  id="collaborator"
                  name="role"
                  value="collaborator"
                />
                <label>Administrador</label>
                <input
                  type="radio"
                  id="administrator"
                  name="role"
                  value="administrator"
                />
              </div>
            </div>
            <div className="form-button">
              <input type="submit" className="button-save" value="Salvar"></input>
            </div>
          </form>
        </div>
      </div>
     <Footer />
    </>
    );
}
