import { AnyAction } from "redux";
import { ACCESS_TOKEN } from "../../../commons/constants";
import ActionTypes from "./constants";
import { ILoginAction, IState } from "./modules";
export const initialState: IState = {
  token: "",
  isLoggedIn: !!localStorage.getItem(ACCESS_TOKEN),
  email: "",
  message: "",
  expiration: "",
  fullName: "",
};
const loginReducer = (state = initialState, action: ILoginAction) => {
  switch (action.type) {
    case ActionTypes.AUTH_LOGIN_SUCCESS:
      localStorage.setItem(ACCESS_TOKEN, JSON.stringify(action.token));
      return {
        ...state,
        isLoggedIn: true,
        token: action.token,
        email: action.email,
        expiration: action.expiration,
        fullName: action.fullName,
      };
    case ActionTypes.AUTH_LOGOUT:
      localStorage.removeItem(ACCESS_TOKEN);
      return {
        ...state,
        isLoggedIn: false,
        token: "",
        email: "",
        expiration: "",
        fullName: "",
      };

    case ActionTypes.AUTH_LOGIN_FAILED:
      return { ...state, isLoggedIn: false, message: action.message };
    default:
      return state;
  }
};
export default loginReducer;
