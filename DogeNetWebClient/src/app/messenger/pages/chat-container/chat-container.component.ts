import { Component, OnInit } from '@angular/core';
import { ConversationService } from 'src/app/core/api/services';
import { ConversationDetailsModel } from 'src/app/core/api/models/conversation-details-model';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.css'],
  providers: [ConversationService],
})
export class ChatContainerComponent implements OnInit {
  constructor(private conversationService: ConversationService) {}
  items: ConversationDetailsModel[] = [];

  //Not forget to replace '1' with userID
  ngOnInit(): void {
    this.conversationService.rootUrl = 'https://localhost:7001';
    this.conversationService
      .apiConversationGetConversationsIdGet$Json({ id: 1 })
      .subscribe((list) => (this.items = list));
  }
}
