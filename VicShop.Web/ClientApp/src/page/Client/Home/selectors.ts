import { createSelector } from "reselect";
import { initialState } from "./reducer";
const selectHomeState = (state: any) => state.homeReducer;
export const makeSelectProductState = () =>
  createSelector(selectHomeState, (homeState) => homeState.products);

 