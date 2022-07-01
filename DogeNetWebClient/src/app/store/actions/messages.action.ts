import { createAction, props } from '@ngrx/store';
import { MessagesDetailsModel } from 'src/app/core/api/models';

export const SetMessages = createAction(
  '[Messages] Set_Messages',
  props<{ messages: MessagesDetailsModel[] }>()
);
export const AddMessage = createAction(
  '[Messages] Add',
  props<{ message: MessagesDetailsModel }>()
);
export const DeleteMessage = createAction(
  '[Messages] Delete',
  props<{ id: number }>()
);
export const EditMessage = createAction(
  '[Messages] Edit',
  props<{ message: MessagesDetailsModel }>()
);
export const ClearMessages = createAction('[Messages] Clear_Messages');
