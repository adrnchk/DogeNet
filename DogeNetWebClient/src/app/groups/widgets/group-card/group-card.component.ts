import { Component, Input, OnInit } from '@angular/core';
import { GroupDetailsModel } from 'src/app/core/api/models';

@Component({
  selector: 'app-group-card',
  templateUrl: './group-card.component.html',
  styleUrls: ['./group-card.component.css'],
})
export class GroupCardComponent {
  @Input() groupInfo: GroupDetailsModel = {};
}
