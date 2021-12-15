import { Component, Input, OnInit } from '@angular/core';
import { MessagesDetailsModel } from 'src/app/core/api/models';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css'],
})
export class MessageComponent implements OnInit {
  @Input() message: MessagesDetailsModel = {};

  constructor() {}

  ngOnInit(): void {}
}
