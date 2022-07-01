import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import {
  AccountDetailsModel,
  EditMessageModel,
  MessagesDetailsModel,
} from 'src/app/core/api/models';
import { MatCardModule } from '@angular/material/card';
import { MessagesService } from 'src/app/core/api/services';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { Observable } from 'rxjs';
import { select, Store } from '@ngrx/store';
import { UserState } from 'src/app/store/states/UserState';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css'],
})
export class MessageComponent implements OnInit {
  @Input() message: MessagesDetailsModel = {};

  public user$: Observable<AccountDetailsModel> = this.userStore.pipe(
    select(selectUser)
  );

  meAuthor = false;
  visible = true;
  editing = false;
  messageText: string;
  constructor(
    public signalrService: SignalrService,
    private userStore: Store<UserState>,
    private messageService: MessagesService
  ) {
    this.messageText = '';
  }
  ngOnInit(): void {
    this.user$.subscribe((state) => {
      state && this.message.userId == state.id && (this.meAuthor = true);
    });

    this.messageText = this.message.text ?? '';
  }
  edit(): void {
    this.messageService
      .apiMessagesEditMessageIdPut$Json({
        id: this.message.id ? this.message.id.toString() : '0',
        body: { messageId: this.message.id ?? 0, text: this.messageText },
      })
      .subscribe((res) => {
        console.log(this.message);
        this.signalrService.editMessage({
          ...this.message,
          text: this.messageText,
        });
        this.editing = false;
      });
  }
  delete(): void {
    this.messageService
      .apiMessagesDeleteMessageIdDelete({ id: this.message.id ?? 0 })
      .subscribe((res) => {
        this.signalrService.deleteMessage(this.message);
      });
  }
}
