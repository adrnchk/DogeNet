import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import {
  EditMessageModel,
  MessagesDetailsModel,
} from 'src/app/core/api/models';
import { MatCardModule } from '@angular/material/card';
import { MessagesService } from 'src/app/core/api/services';
import { SignalrService } from 'src/app/core/services/signalr.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css'],
})
export class MessageComponent implements OnInit {
  @Input() message: MessagesDetailsModel = {};

  meAuthor = false;
  visible = true;
  editing = false;
  messageText: string;
  constructor(
    public signalrService: SignalrService,
    private messageService: MessagesService
  ) {
    this.messageText = '';
  }
  ngOnInit(): void {
    this.message.userId == 1 && (this.meAuthor = true);
    this.messageText = this.message.text ?? '';
    this.signalrService.hubConnection?.on(
      'EditMessageAsync',
      (messageId, message) => {
        if (this.message.id === messageId) {
          this.message.text = message;
          this.messageText = message;
        }
      }
    );

    this.signalrService.hubConnection?.on('DeleteMessageAsync', (messageId) => {
      if (this.message.id === messageId) {
        this.delete();
      }
    });
  }
  edit(): void {
    this.messageService
      .apiMessagesEditMessageIdPut$Json({
        id: this.message.id ? this.message.id.toString() : '0',
        body: { messageId: this.message.id ?? 0, text: this.messageText },
      })
      .subscribe((res) => {
        console.log(res);
        this.editing = false;
      });
  }
  delete(): void {
    this.messageService
      .apiMessagesDeleteMessageIdDelete({ id: this.message.id ?? 0 })
      .subscribe((res) => {
        console.log(res);
        this.visible = false;
      });
  }
}
