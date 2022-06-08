import { Routes, RouterModule } from '@angular/router';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ChatContainerComponent } from './messenger/pages/chat-container/chat-container.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ChatBoxComponent } from './messenger/pages/chat-box/chat-box.component';
import { AuthGuard } from './core/guards/auth.guard';
import { LoginComponent } from './shared/components/login/login.component';

const routes: Routes = [
  {
    path: 'messages',
    component: ChatContainerComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppRoutingModule {}
