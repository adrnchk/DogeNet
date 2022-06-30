import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../core/guards/auth.guard';
import { GroupsContainerComponent } from './pages/groups-container/groups-container.component';

const routes: Routes = [
  {
    path: 'groups',
    component: GroupsContainerComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class MessengerRoutingModule {}
