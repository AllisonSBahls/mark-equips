import {BrowserRouter, Route, Switch} from "react-router-dom";
import Login from "./Views/Login";
import Collaborator from "./Views/Collaborator";

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login}>
                </Route>
                <Route path="/colaboradores">
                    <Collaborator />
                </Route>
            </Switch>
        </BrowserRouter>
    );
}