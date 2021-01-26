import {BrowserRouter, Route, Switch} from "react-router-dom";
import Login from "./Views/Login";
import Collaborator from "./Views/Collaborator";
import Register from "./Views/Collaborator/register";

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login}>
                </Route>
                <Route path="/colaboradores" exact>
                    <Collaborator />
                </Route>
                <Route path="/colaboradores/register">
                    <Register />
                </Route>
            </Switch>
        </BrowserRouter>
    );
}