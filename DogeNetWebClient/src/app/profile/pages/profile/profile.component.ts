import { Component, OnInit } from '@angular/core';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { UserService } from 'src/app/core/api/services';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  user: AccountDetailsModel = {};
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.rootUrl = 'https://localhost:7001';
    //don't forget to change 1 to User Id and define city
    this.userService
      .apiUserGetUserByIdIdGet$Json({ id: 1 })
      .subscribe((res) => {
        this.user = res;
      });
  }
}
