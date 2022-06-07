import { createAction, props } from '@ngrx/store';
import { MessagesDetailsModel } from 'src/app/core/api/models';

export const SET_NEW_DIALOGUE = '[Messages] Set_Dialogue';
export const DELETE_DIALOGUE = '[Messages] Delete_Dialogue';
export const SEND_MESSAGE = '[Messages] Send';
export const DELETE_MESSAGE = '[Messages] Delete';
export const EDIT_MESSAGE = '[Messages] Edit';

export const SetNewDialogue = createAction(
  SET_NEW_DIALOGUE,
  props<{ id: number; messages: MessagesDetailsModel[] }>()
);
export const SendMessage = createAction(
  SEND_MESSAGE,
  props<{ id: number; message: MessagesDetailsModel }>()
);
export const DeleteMessage = createAction(
  DELETE_MESSAGE,
  props<{ id: number; message: MessagesDetailsModel }>()
);
export const EditMessage = createAction(
  EDIT_MESSAGE,
  props<{ id: number; message: MessagesDetailsModel }>()
);
export const DeleteDialogue = createAction(
  DELETE_DIALOGUE,
  props<{ payload: number }>()
);
