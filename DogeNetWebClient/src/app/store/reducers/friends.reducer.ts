import * as Actions from 'src/app/store/actions/friends.actions';
import { initialState } from '../states/FriendsState';
import { createReducer, on } from '@ngrx/store';

export const friendsNode = 'friends';

export const friendsReducer = createReducer(
  initialState,
  on(Actions.SetFriendsSuccess, (state, { friends }) => ({
    ...state,
    items: friends,
  })),
  on(Actions.AddFriend, (state, { friend }) => {
    state.items.unshift(friend);
    return state;
  }),
  on(Actions.DeleteFriend, (state, { id }) => ({
    ...state,
    items: state.items.filter((val, indx, arr) => val.id !== id),
  })),
  on(Actions.ClearFriends, (state) => ({
    ...state,
    items: [],
  }))
);
