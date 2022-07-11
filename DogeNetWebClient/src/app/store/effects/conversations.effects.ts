import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { select, Store } from '@ngrx/store';
import { catchError, EmptyError, exhaustMap, map, Observable } from 'rxjs';
import {
  AccountDetailsModel,
  ConversationDetailsModel,
} from 'src/app/core/api/models';
import { ConversationService } from 'src/app/core/api/services';
import { JsonAppConfigService } from 'src/app/core/services/json-app-config.service';
import * as ConversationsActions from 'src/app/store/actions/conversation.actions';
import { selectUser } from '../selectors/user-info.selectors';
import { UserState } from '../states/UserState';

@Injectable()
export class ConversationsEffects {
  private user$: Observable<AccountDetailsModel>;

  loadConversations$ = createEffect(() =>
    this.action$.pipe(
      ofType(ConversationsActions.SetConversations),
      exhaustMap(() =>
        this.getConversationsData().pipe(
          map((list) =>
            ConversationsActions.SetConversationsSuccess({ payload: list })
          )
        )
      )
    )
  );

  getConversationsData = (): Observable<ConversationDetailsModel[]> => {
    this.conversationsService.rootUrl = this.appConfigService.apiRootUrl;
    let userId = 0;
    this.user$.subscribe((state) => {
      userId = state.id ?? 0;
    });

    return this.conversationsService.apiConversationGetConversationsIdGet$Json({
      id: userId,
    });
  };

  constructor(
    private appConfigService: JsonAppConfigService,
    private action$: Actions,
    private userStore: Store<UserState>,
    private conversationsService: ConversationService
  ) {
    this.user$ = this.userStore.select(selectUser);
  }
}
