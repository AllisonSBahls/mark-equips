import {
  BrowserRouter,
  Redirect,
  Route,
  RouteProps,
  Switch,
} from "react-router-dom";
import Login from "./Pages/Login";
import Collaborator from "./Pages/Collaborator";
import Schedule from "./Pages/Schedule";
import Equipment from "./Pages/Equipments";
import Home from "./Pages/Home";
import { isAuthenticated } from "./auth";

interface PrivateRouteProps extends RouteProps {
  // tslint:disable-next-line:no-any
  component: any;
}

const PrivateRoute = (props: PrivateRouteProps) => {
  const { component: Component, ...rest } = props;

  return (
    <Route
      {...rest}
      render={(RouteProps) => 
        isAuthenticated() ? (
          <Component {...props} />
        ) : (
          <Redirect to={{ pathname: "/", state: { from: RouteProps.location } }} />
        )
      }/>
  );
};

export default function Routes() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact>
          <Login />
        </Route>
        <PrivateRoute path="/inicio" exact component={Home}/>
        <PrivateRoute path="/colaboradores" exact component={Collaborator} />
        <PrivateRoute path="/equipamentos"  exact component={Equipment}/>
        <PrivateRoute path="/horarios" exact component={Schedule}/>
      </Switch>
    </BrowserRouter>
  );
}
