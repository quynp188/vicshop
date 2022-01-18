import ActionTypes from "./constants";
import { IResponseFailed, IResponseSucess } from "./modules";
export const auth = (email: string, password: string) => ({
  type: ActionTypes.AUTH_ACTION,
  email,
  password,
});
export const loginSuccess = (
  email: string,
  token: string,
  expiration: string,
  fullName: string
): IResponseSucess => ({
  type: ActionTypes.AUTH_LOGIN_SUCCESS,
  token,
  email,
  expiration,
  fullName,
});
export const loginFailed = (message: string): IResponseFailed => ({
  type: ActionTypes.AUTH_LOGIN_FAILED,
  message,
});
export const logout = () => ({
  type: ActionTypes.AUTH_LOGOUT,
});
