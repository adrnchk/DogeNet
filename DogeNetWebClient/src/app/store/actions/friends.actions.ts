import { createAction, props } from '@ngrx/store';
import { FriendsDetailsModel } from 'src/app/core/api/models';

export const SetFriends = createAction(
  '[Friends] Set_Friends',
  props<{ friends: FriendsDetailsModel[] }>()
);
export const ClearFriends = createAction('[Friends] Clear_Friends');
export const AddFriend = createAction(
  '[Friends] Add',
  props<{ id: number; friend: FriendsDetailsModel }>()
);
export const DeleteFriend = createAction(
  '[Friends] Delete',
  props<{ id: number }>()
);
