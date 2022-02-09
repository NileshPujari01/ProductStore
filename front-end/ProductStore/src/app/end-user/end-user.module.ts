import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EndUserRoutingModule } from './end-user-routing.module';
import { EndUserLandingPageComponent } from './end-user-landing-page/end-user-landing-page.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    EndUserLandingPageComponent
  ],
  imports: [
    CommonModule,
    EndUserRoutingModule,
    SharedModule
  ]
})
export class EndUserModule { }
