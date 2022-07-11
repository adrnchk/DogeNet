import { createAction, props } from '@ngrx/store';
import { AccountDetailsModel } from 'src/app/core/api/models';

export const SetUserInfo = createAction('[UserInfo] Set');
export const SetUserInfoSuccess = createAction(
  '[UserInfo] Set_Success',
  props<{ payload: AccountDetailsModel }>()
);
export const ClearUserInfo = createAction('[UserInfo] Clear');
