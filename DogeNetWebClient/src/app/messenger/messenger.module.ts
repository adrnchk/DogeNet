import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatContainerComponent } from './pages/chat-container/chat-container.component';
import { ChatItemComponent } from './widgets/chat-item/chat-item.component';
import { ChatBoxComponent } from './pages/chat-box/chat-box.component';
import { MessageComponent } from './widgets/message/message.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DatePipe } from '@angular/common';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { MessengerRoutingModule } from './messenger-routing.module';

@NgModule({
  declarations: [
    ChatContainerComponent,
    ChatItemComponent,
    ChatBoxComponent,
    MessageComponent,
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    MatMenuModule,
    MatCardModule,
    FormsModule,
    MessengerRoutingModule,
  ],
  providers: [DatePipe],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class MessengerModule {}
