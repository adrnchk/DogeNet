import { createFeatureSelector, createSelector } from '@ngrx/store';
import { groupsNode } from '../reducers/groups.reducer';
import { GroupsState } from '../states/GroupsState';

export const selectGroupsFeature =
  createFeatureSelector<GroupsState>(groupsNode);

export const selectGroups = createSelector(
  selectGroupsFeature,
  (state: GroupsState) => state.items
);
