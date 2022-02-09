import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminUserLandingPageComponent } from './admin-user-landing-page/admin-user-landing-page.component';

const routes: Routes = [
  { path: 'admin-user-landing-page', component: AdminUserLandingPageComponent, data: { title: 'Landing Page' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminUserRoutingModule { }
