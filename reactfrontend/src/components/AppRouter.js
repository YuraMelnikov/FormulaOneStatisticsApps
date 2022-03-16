import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { publicRoutes } from '../Routes';
import { SEASONS_ROUTE } from "../utils/Consts";

const AppRouter = () => {
    return (
        <Switch>
            {publicRoutes.map(({path, Component}) =>
                <Route key={path} path={path} component={Component} exact/>
            )}
            <Redirect to={SEASONS_ROUTE}/>
        </Switch>
    );
}

export default AppRouter;