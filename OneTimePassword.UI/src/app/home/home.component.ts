import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  userId: string = '';

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  generatePassword() {
    this.router.navigate(["/oneTimePassword", this.userId]);
  }

  isValidUserId(): boolean {
    if (this.userId == null || this.userId == '')
      return false;
    return true;
  }
}
