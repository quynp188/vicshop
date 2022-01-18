import { AnyAction } from "redux";
import ActionTypes from "./constants";
import { IAction, IState } from "./modules";
export const initialState: IState = {
  products: [],
  message: "",
};
const homeReducer = (state = initialState, action: IAction) => {
  switch (action.type) {
    case ActionTypes.REQUEST_PRODUCT_DATA_SUCCESS:
      return {
        ...state,
        products: action.products,
      };
    case ActionTypes.REQUEST_PRODUCT_DATA_FAILED:
      return {
        ...state,
        message: action.message,
      };
    default:
      return state;
  }
};
export default homeReducer;
