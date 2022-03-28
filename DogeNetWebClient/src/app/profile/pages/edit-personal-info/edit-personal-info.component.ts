import { Component, OnInit } from '@angular/core';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserService } from 'src/app/core/api/services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-personal-info',
  templateUrl: './edit-personal-info.component.html',
  styleUrls: ['./edit-personal-info.component.css'],
})
export class EditPersonalInfoComponent implements OnInit {
  user: AccountDetailsModel = {};
  newInfo: AccountDetailsModel = {};
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    this.userService.rootUrl = 'https://localhost:7001';
    //don't forget to change 1 to User Id and define city
    this.userService
      .apiUserGetUserByIdIdGet$Json({ id: 1 })
      .subscribe((res) => {
        this.user = res;
        this.newInfo.id = this.user.id;
        this.newInfo.avatarImg = this.user.avatarImg;
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
