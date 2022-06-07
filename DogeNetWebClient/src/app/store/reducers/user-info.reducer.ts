import { Action, createReducer, on } from '@ngrx/store';
import * as Actions from 'src/app/store/actions/user-info.actions';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserState } from '../states/UserState';

const initialState: UserState = {
  info: {
    avatarImg: '',
    bio: '',
    cityId: 0,
    coverImg: '',
    createdAt: '',
    firstName: '',
    id: 0,
    identityId: '',
    lastName: '',
    statusId: 0,
    title: '',
    updatedAt: '',
    userName: '',
  },
};

export const userNode = 'user';

export const userReducer = createReducer(
  initialState,
  on(Actions.SetUserInfo, (state, { payload }) => ({
    ...state,
    info: payload,
  })),
  on(Actions.ClearUserInfo, (state) => ({
    ...state,
    info: initialState.info,
  }))
);
