import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';

const routes: Routes = [
  { 
    path: 'home-landing', 
    component: LandingPageComponent, 
    data: { title: 'Welcome!' } 
  },
  {
    path: 'admin-user',
    loadChildren: () => import('./admin-user/admin-user.module').then((x) => x.AdminUserModule)
  },
  {
    path: 'end-user',
    loadChildren: () => import('./end-user/end-user.module').then((x) => x.EndUserModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
