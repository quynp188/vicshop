import { IRouter } from "./../../../commons/modules";
export interface Iprops extends IRouter {
  isLoggedIn?: boolean;
  token?: string;
  location: any;
}
export interface IRequestData {
  email: string;
  password: string;
  type: string;
}
export interface IState {
  isLoggedIn: boolean;
  token: string;
  email: string;
  message: string;
  expiration: string;
  fullName: string;
}
export interface IResponseSucess {
  type: string;
  token: string;
  email: string;
  expiration: string;
  fullName: string;
}
export interface IResponseFailed {
  type: string;
  message: string;
}
export interface ILoginAction {
  type: string;
  token?: string;
  email?: string;
  message?: string;
  expiration?: string;
  fullName?: string;
}
