import { Component, Input, OnInit } from '@angular/core';
import { MessagesDetailsModel } from 'src/app/core/api/models';
import { MatCardModule } from '@angular/material/card';
@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css'],
})
export class MessageComponent implements OnInit {
  @Input() message: MessagesDetailsModel = {};

  meAuthor = false;
  constructor() {}

  ngOnInit(): void {
    this.message.userId == 1 && (this.meAuthor = true);
  }
}
