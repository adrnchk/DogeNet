import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { select, Store } from '@ngrx/store';
import { catchError, EmptyError, exhaustMap, map, Observable } from 'rxjs';
import { GroupDetailsModel } from 'src/app/core/api/models';
import { GroupService } from 'src/app/core/api/services';
import * as GroupsActions from 'src/app/store/actions/groups.action';
import { selectUser } from '../selectors/user-info.selectors';
import { UserState } from '../states/UserState';

@Injectable()
export class GroupsEffects {
  private user$: Observable<GroupDetailsModel>;

  loadGroups$ = createEffect(() =>
    this.action$.pipe(
      ofType(GroupsActions.SetGroups),
      exhaustMap(() =>
        this.getGroupsData().pipe(
          map((list) => GroupsActions.SetGroupsSuccess({ groups: list }))
        )
      )
    )
  );

  getGroupsData = (): Observable<GroupDetailsModel[]> => {
    this.groupsService.rootUrl = 'https://localhost:7001';
    let userId = 0;
    this.user$.subscribe((state) => {
      userId = state.id ?? 0;
    });

    return this.groupsService.apiGroupGetUserGroupsIdGet$Json({
      id: userId,
    });
  };

  constructor(
    private action$: Actions,
    private userStore: Store<UserState>,
    private groupsService: GroupService
  ) {
    this.user$ = this.userStore.select(selectUser);
  }
}
