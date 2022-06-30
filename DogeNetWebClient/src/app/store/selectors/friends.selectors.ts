import { createFeatureSelector, createSelector } from '@ngrx/store';
import { friendsNode } from '../reducers/friends.reducer';
import { FriendsState } from '../states/FriendsState';

export const selectFriendsFeature =
  createFeatureSelector<FriendsState>(friendsNode);

export const selectFriends = createSelector(
  selectFriendsFeature,
  (state: FriendsState) => state.items
);
