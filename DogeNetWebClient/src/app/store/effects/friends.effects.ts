import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { select, Store } from '@ngrx/store';
import { catchError, EmptyError, exhaustMap, map, Observable } from 'rxjs';
import {
  AccountDetailsModel,
  FriendsDetailsModel,
} from 'src/app/core/api/models';
import { FriendService } from 'src/app/core/api/services';
import { JsonAppConfigService } from 'src/app/core/services/json-app-config.service';
import * as FriendsActions from 'src/app/store/actions/friends.actions';
import { selectUser } from '../selectors/user-info.selectors';
import { UserState } from '../states/UserState';

@Injectable()
export class FriendsEffects {
  private user$: Observable<AccountDetailsModel>;

  loadFriends$ = createEffect(() =>
    this.action$.pipe(
      ofType(FriendsActions.SetFriends),
      exhaustMap(() =>
        this.getFriendsData().pipe(
          map((list) => FriendsActions.SetFriendsSuccess({ friends: list }))
        )
      )
    )
  );

  getFriendsData = (): Observable<FriendsDetailsModel[]> => {
    this.friendsService.rootUrl = this.appConfigService.apiRootUrl;
    let userId = 0;
    this.user$.subscribe((state) => {
      userId = state.id ?? 0;
    });

    return this.friendsService.apiFriendGetFriendsIdGet$Json({
      id: userId,
    });
  };

  constructor(
    private appConfigService: JsonAppConfigService,
    private action$: Actions,
    private userStore: Store<UserState>,
    private friendsService: FriendService
  ) {
    this.user$ = this.userStore.select(selectUser);
  }
}
