import { loginSuccess, loginFailed } from "./action";
import { call, takeLatest, put } from "redux-saga/effects";
import ActionTypes from "./constants";
import StatusCodes from "../../../commons/constants";
import { post } from "../../../commons/axiosService";
import { IRequestData } from "./modules";
export function* authRequestsWatcher() {
  yield takeLatest(ActionTypes.AUTH_ACTION, authRequestTask);
}
export function* authRequestTask(action: IRequestData): any {
  const { email, password } = action;
  let response = yield call(authRequestAxios, email, password);
  if (response) {
    if (
      response.status === StatusCodes.Ok ||
      response.status === StatusCodes.Created
    ) {
      const { token, expiration, fullName } = response.data;
      yield put(loginSuccess(email, token, expiration, fullName));
    } else {
      const { message } = response;
      yield put(loginFailed(message));
    }
  }
  console.log("response", response);
}
async function authRequestAxios(email: string, password: string) {
  const param = {
    email,
    password,
  };
  return post("api/Account/login", param);
}
