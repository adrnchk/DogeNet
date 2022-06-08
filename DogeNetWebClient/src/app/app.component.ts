import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { UserService } from './core/api/services';
import { SignalrService } from './core/services/signalr.service';
import * as UserActions from 'src/app/store/actions/user-info.actions';
import { Observable } from 'rxjs';
import { selectUser } from './store/selectors/user-info.selectors';
import { AccountDetailsModel } from './core/api/models';
import { UserState } from './store/states/UserState';
import { AuthService } from './core/services/auth.service';

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
    private store: Store<UserState>,
    public authService: AuthService
  ) {}

  ngOnInit() {
    this.oidcSecurityService
      .checkAuth()
      .subscribe(({ isAuthenticated, userData }) => {
        console.log(isAuthenticated);
      });
  }

  login() {
    this.authService.login();
  }

  title = 'DogeNetWebClient';
}
