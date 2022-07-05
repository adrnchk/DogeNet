import { Injectable, OnInit } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { OAuthService } from 'angular-oauth2-oidc';
import { catchError, EmptyError, exhaustMap, map, Observable } from 'rxjs';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserService } from 'src/app/core/api/services';
import * as UserActions from 'src/app/store/actions/user-info.actions';

@Injectable()
export class UserEffects {
  loadUser$ = createEffect(() =>
    this.action$.pipe(
      ofType(UserActions.SetUserInfo),
      exhaustMap(() =>
        this.getUserData().pipe(
          map((user) => UserActions.SetUserInfoSuccess({ payload: user }))
        )
      )
    )
  );

  getUserData = (): Observable<AccountDetailsModel> => {
    this.userService.rootUrl = 'https://localhost:7001';
    let res: any = this.oauthService.getIdentityClaims();

    return this.userService.apiUserGetUserByIdentityIdGet$Json({
      id: res?.sub,
    });
  };

  constructor(
    private action$: Actions,
    public oauthService: OAuthService,
    private userService: UserService
  ) {}
}
