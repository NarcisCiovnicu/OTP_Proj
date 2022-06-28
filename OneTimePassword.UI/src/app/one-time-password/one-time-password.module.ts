import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OneTimePasswordComponent } from './one-time-password.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    OneTimePasswordComponent
  ],
  imports: [
    CommonModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    BrowserAnimationsModule,
    FormsModule
  ]
})
export class OneTimePasswordModule { }
