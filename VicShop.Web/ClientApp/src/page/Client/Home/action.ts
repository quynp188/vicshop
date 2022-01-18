import { IProductData } from "../../../module/Product";
import ActionTypes from "./constants";
import { IResponseFailed, IResponseSucess } from "./modules";
export const requestProductData = () => ({
  type: ActionTypes.REQUEST_PRODUCT_DATA,
});
export const requestProductDataSucess = (products:Array<IProductData>): IResponseSucess => ({
  type: ActionTypes.REQUEST_PRODUCT_DATA_SUCCESS,
  products
});
export const requestProductDataFailed = (message: string): IResponseFailed => ({
  type: ActionTypes.REQUEST_PRODUCT_DATA_FAILED,
  message,
});
