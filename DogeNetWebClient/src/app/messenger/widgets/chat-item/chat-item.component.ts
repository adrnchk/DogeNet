import { Input, Component, OnInit } from '@angular/core';
import {
  AccountDetailsModel,
  ConversationDetailsModel,
} from 'src/app/core/api/models';
import { RouterLink } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import { Observable } from 'rxjs';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { UserState } from 'src/app/store/states/UserState';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-chat-item',
  templateUrl: './chat-item.component.html',
  styleUrls: ['./chat-item.component.css'],
})
export class ChatItemComponent implements OnInit {
  @Input() conversationInfo: ConversationDetailsModel = {};
  public user$: Observable<AccountDetailsModel> = this.userStore.pipe(
    select(selectUser)
  );
  constructor(
    private userStore: Store<UserState>,
    public oidcSecurityService: OAuthService,
    public signalrService: SignalrService
  ) {}

  onClick(): void {
    console.log('click');
    this.user$.subscribe((data) => {
      let token = this.oidcSecurityService.getAccessToken();
      console.log(data.userName + ' joined ' + this.conversationInfo.title);
      this.signalrService.joinRoom(
        token,
        data.userName ?? 'no_username',
        this.conversationInfo.title ?? 'no_roomname'
      );
    });
  }

  ngOnInit(): void {}
}
