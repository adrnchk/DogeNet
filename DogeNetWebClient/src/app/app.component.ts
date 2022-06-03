import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { UserService } from './core/api/services';
import { SignalrService } from './core/services/signalr.service';
import { UserState } from './reducers/user-info/user-info.reducer';
import * as UserActions from 'src/app/actions/user-info/user-info.actions';
import { Observable } from 'rxjs';
import { selectUser } from './selectors/user-info/user-info.selectors';
import { AccountDetailsModel } from './core/api/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  public user$: Observable<AccountDetailsModel> = this.store.pipe(
    select(selectUser)
  );
  constructor(
    public oidcSecurityService: OidcSecurityService,
    public signalrService: SignalrService,
    private userService: UserService,
    private store: Store<UserState>
  ) {}

  ngOnInit() {
    this.oidcSecurityService
      .checkAuth()
      .subscribe(({ isAuthenticated, userData }) => {});
  }

  login() {
    this.userService.rootUrl = 'https://localhost:7001';
    this.oidcSecurityService.authorize();
    this.oidcSecurityService.getUserData().subscribe((data) => {
      this.userService
        .apiUserGetUserByIdentityIdGet$Json({ id: data.sub })
        .subscribe((res) => {
          this.store.dispatch(new UserActions.SetUserInfo(res));
        });
    });
    this.user$.subscribe((data) => {
      this.oidcSecurityService.getAccessToken().subscribe((token) => {
        this.signalrService.joinRoom(
          token,
          data.userName ?? 'no_username',
          'g1'
        );
      });
    });
  }

  logout() {
    this.oidcSecurityService.logoff();
  }

  title = 'DogeNetWebClient';
}
