import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import { UserState } from 'src/app/store/states/UserState';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent {
  public user$: Observable<AccountDetailsModel> = this.store.pipe(
    select(selectUser)
  );
  constructor(private store: Store<UserState>) {}
}
