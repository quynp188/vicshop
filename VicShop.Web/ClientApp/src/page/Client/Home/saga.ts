import { requestProductDataSucess, requestProductDataFailed } from "./action";
import { call, takeLatest, put } from "redux-saga/effects";
import ActionTypes from "./constants";
import StatusCodes from "../../../commons/constants";
import { get } from "../../../commons/axiosService";
import { IRequestData } from "./modules";
export function* homeRequestsWatcher() {
  yield takeLatest(ActionTypes.REQUEST_PRODUCT_DATA, productRequestTask);
}
export function* productRequestTask(): any {
  let response = yield call(authRequestAxios);
  if (response) {
    if (response.status === StatusCodes.Ok) {
      const products = response.data.value;
      yield put(requestProductDataSucess(products));
    } else {
      const { message } = response;
      yield put(requestProductDataFailed(message));
    }
  }
}
async function authRequestAxios() {
  return get("odata/Product");
}
