import { createFeatureSelector, createSelector } from '@ngrx/store';
import { userNode } from '../reducers/user-info.reducer';
import { UserState } from '../states/UserState';

export const selectUserFeature = createFeatureSelector<UserState>(userNode);

export const selectUser = createSelector(
  selectUserFeature,
  (state: UserState) => state.info
);
