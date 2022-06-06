import { Action } from '@ngrx/store';
import { ConversationDetailsModel } from 'src/app/core/api/models';

export const SET_CONVERSATIONS = '[Conversations] Set';
export const ADD_CONVERSATION = '[Conversations] Add';
export const DELETE_CONVERSATION = '[Conversations] Delete';
export const CLEAR_CONVERSATIONS = '[Conversations] Clear';

export class SetConversations implements Action {
  readonly type = SET_CONVERSATIONS;
  constructor(public payload: ConversationDetailsModel[]) {}
}
export class AddConversation implements Action {
  readonly type = ADD_CONVERSATION;
  constructor(public payload: ConversationDetailsModel) {}
}
export class DeleteConversation implements Action {
  readonly type = DELETE_CONVERSATION;
  constructor(public payload: number) {}
}

export class ClearConversations implements Action {
  readonly type = CLEAR_CONVERSATIONS;
}

export type All =
  | SetConversations
  | AddConversation
  | DeleteConversation
  | ClearConversations;
