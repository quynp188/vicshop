import React from "react";
import { Provider } from "react-redux";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { IRouter } from "./commons/modules";
import Layout from "./page/Admin/Layout";
import { AdminRoutes } from "./page/Admin/Routes";
import { ClientRoutes } from "./page/Client/Routes";
import configureStore from "./redux/configureStore";
import ChatBox from "./page/Client/ChatBox";
const store = configureStore();
const App = () => {
  const renderAdminRoutes = () => {
    return AdminRoutes.map((route: IRouter) => {
      if (route.withoutLayout) {
        return (
          <Route
            key={route.path}
            path={route.path}
            exact={route.exact}
            render={(routeProps) => (
              <route.component title={route.name} {...routeProps} />
            )}
          />
        );
      }
      return (
        <Layout
          key={route.path}
          name={route.name}
          path={route.path}
          exact={route.exact}
          component={route.component}
        />
      );
    });
  };
  const renderClientRoutes = () => {
    return (
      <>
        {ClientRoutes.map((route: IRouter) => (
          <Route
            key={route.path}
            path={route.path}
            exact={route.exact}
            render={(routeProps) => (
              <route.component title={route.name} {...routeProps} />
            )}
          />
        ))}
        <ChatBox />
      </>
    );
  };
  return (
    <Provider store={store}>
      <BrowserRouter>
        <Switch>
          {renderAdminRoutes()}
          {renderClientRoutes()}
        </Switch>
      </BrowserRouter>
    </Provider>
  );
};

export default App;
