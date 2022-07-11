import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable, timeout } from 'rxjs';
import {
  AccountDetailsModel,
  FriendsDetailsModel,
} from 'src/app/core/api/models';
import { FriendService, UserService } from 'src/app/core/api/services';
import { FriendsState } from 'src/app/store/states/FriendsState';
import { selectFriends } from 'src/app/store/selectors/friends.selectors';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import * as FriendsActions from 'src/app/store/actions/friends.actions';
import { UserState } from 'src/app/store/states/UserState';

@Component({
  selector: 'app-friends-grid',
  templateUrl: './friends-grid.component.html',
  styleUrls: ['./friends-grid.component.css'],
})
export class FriendsGridComponent implements OnInit {
  public items$: Observable<FriendsDetailsModel[]> = this.friendsStore.pipe(
    select(selectFriends)
  );
  public user$: Observable<AccountDetailsModel> = this.userStore.pipe(
    select(selectUser)
  );

  constructor(
    private friendsService: FriendService,
    private friendsStore: Store<FriendsState>,
    private userStore: Store<UserState>
  ) {}
  ngOnInit(): void {
    this.friendsStore.dispatch(FriendsActions.SetFriends());
  }
}
