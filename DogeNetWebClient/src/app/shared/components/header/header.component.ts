import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import { UserState } from 'src/app/store/states/UserState';
import * as UserActions from 'src/app/store/actions/user-info.actions';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  public user$: Observable<AccountDetailsModel> = this.store.pipe(
    select(selectUser)
  );
  constructor(
    private store: Store<UserState>,
    public oidcSecurityService: OidcSecurityService,
    public signalrService: SignalrService
  ) {}

  ngOnInit(): void {}

  logout() {
    this.oidcSecurityService.logoff();
    this.store.dispatch(UserActions.ClearUserInfo());
  }
}
