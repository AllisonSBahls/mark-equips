import {BrowserRouter, Route, Switch} from "react-router-dom";
import Login from "./Views/Login";
import Collaborator from "./Views/Collaborator";
import Register from "./Views/Collaborator/register";
import Sidebar from "./Views/Sidebar";
import Schedule from "./Views/Schedule";

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login}>
                </Route>
                <Route path="/colaboradores" exact>
                    <Collaborator />
                </Route>
                <Route path="/colaborador/form/:collaboratorId" exact>
                    <Register />
                </Route>
                <Route path="/sidebar" exact>
                    <Sidebar />
                </Route>           
                <Route path="/horarios" exact>
                    <Schedule />
                </Route>           
            </Switch>
        </BrowserRouter>
    );
}