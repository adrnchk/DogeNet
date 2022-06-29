import { Action, createAction, props } from '@ngrx/store';
import { AccountDetailsModel } from 'src/app/core/api/models';

export const SetUserInfo = createAction(
  '[UserInfo] Set',
  props<{ payload: AccountDetailsModel }>()
);
export const ClearUserInfo = createAction('[UserInfo] Clear');
