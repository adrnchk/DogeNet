import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserService } from 'src/app/core/api/services';
import { UserState } from 'src/app/reducers/user-info/user-info.reducer';
import { selectUser } from 'src/app/selectors/user-info/user-info.selectors';
import * as UserActions from 'src/app/actions/user-info/user-info.actions';

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
        this.store.dispatch(new UserActions.SetUserInfo(res));
      });
  }
}
