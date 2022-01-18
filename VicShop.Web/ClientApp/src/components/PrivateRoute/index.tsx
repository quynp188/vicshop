import React, { useEffect } from "react";
import { connect } from "react-redux";
import { Route, Redirect } from "react-router-dom";
import { createStructuredSelector } from "reselect";
import { makeSelectLoginStatus } from "../PrivateRoute/selectors";
import jwt_decode, { JwtPayload } from "jwt-decode";
import { ACCESS_TOKEN } from "../../commons/constants";
const PrivateRoute = (props: any) => {
  const { isLoggedIn, expiration, component: Component, page, ...rest } = props;
  useEffect(() => {
    let token = localStorage.getItem(ACCESS_TOKEN);
    if (token) {
      let decodedToken =jwt_decode<JwtPayload>(JSON.stringify(token));
      let currentDate = new Date();
      const {exp} = decodedToken;
      // JWT exp is in seconds
      if (exp && exp * 1000 < currentDate.getTime()) {
        localStorage.removeItem(ACCESS_TOKEN);
      } 
    }
  }, []);
  return (
    <Route
      {...rest}
      render={(props) =>
        isLoggedIn === true ? (
          <Component {...props} />
        ) : (
          <Redirect
            to={{
              pathname: `/${page}/login`,
              state: { from: props.location },
            }}
          />
        )
      }
    />
  );
};
function mapStateToProps(state: any) {
  return {
    isLoggedIn: state.loginReducer.isLoggedIn,
    expiration: state.loginReducer.expiration,
  };
}
export default connect(mapStateToProps)(PrivateRoute);
