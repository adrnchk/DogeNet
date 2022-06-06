import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserState } from 'src/app/reducers/user-info.reducer';
import { selectUser } from 'src/app/selectors/user-info.selectors';
import * as UserActions from 'src/app/actions/user-info.actions';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  public user$: Observable<AccountDetailsModel> = this.store.pipe(
    select(selectUser)
  );
  constructor(private store: Store<UserState>) {}

  ngOnInit(): void {}
}
