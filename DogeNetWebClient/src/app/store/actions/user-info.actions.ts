import { Action, createAction, props } from '@ngrx/store';
import { AccountDetailsModel } from 'src/app/core/api/models';

export const SET_USER_INFO = '[UserInfo] Set';
export const CLEAR_USER_INFO = '[UserInfo] Clear';

export const SetUserInfo = createAction(
  SET_USER_INFO,
  props<{ payload: AccountDetailsModel }>()
);
export const ClearUserInfo = createAction(CLEAR_USER_INFO);
