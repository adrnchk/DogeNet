import { Injectable } from '@angular/core';
import * as UserActions from 'src/app/store/actions/user-info.actions';
import { UserState } from 'src/app/store/states/UserState';
import { select, Store } from '@ngrx/store';
import { UserService } from '../api/services';
import { OAuthService } from 'angular-oauth2-oidc';
import { authCodeFlowConfig } from 'src/app/shared/configs/OAuthConfig';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    public oauthService: OAuthService,
    private userService: UserService,
    private store: Store<UserState>
  ) {
    this.oauthService.configure(authCodeFlowConfig);
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
    this.oauthService.setupAutomaticSilentRefresh();
    setTimeout(() => {
      this.store.dispatch(UserActions.SetUserInfo());
    }, 500);
  }

  login() {
    this.oauthService.initCodeFlow();
  }

  logout() {
    this.store.dispatch(UserActions.ClearUserInfo());
    this.oauthService.revokeTokenAndLogout();
  }

  get loggedIn() {
    return this.oauthService.hasValidAccessToken();
  }
}
