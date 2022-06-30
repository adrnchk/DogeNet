import { ActionReducer, ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from 'src/environments/environment';
import { ConversationsState } from '../states/ConversationsState';
import { FriendsState } from '../states/FriendsState';
import { GroupsState } from '../states/GroupsState';
import { MessagesState } from '../states/MessagesState';
import { UserState } from '../states/UserState';
import {
  conversationsNode,
  conversationsReducer,
} from './conversations.reducer';
import { friendsNode, friendsReducer } from './friends.reducer';
import { groupsNode, groupsReducer } from './groups.reducer';
import { messagesNode, messagesReducer } from './messages.reducer';
import { userNode, userReducer } from './user-info.reducer';

export interface State {
  [userNode]: UserState;
  [conversationsNode]: ConversationsState;
  [messagesNode]: MessagesState;
  [groupsNode]: GroupsState;
  [friendsNode]: FriendsState;
}

export const reducers: ActionReducerMap<State, any> = {
  [userNode]: userReducer,
  [conversationsNode]: conversationsReducer,
  [messagesNode]: messagesReducer,
  [groupsNode]: groupsReducer,
  [friendsNode]: friendsReducer,
};
