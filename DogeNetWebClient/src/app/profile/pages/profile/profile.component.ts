import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserService } from 'src/app/core/api/services';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import * as UserActions from 'src/app/store/actions/user-info.actions';
import { UserState } from 'src/app/store/states/UserState';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  public user$: Observable<AccountDetailsModel> = this.store.pipe(
    select(selectUser)
  );
  constructor(
    private userService: UserService,
    private store: Store<UserState>
  ) {}

  ngOnInit(): void {
    this.userService.rootUrl = 'https://localhost:7001';
    //don't forget to change 1 to User Id and define city
    this.userService
      .apiUserGetUserByIdIdGet$Json({ id: 1 })
      .subscribe((res) => {
        this.store.dispatch(UserActions.SetUserInfo({ payload: res }));
      });
  }
}
