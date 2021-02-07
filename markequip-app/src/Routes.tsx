import {BrowserRouter, Route, Switch} from "react-router-dom";
import Login from "./Pages/Login";
import Collaborator from "./Pages/Collaborator";
import Schedule from "./Pages/Schedule";
import Equipment from "./Pages/Equipments";
import Home from "./Pages/Home";

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact> 
                    <Login/>
                </Route>
                <Route path="/inicio" exact> 
                    <Home/>
                </Route>
                <Route path="/colaboradores" exact>
                    <Collaborator />
                </Route>
                <Route path="/equipamentos" exact>
                    <Equipment />
                </Route>         
                <Route path="/horarios" exact>
                    <Schedule />
                </Route>           
            </Switch>
        </BrowserRouter>
    );
}