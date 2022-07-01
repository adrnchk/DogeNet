import { Component, OnInit } from '@angular/core';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserService } from 'src/app/core/api/services';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserState } from 'src/app/store/states/UserState';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';

@Component({
  selector: 'app-edit-personal-info',
  templateUrl: './edit-personal-info.component.html',
  styleUrls: ['./edit-personal-info.component.css'],
})
export class EditPersonalInfoComponent implements OnInit {
  public user$: Observable<AccountDetailsModel> = this.userStore.pipe(
    select(selectUser)
  );

  user: AccountDetailsModel = {};
  newInfo: AccountDetailsModel = {};
  constructor(
    private userStore: Store<UserState>,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.userService.rootUrl = 'https://localhost:7001';

    this.user$.subscribe((state) => {
      state &&
        this.userService
          .apiUserGetUserByIdIdGet$Json({ id: state.id ?? 0 })
          .subscribe((res) => {
            this.user = res;
            this.newInfo.id = this.user.id;
            this.newInfo.avatarImg = this.user.avatarImg;
          });
    });
  }
  saveChanges(): void {
    this.userService
      .apiUserChangeUserInfoPut$Json({ body: this.newInfo })
      .subscribe((res) => {
        console.log(res);
        this.router.navigate(['/profile']);
      });
  }
}
