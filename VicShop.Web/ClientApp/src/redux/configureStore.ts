import { createStore, applyMiddleware, compose } from "redux";
import createSagaMiddleware from 'redux-saga'
import rootReducer from "./rootReducer";
import rootSaga from './rootSaga';
const composeEnhancers =
  process.env.NODE_ENV !== "production" &&
  window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
    ? window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
    : compose;
// Create the saga middleware
const sagaMiddleware = createSagaMiddleware()
const configureStore = () => {
  const middlewares = [sagaMiddleware];
  const enhancers = [applyMiddleware(...middlewares)];
  const store = createStore(rootReducer, composeEnhancers(...enhancers));
 sagaMiddleware.run(rootSaga)
  return store;
};
export default configureStore;
