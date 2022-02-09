import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminUserRoutingModule } from './admin-user-routing.module';
import { AdminUserLandingPageComponent } from './admin-user-landing-page/admin-user-landing-page.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AdminUserLandingPageComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AdminUserRoutingModule
  ]
})
export class AdminUserModule {
  
 }
