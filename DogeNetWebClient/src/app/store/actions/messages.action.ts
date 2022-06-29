import { createAction, props } from '@ngrx/store';
import { MessagesDetailsModel } from 'src/app/core/api/models';

export const SetNewDialogue = createAction(
  '[Messages] Set_Dialogue',
  props<{ id: number; messages: MessagesDetailsModel[] }>()
);
export const SendMessage = createAction(
  '[Messages] Send',
  props<{ id: number; message: MessagesDetailsModel }>()
);
export const DeleteMessage = createAction(
  '[Messages] Delete',
  props<{ id: number; message: MessagesDetailsModel }>()
);
export const EditMessage = createAction(
  '[Messages] Edit',
  props<{ id: number; message: MessagesDetailsModel }>()
);
export const DeleteDialogue = createAction(
  '[Messages] Delete_Dialogue',
  props<{ payload: number }>()
);
