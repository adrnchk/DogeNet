import { Input, Component, OnInit } from '@angular/core';
import { ConversationDetailsModel } from 'src/app/core/api/models';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-chat-item',
  templateUrl: './chat-item.component.html',
  styleUrls: ['./chat-item.component.css'],
})
export class ChatItemComponent implements OnInit {
  @Input() conversationInfo: ConversationDetailsModel = {};

  constructor() {}

  ngOnInit(): void {}
}
