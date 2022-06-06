import { Action } from '@ngrx/store';
import { AccountDetailsModel } from 'src/app/core/api/models';

export const SET_USER_INFO = '[UserInfo] Set';
export const CLEAR_USER_INFO = '[UserInfo] Clear';

export class SetUserInfo implements Action {
  readonly type = SET_USER_INFO;
  constructor(public payload: AccountDetailsModel) {}
}

export class ClearUserInfo implements Action {
  readonly type = CLEAR_USER_INFO;
}

export type All = SetUserInfo | ClearUserInfo;
