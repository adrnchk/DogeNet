import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatContainerComponent } from './pages/chat-container/chat-container.component';
import { ChatItemComponent } from './widgets/chat-item/chat-item.component';
import { ChatBoxComponent } from './pages/chat-box/chat-box.component';
import { MessageComponent } from './widgets/message/message.component';

@NgModule({
  declarations: [
    ChatContainerComponent,
    ChatItemComponent,
    ChatBoxComponent,
    MessageComponent,
  ],
  imports: [CommonModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class MessengerModule {}
