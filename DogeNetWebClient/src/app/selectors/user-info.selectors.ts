import { createFeatureSelector, createSelector } from '@ngrx/store';
import { userNode, UserState } from '../reducers/user-info.reducer';

export const selectUserFeature = createFeatureSelector<UserState>(userNode);

export const selectUser = createSelector(
  selectUserFeature,
  (state: UserState) => state.info
);
