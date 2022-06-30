import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../core/guards/auth.guard';
import { FriendsContainerComponent } from './pages/friends-container/friends-container.component';

const routes: Routes = [
  {
    path: 'friends',
    component: FriendsContainerComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class MessengerRoutingModule {}
