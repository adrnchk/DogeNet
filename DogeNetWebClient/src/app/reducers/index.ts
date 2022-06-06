import { ActionReducer, ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from 'src/environments/environment';
import {
  conversationsNode,
  conversationsReducer,
  ConversationsState,
} from './conversations.reducer';
import {
  messagesNode,
  messagesReducer,
  MessagesState,
} from './messages.reducer';
import { userNode, userReducer, UserState } from './user-info.reducer';

export interface State {
  [userNode]: UserState;
  [conversationsNode]: ConversationsState;
  [messagesNode]: MessagesState;
}

export const reducers: ActionReducerMap<State, any> = {
  [userNode]: userReducer,
  [conversationsNode]: conversationsReducer,
  [messagesNode]: messagesReducer,
};

export const metaReducers: MetaReducer<State, any>[] = !environment.production
  ? []
  : [];
