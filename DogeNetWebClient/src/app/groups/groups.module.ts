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
import { MessengerRoutingModule } from './groups-routing.module';
import { MatGridListModule } from '@angular/material/grid-list';
import { GroupsContainerComponent } from './pages/groups-container/groups-container.component';
import { GroupsListComponent } from './pages/groups-list/groups-list.component';
import { GroupCardComponent } from './widgets/group-card/group-card.component';

@NgModule({
  declarations: [
  
    GroupsContainerComponent,
       GroupsListComponent,
       GroupCardComponent
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
export class GroupsModule {}
