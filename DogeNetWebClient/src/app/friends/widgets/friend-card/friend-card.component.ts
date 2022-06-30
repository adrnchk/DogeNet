import { Component, Input, OnInit } from '@angular/core';
import { FriendsDetailsModel } from 'src/app/core/api/models';

@Component({
  selector: 'app-friend-card',
  templateUrl: './friend-card.component.html',
  styleUrls: ['./friend-card.component.css'],
})
export class FriendCardComponent {
  @Input() friendInfo: FriendsDetailsModel = {};
  
}
