import { Action } from '@ngrx/store';
import { MessagesDetailsModel } from 'src/app/core/api/models';

export const SET_NEW_DIALOGUE = '[Messages] Set_Dialogue';
export const DELETE_DIALOGUE = '[Messages] Delete_Dialogue';
export const SEND_MESSAGE = '[Messages] Send';
export const DELETE_MESSAGE = '[Messages] Delete';
export const EDIT_MESSAGE = '[Messages] Edit';

export class SetNewDialogue implements Action {
  readonly type = SET_NEW_DIALOGUE;
  constructor(
    public payload: { id: number; messages: MessagesDetailsModel[] }
  ) {}
}
export class SendMessage implements Action {
  readonly type = SEND_MESSAGE;
  constructor(public payload: { id: number; message: MessagesDetailsModel }) {}
}
export class DeleteMessage implements Action {
  readonly type = DELETE_MESSAGE;
  constructor(public payload: { id: number; message: MessagesDetailsModel }) {}
}
export class EditMessage implements Action {
  readonly type = EDIT_MESSAGE;
  constructor(public payload: { id: number; message: MessagesDetailsModel }) {}
}
export class DeleteDialogue implements Action {
  readonly type = DELETE_DIALOGUE;
  constructor(public payload: number) {}
}

export type All =
  | DeleteDialogue
  | EditMessage
  | DeleteMessage
  | SendMessage
  | SetNewDialogue;
