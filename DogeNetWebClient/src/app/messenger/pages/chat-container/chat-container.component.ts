import { Component, OnInit } from '@angular/core';
import { ConversationService } from 'src/app/core/api/services';
import { ConversationDetailsModel } from 'src/app/core/api/models/conversation-details-model';
import { HttpHeaders } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ConversationsState } from 'src/app/reducers/conversations.reducer';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import { selectConversations } from 'src/app/selectors/conversations.selectors';
import * as ConversationActions from 'src/app/actions/conversation.actions';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { selectUser } from 'src/app/selectors/user-info.selectors';
import { UserState } from 'src/app/reducers/user-info.reducer';
import { AccountDetailsModel } from 'src/app/core/api/models';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.css'],
  providers: [ConversationService],
})
export class ChatContainerComponent implements OnInit {
  public items$: Observable<ConversationDetailsModel[]> =
    this.conversationStore.pipe(select(selectConversations));
  constructor(
    private conversationService: ConversationService,
    public oidcSecurityService: OidcSecurityService,
    public signalrService: SignalrService,
    private conversationStore: Store<ConversationsState>
  ) {}

  ngOnInit(): void {
    this.conversationService.rootUrl = 'https://localhost:7001';

    this.conversationService
      .apiConversationGetConversationsIdGet$Json({ id: 1 })
      .subscribe((list) => {
        this.conversationStore.dispatch(
          new ConversationActions.SetConversations(list)
        );
      });
  }
}
