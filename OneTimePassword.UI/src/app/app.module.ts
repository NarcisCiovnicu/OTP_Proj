import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeModule } from './home/home.module';
import { OneTimePasswordModule } from './one-time-password/one-time-password.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    AppRoutingModule,
    HomeModule,
    OneTimePasswordModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
