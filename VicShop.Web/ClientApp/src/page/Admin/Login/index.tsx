import React, { useEffect, useState } from "react";
import { bindActionCreators, compose } from "redux";
import { Container, Link, Form, Input, Button, Title, Wrapper } from "./styles";
import { auth } from "./action";
import { connect, useDispatch } from "react-redux";
import { Iprops } from "./modules";
import { createStructuredSelector } from "reselect";
import { makeSelectLoginStatus } from "./selectors";
import { useHistory } from "react-router";
const Login = (props: Iprops) => {
  const { isLoggedIn, location } = props;
  const  returnUrl  = location?.state?.from?.pathname; 
  const history = useHistory();
  const dispatch = useDispatch();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  useEffect(() => {   
    if (isLoggedIn) {
      if (returnUrl) {
        return  history.push(returnUrl);
      }
      return history.push("/admin");
    }
  }, [isLoggedIn]);

  const onHandleSubmit = (e: React.SyntheticEvent<EventTarget>) => {
    e.preventDefault();
    dispatch(auth(email, password));
  };
  return (
    <Container>
      <Wrapper>
        <Title>ĐĂNG NHẬP</Title>
        <Form>
          <Input
            placeholder="Tên đăng nhập"
            type="text"
            name="usename"
            onChange={(e) => setEmail(e.target.value)}
            value={email}
          />
          <Input
            placeholder="Mật khẩu"
            type="password"
            name="password"
            onChange={(e) => setPassword(e.target.value)}
            value={password}
          />
          <Button onClick={onHandleSubmit}>Đăng nhập</Button>
          <Link>Nhớ mật khẩu?</Link>
          <Link>Tạo tài khoản</Link>
        </Form>
      </Wrapper>
    </Container>
  );
};
function mapStateToProps(state: any) {
  return {
    isLoggedIn: state.loginReducer.isLoggedIn,
  };
}
export default connect(mapStateToProps)(Login);
