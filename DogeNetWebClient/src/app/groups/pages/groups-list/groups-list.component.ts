import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  AccountDetailsModel,
  GroupDetailsModel,
} from 'src/app/core/api/models';
import { GroupsState } from 'src/app/store/states/GroupsState';
import { selectGroups } from 'src/app/store/selectors/groups.selectors';
import * as GroupActions from 'src/app/store/actions/groups.action';
import { FriendService, GroupService } from 'src/app/core/api/services';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import { UserState } from 'src/app/store/states/UserState';

@Component({
  selector: 'app-groups-list',
  templateUrl: './groups-list.component.html',
  styleUrls: ['./groups-list.component.css'],
})
export class GroupsListComponent {
  public items$: Observable<GroupDetailsModel[]> = this.groupStore.pipe(
    select(selectGroups)
  );
  public user$: Observable<AccountDetailsModel> = this.userStore.pipe(
    select(selectUser)
  );

  constructor(
    private groupStore: Store<GroupsState>,
    private groupsService: GroupService,
    private userStore: Store<UserState>
  ) {}
  ngOnInit(): void {
    this.groupsService.rootUrl = 'https://localhost:7001';

    this.user$.subscribe((state) => {
      state &&
        this.groupsService
          .apiGroupGetUserGroupsIdGet$Json({ id: state.id ?? 0 })
          .subscribe((list) => {
            this.groupStore.dispatch(GroupActions.SetGroups({ groups: list }));
          });
    });
  }
}
