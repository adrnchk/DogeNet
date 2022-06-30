import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ChatBoxComponent } from './pages/chat-box/chat-box.component';
import { AuthGuard } from '../core/guards/auth.guard';

const routes: Routes = [
  {
    path: 'messages/:id',
    component: ChatBoxComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class MessengerRoutingModule {}
