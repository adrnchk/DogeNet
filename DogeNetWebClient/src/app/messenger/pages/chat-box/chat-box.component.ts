import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { DatePipe } from '@angular/common';
import {
  AccountDetailsModel,
  ConversationDetailsModel,
  MessagesDetailsModel,
} from 'src/app/core/api/models';
import {
  ConversationService,
  MessagesService,
} from 'src/app/core/api/services';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import { select, Store } from '@ngrx/store';
import { UserState } from 'src/app/store/states/UserState';
import { MessagesState } from 'src/app/store/states/MessagesState';
import * as MessagesActions from 'src/app/store/actions/messages.action';
import { selectMessages } from 'src/app/store/selectors/messages.selector';

@Component({
  selector: 'app-chat-box',
  templateUrl: './chat-box.component.html',
  styleUrls: ['./chat-box.component.css'],
})
export class ChatBoxComponent implements OnInit {
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();

  public user$: Observable<AccountDetailsModel> = this.userStore.pipe(
    select(selectUser)
  );
  public items$: Observable<MessagesDetailsModel[]>;

  private routeSubscription: Subscription;
  id: any;
  messageText: string = '';
  message: MessagesDetailsModel = {};

  constructor(
    private userStore: Store<UserState>,
    private messagesStore: Store<MessagesState>,
    public signalrService: SignalrService,
    private messagesService: MessagesService,
    private conversationsService: ConversationService,
    private route: ActivatedRoute
  ) {
    this.routeSubscription = route.params.subscribe((params) => {
      this.id = params['id'];
      this.message.conversationId = this.id;
      this.user$.subscribe((state) => {
        state && (this.message.userId = state.id);
      });
      this.message.text = '';
    });
    this.messagesStore.dispatch(MessagesActions.ClearMessages());

    this.items$ = this.messagesStore.pipe(select(selectMessages));
  }

  items: MessagesDetailsModel[] = [];
  conversationInfo: ConversationDetailsModel = {};

  ngOnInit(): void {
    this.messagesService.rootUrl = 'https://localhost:7001';
    this.conversationsService.rootUrl = 'https://localhost:7001';
    this.messagesService
      .apiMessagesGetMessagesIdGet$Json({ id: this.id })
      .subscribe((list) =>
        this.messagesStore.dispatch(
          MessagesActions.SetMessages({ messages: list })
        )
      );
    this.conversationsService
      .apiConversationGetConversationByIdIdGet$Json({ id: this.id })
      .subscribe((res) => (this.conversationInfo = res));
  }
  sendMessage(): void {
    this.message.text = this.messageText;
    this.messagesService
      .apiMessagesSendMessagePost$Json({ body: this.message })
      .subscribe((res) => {
        this.message.id = res;
        this.signalrService.sendMessage(this.message);
        this.messageText = '';

        this.messagesService
          .apiMessagesGetMessagesIdGet$Json({ id: this.id })
          .subscribe((list) =>
            this.messagesStore.dispatch(
              MessagesActions.SetMessages({ messages: list })
            )
          );
      });
  }
}
