import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import * as UserActions from 'src/app/store/actions/user-info.actions';
import { Observable } from 'rxjs';
import { UserState } from 'src/app/store/states/UserState';
import { select, Store } from '@ngrx/store';
import { UserService } from '../api/services';
import { AccountDetailsModel } from '../api/models';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public user$: Observable<AccountDetailsModel> = this.store.pipe(
    select(selectUser)
  );
  constructor(
    public oidcSecurityService: OidcSecurityService,
    private userService: UserService,
    private store: Store<UserState>
  ) {
    this.setToken();
  }
  ngOnInit() {
    this.userService.rootUrl = 'https://localhost:7001';
    this.oidcSecurityService
      .checkAuth()
      .subscribe(({ isAuthenticated, userData }) => {});
    this.oidcSecurityService.getUserData().subscribe((data) => {
      this.userService
        .apiUserGetUserByIdentityIdGet$Json({ id: data.sub })
        .subscribe((res) => {
          this.store.dispatch(UserActions.SetUserInfo({ payload: res }));
        });
    });
  }
  setToken() {
    this.oidcSecurityService.getAccessToken().subscribe((token) => {
      localStorage.removeItem('AccessToken');
      localStorage.setItem('AccessToken', token);
    });
  }

  login() {
    this.oidcSecurityService.authorize();
    this.setToken();
  }

  logout() {
    this.store.dispatch(UserActions.ClearUserInfo());
    localStorage.removeItem('AccessToken');
    this.oidcSecurityService.logoff();
  }

  loggedIn() {
    return localStorage.getItem('AccessToken') !== null ? true : false;
  }
}
