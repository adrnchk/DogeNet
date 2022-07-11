import * as Actions from 'src/app/store/actions/groups.action';
import { initialState } from '../states/GroupsState';
import { createReducer, on } from '@ngrx/store';

export const groupsNode = 'groups';

export const groupsReducer = createReducer(
  initialState,
  on(Actions.SetGroupsSuccess, (state, { groups }) => ({
    ...state,
    items: groups,
  })),
  on(Actions.AddGroup, (state, { group }) => {
    state.items.unshift(group);
    return state;
  }),
  on(Actions.DeleteGroup, (state, { id }) => ({
    ...state,
    items: state.items.filter((val, indx, arr) => val.id !== id),
  })),
  on(Actions.ClearGroups, (state) => ({
    ...state,
    items: [],
  }))
);
