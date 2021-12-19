import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { DatePipe } from '@angular/common';
import {
  ConversationDetailsModel,
  MessagesDetailsModel,
} from 'src/app/core/api/models';
import {
  ConversationService,
  MessagesService,
} from 'src/app/core/api/services';

@Component({
  selector: 'app-chat-box',
  templateUrl: './chat-box.component.html',
  styleUrls: ['./chat-box.component.css'],
})
export class ChatBoxComponent implements OnInit {
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();

  private routeSubscription: Subscription;
  id: any;
  messageText: string = '';
  message: MessagesDetailsModel = {};
  constructor(
    private datepipe: DatePipe,
    private messagesService: MessagesService,
    private conversationsService: ConversationService,
    private route: ActivatedRoute
  ) {
    this.routeSubscription = route.params.subscribe((params) => {
      this.id = params['id'];
      this.message.conversationId = this.id;
      this.message.userId = 1; //don't forget to replace 1 - userId
      this.message.text = '';
    });
  }

  items: MessagesDetailsModel[] = [];
  conversationInfo: ConversationDetailsModel = {};

  ngOnInit(): void {
    this.messagesService.rootUrl = 'https://localhost:7001';
    this.conversationsService.rootUrl = 'https://localhost:7001';
    this.messagesService
      .apiMessagesGetMessagesIdGet$Json({ id: this.id })
      .subscribe((list) => (this.items = list));
    this.conversationsService
      .apiConversationGetConversationByIdIdGet$Json({ id: this.id })
      .subscribe((res) => (this.conversationInfo = res));
  }
  sendMessage(): void {
    this.message.text = this.messageText;
    this.messagesService
      .apiMessagesSendMessagePost({ body: this.message })
      .subscribe((res) => {
        console.log(res);
        this.messageText = '';
      });
  }
}
