import { Component, OnInit } from '@angular/core';
import { ConversationService } from 'src/app/core/api/services';
import { ConversationDetailsModel } from 'src/app/core/api/models/conversation-details-model';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import { selectConversations } from 'src/app/store/selectors/conversations.selectors';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import * as ConversationActions from 'src/app/store/actions/conversation.actions';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { ConversationsState } from 'src/app/store/states/ConversationsState';
import { OAuthService } from 'angular-oauth2-oidc';
import { UserState } from 'src/app/store/states/UserState';
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

  public user$: Observable<AccountDetailsModel> = this.userStore.pipe(
    select(selectUser)
  );

  constructor(
    private conversationService: ConversationService,
    public oidcSecurityService: OAuthService,
    public signalrService: SignalrService,
    private conversationStore: Store<ConversationsState>,
    private userStore: Store<UserState>
  ) {}

  ngOnInit(): void {
    this.conversationStore.dispatch(ConversationActions.SetConversations());
  }
}
