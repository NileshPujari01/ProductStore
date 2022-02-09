import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EndUserLandingPageComponent } from './end-user-landing-page/end-user-landing-page.component';

const routes: Routes = [
  { path: 'end-user-landing-page', component: EndUserLandingPageComponent, data: { title: 'Landing Page' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EndUserRoutingModule { }
