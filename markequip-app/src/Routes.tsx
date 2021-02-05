import {BrowserRouter, Route, Switch} from "react-router-dom";
import Login from "./Pages/Login";
import Collaborator from "./Pages/Collaborator";
import Sidebar from "./Pages/Sidebar";
import Schedule from "./Pages/Schedule";
import Equipment from "./Pages/Equipments";
import Reservations from "./Pages/Reservations";

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login}>
                </Route>
                <Route path="/colaboradores" exact>
                    <Collaborator />
                </Route>
                <Route path="/equipamentos" exact>
                    <Equipment />
                </Route>
                <Route path="/sidebar" exact>
                    <Sidebar />
                </Route>           
                <Route path="/horarios" exact>
                    <Schedule />
                </Route>           
                <Route path="/reservas" exact>
                    <Reservations />
                </Route>           
            </Switch>
        </BrowserRouter>
    );
}