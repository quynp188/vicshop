import { IRouter } from "./../../../commons/modules";
import {IProductData} from '../../../module/Product'
export interface Iprops extends IRouter {
  products?: Array<IProductData>;
}
export interface IRequestData {
  type: string;
}
export interface IState {
  products?: Array<IProductData>;
  message?:string;
}
export interface IResponseSucess {
  type: string;
  products: Array<IProductData>;
}
export interface IResponseFailed {
  type: string;
  message: string;
}
export interface IAction {
  type: string;  
  products: Array<IProductData>;
  message: string;
}
