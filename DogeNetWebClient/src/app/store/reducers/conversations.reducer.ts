import * as Actions from 'src/app/store/actions/conversation.actions';
import { initialState } from '../states/ConversationsState';
import { createReducer, on } from '@ngrx/store';

export const conversationsNode = 'conversations';

export const conversationsReducer = createReducer(
  initialState,
  on(Actions.SetConversationsSuccess, (state, { payload }) => ({
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
