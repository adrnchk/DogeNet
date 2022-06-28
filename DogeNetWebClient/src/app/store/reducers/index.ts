import { ActionReducer, ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from 'src/environments/environment';
import { ConversationsState } from '../states/ConversationsState';
import { MessagesState } from '../states/MessagesState';
import { UserState } from '../states/UserState';
import {
  conversationsNode,
  conversationsReducer,
} from './conversations.reducer';
import { messagesNode, messagesReducer } from './messages.reducer';
import { userNode, userReducer } from './user-info.reducer';

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
