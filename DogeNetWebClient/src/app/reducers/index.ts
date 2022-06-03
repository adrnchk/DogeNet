import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import * as UserActions from 'src/app/actions/user-info/user-info.actions';
import { environment } from 'src/environments/environment';
import {
  userNode,
  userReducer,
  UserState,
} from './user-info/user-info.reducer';

export interface State {
  [userNode]: UserState;
}

export const reducers: ActionReducerMap<State, UserActions.All> = {
  [userNode]: userReducer,
};

export const metaReducers: MetaReducer<State, UserActions.All>[] =
  !environment.production ? [] : [];
