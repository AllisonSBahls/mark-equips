import {BrowserRouter, Route, Switch} from "react-router-dom";
 import Home from "./Views/Home"
// import Navbar from "./Views/Navbar";
// import Footer from "./Views/Footer";
import Login from "./Views/Login";

export default function Routes(){
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" component={Login}>
                </Route>
                <Route path="/inicio" component={Home}>
                </Route>
            </Switch>
        </BrowserRouter>
    );
}