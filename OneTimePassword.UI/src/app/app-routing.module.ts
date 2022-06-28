import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { OneTimePasswordComponent } from './one-time-password/one-time-password.component';

const routes: Routes = [
    { path: 'oneTimePassword/:userId', component: OneTimePasswordComponent },
    { path: 'oneTimePassword', component: OneTimePasswordComponent },
    { path: '', component: HomeComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }