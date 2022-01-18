import { createSelector } from "reselect";
import { initialState } from "../../page/Admin/Login/reducer";
const selectLoginState = (state: any) => initialState;

const makeSelectLoginStatus = () =>
  createSelector(selectLoginState, (loginState) => loginState.isLoggedIn);
const makeSelectLoginToken = () =>
  createSelector(selectLoginState, (loginState) =>
    loginState.token
  );
export { makeSelectLoginStatus, makeSelectLoginToken };
