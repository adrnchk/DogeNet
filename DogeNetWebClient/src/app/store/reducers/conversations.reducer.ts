import * as Actions from 'src/app/store/actions/conversation.actions';
import { ConversationDetailsModel } from 'src/app/core/api/models';
import { ConversationsState } from '../states/ConversationsState';
import { createReducer, on } from '@ngrx/store';

const initialState: ConversationsState = {
  items: new Array<ConversationDetailsModel>(),
};

export const conversationsNode = 'conversations';

export const conversationsReducer = createReducer(
  initialState,
  on(Actions.SetConversations, (state, { payload }) => ({
    ...state,
    items: payload,
  })),
  on(Actions.AddConversation, (state, { payload }) => {
    state.items.unshift(payload);
    return state;
  }),
  on(Actions.DeleteConversation, (state, { payload }) => ({
    ...state,
    items: state.items.filter((val, indx, arr) => val.id !== payload),
  })),
  on(Actions.ClearConversations, (state) => ({
    ...state,
    items: [],
  }))
);
