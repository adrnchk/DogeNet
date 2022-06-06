import { Input, Component, OnInit } from '@angular/core';
import {
  AccountDetailsModel,
  ConversationDetailsModel,
} from 'src/app/core/api/models';
import { RouterLink } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { selectUser } from 'src/app/selectors/user-info.selectors';
import { Observable } from 'rxjs';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { SignalrService } from 'src/app/core/services/signalr.service';
import { UserState } from 'src/app/reducers/user-info.reducer';

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
    public oidcSecurityService: OidcSecurityService,
    public signalrService: SignalrService
  ) {}

  onClick(): void {
    this.user$.subscribe((data) => {
      this.oidcSecurityService.getAccessToken().subscribe((token) => {
        this.signalrService.joinRoom(
          token,
          data.userName ?? 'no_username',
          this.conversationInfo.title ?? 'no_roomname'
        );
      });
    });
  }

  ngOnInit(): void {}
}
