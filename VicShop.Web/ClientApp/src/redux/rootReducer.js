import { combineReducers } from "redux";
import loginReducer from '../page/Admin/Login/reducer';
import homeReducer from '../page/Client/Home/reducer';
const rootReducer = combineReducers({
    loginReducer,
    homeReducer
});
export default rootReducer;