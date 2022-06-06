import { Action } from '@ngrx/store';
import * as UserActions from 'src/app/actions/user-info.actions';
import { AccountDetailsModel } from 'src/app/core/api/models';

export interface UserState {
  info: AccountDetailsModel;
}

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

export const userReducer = (
  state = initialState,
  action: UserActions.All
): UserState => {
  switch (action.type) {
    case UserActions.SET_USER_INFO:
      return { ...state, info: action.payload };
    case UserActions.CLEAR_USER_INFO:
      return { ...state, info: initialState.info };
  }
  return state;
};
