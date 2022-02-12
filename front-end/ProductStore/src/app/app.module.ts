import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ProductStoreService } from './services/product-store.service';
import { AdminUserModule } from './admin-user/admin-user.module';
import { EndUserModule } from './end-user/end-user.module';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    EndUserModule,
    AdminUserModule,
    MatButtonModule
  ],
  providers: [ProductStoreService],
  bootstrap: [AppComponent]
})
export class AppModule { }
