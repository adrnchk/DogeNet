import { createAction, props } from '@ngrx/store';
import { ConversationDetailsModel } from 'src/app/core/api/models';

export const SetConversations = createAction('[Conversations] Set');
export const SetConversationsSuccess = createAction(
  '[Conversations] Set_Success',
  props<{ payload: ConversationDetailsModel[] }>()
);
export const AddConversation = createAction(
  '[Conversations] Add',
  props<{ payload: ConversationDetailsModel }>()
);
export const DeleteConversation = createAction(
  '[Conversations] Delete',
  props<{ payload: number }>()
);
export const ClearConversations = createAction('[Conversations] Clear');
