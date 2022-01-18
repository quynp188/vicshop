import { fork, all } from "redux-saga/effects";
import { authRequestsWatcher } from "../page/Admin/Login/saga";
import { homeRequestsWatcher } from "../page/Client/Home/saga";
function* rootSaga() {
  yield all([fork(authRequestsWatcher), fork(homeRequestsWatcher)]);
}
export default rootSaga;
