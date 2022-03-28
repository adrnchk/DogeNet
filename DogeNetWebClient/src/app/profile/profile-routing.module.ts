import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ProfileComponent } from './pages/profile/profile.component';
import { EditPersonalInfoComponent } from './pages/edit-personal-info/edit-personal-info.component';

const routes: Routes = [
  { path: 'profile', component: ProfileComponent },
  { path: 'profile/edit', component: EditPersonalInfoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class ProfileRoutingModule {}
