import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { FriendsDetailsModel } from 'src/app/core/api/models';
import { FriendService } from 'src/app/core/api/services';
import { FriendsState } from 'src/app/store/states/FriendsState';
import { selectFriends } from 'src/app/store/selectors/friends.selectors';
import * as FriendsActions from 'src/app/store/actions/friends.actions';

@Component({
  selector: 'app-friends-grid',
  templateUrl: './friends-grid.component.html',
  styleUrls: ['./friends-grid.component.css'],
})
export class FriendsGridComponent implements OnInit {
  public items$: Observable<FriendsDetailsModel[]> = this.friendsStore.pipe(
    select(selectFriends)
  );

  constructor(
    private friendsService: FriendService,
    private friendsStore: Store<FriendsState>
  ) {}
  ngOnInit(): void {
    this.friendsService.rootUrl = 'https://localhost:7001';

    this.friendsService
      .apiFriendGetFriendsIdGet$Json({ id: 1 })
      .subscribe((list) => {
        this.friendsStore.dispatch(
          FriendsActions.SetFriends({ friends: list })
        );
      });
  }
}
