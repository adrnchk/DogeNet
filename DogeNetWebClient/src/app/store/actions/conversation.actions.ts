import { createAction, props } from '@ngrx/store';
import { ConversationDetailsModel } from 'src/app/core/api/models';

export const SET_CONVERSATIONS = '[Conversations] Set';
export const ADD_CONVERSATION = '[Conversations] Add';
export const DELETE_CONVERSATION = '[Conversations] Delete';
export const CLEAR_CONVERSATIONS = '[Conversations] Clear';

export const SetConversations = createAction(
  SET_CONVERSATIONS,
  props<{ payload: ConversationDetailsModel[] }>()
);
export const AddConversation = createAction(
  ADD_CONVERSATION,
  props<{ payload: ConversationDetailsModel }>()
);
export const DeleteConversation = createAction(
  DELETE_CONVERSATION,
  props<{ payload: number }>()
);
export const ClearConversations = createAction(CLEAR_CONVERSATIONS);
