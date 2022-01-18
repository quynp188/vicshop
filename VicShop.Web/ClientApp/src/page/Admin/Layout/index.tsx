import React from "react";
import { Route } from "react-router-dom";
import Sidebar from "../../../components/Admin/Sidebar";
import Topbar from "../../../components/Admin/Topbar";
import Home from "../Home";
import { Iprops } from "./module";
import { Container, MainContent } from "./styles";
import PrivateRoute from "../../../components/PrivateRoute";
import { connect, useDispatch } from "react-redux";
import { logout } from "../Login/action";
const Layout = (props: Iprops) => {
  const { component,fullName, ...rest} = props;
  const dispatch = useDispatch();
  const onHandleLogoutHandle = () => {
    dispatch(logout());
  };
  return (
    <>
      <Topbar onHandleLogout={onHandleLogoutHandle} fullName={fullName} />
      <Container>
        <Sidebar />
        <MainContent>
          <PrivateRoute {...rest} component={component} page="admin" />         
        </MainContent>
      </Container>
    </>
  );
};
function mapStateToProps(state: any) {
  return {
    fullName: state.loginReducer.fullName,
  };
}
export default connect(mapStateToProps)(Layout);
