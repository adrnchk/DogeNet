import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { select, Store } from '@ngrx/store';
import { catchError, EmptyError, exhaustMap, map, Observable } from 'rxjs';
import {
  AccountDetailsModel,
  FriendsDetailsModel,
  MessagesDetailsModel,
} from 'src/app/core/api/models';
import { MessagesService } from 'src/app/core/api/services';
import { JsonAppConfigService } from 'src/app/core/services/json-app-config.service';
import * as MessagesActions from 'src/app/store/actions/messages.action';
import { selectUser } from '../selectors/user-info.selectors';
import { UserState } from '../states/UserState';

@Injectable()
export class MessagesEffects {
  loadMessages$ = createEffect(() =>
    this.action$.pipe(
      ofType(MessagesActions.SetMessages),
      exhaustMap((action) =>
        this.getMessagesData(action.conversationId).pipe(
          map((list) => MessagesActions.SetMessagesSuccess({ messages: list }))
        )
      )
    )
  );

  getMessagesData = (
    conversationId: number
  ): Observable<MessagesDetailsModel[]> => {
    this.messagesService.rootUrl = this.appConfigService.apiRootUrl;
    return this.messagesService.apiMessagesGetMessagesIdGet$Json({
      id: conversationId ?? 1,
    });
  };

  constructor(
    private appConfigService: JsonAppConfigService,
    private action$: Actions,
    private messagesService: MessagesService
  ) {}
}
