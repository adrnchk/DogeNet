import { createReducer, on } from '@ngrx/store';
import * as Actions from 'src/app/store/actions/user-info.actions';
import { initialState } from '../states/UserState';

export const userNode = 'user';

export const userReducer = createReducer(
  initialState,
  on(Actions.SetUserInfoSuccess, (state, { payload }) => ({
    ...state,
    info: payload,
  })),
  on(Actions.ClearUserInfo, (state) => ({
    ...state,
    info: initialState.info,
  }))
);
