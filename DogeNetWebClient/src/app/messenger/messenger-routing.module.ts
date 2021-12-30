import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ChatBoxComponent } from './pages/chat-box/chat-box.component';

const routes: Routes = [
  { path: 'conversation/:id', component: ChatBoxComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class MessengerRoutingModule {}
