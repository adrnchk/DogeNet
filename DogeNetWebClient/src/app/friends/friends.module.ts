import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DatePipe } from '@angular/common';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { MessengerRoutingModule } from './friends-routing.module';
import { FriendCardComponent } from './widgets/friend-card/friend-card.component';
import { FriendsGridComponent } from './pages/friends-grid/friends-grid.component';
import { FriendsContainerComponent } from './pages/friends-container/friends-container.component';
import { MatGridListModule } from '@angular/material/grid-list';

@NgModule({
  declarations: [
    FriendCardComponent,
    FriendsGridComponent,
    FriendsContainerComponent,
  ],
  imports: [
    MatGridListModule,
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
export class FriendsModule {}
