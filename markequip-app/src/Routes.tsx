import {BrowserRouter, Redirect, Route, Switch} from "react-router-dom";
import Login from "./Pages/Login";
import Collaborator from "./Pages/Collaborator";
import Schedule from "./Pages/Schedule";
import Equipment from "./Pages/Equipments";
import Home from "./Pages/Home";
import {isAuthenticated} from './auth';


const PrivateRoute = ({component: Component, ...rest} : any) => (
    <Route {...rest} render={props => {
        isAuthenticated() ? (
            <Component {...props} /> 
            ): (
                <Redirect to={{pathname: '/', state: {from: props.location}}}/>
            )
        }
    } />
)
    

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
                <PrivateRoute path="/colaboradores" exact component={Collaborator}/>
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