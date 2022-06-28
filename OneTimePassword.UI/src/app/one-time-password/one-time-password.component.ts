import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GeneratedPasswordModel, UserOtpRequestModel } from '../core/models/generated-password.model';
import { OneTimePasswordService } from '../core/services/one-time-password.service';

@Component({
  selector: 'app-one-time-password',
  templateUrl: './one-time-password.component.html',
  styleUrls: ['./one-time-password.component.css']
})
export class OneTimePasswordComponent implements OnInit {

  userId: string = '';
  password: string = '';
  secondsLeft: number = 0;

  constructor(private route: ActivatedRoute, private router: Router, private service: OneTimePasswordService) { 
    this.userId = route.snapshot.paramMap.get("userId") ?? '';
  }

  ngOnInit(): void {
    if (this.userId == null || this.userId == "") {
      this.router.navigate(["/"]);
    }
    
    this.getPassword();

    setInterval(() => {
      if (this.secondsLeft > 0) {
        this.secondsLeft -= 1;
      }
    }, 1000);
  }

  getPassword() {
    let userOtpRequest: UserOtpRequestModel = {
      userId: this.userId,
      currentTime: new Date()
    };
    this.service.getPassword(userOtpRequest).subscribe({
      next: (response: GeneratedPasswordModel) => {
        this.password = response.password;
        this.secondsLeft = Math.floor((new Date(response.generatedTime).getTime() - new Date().getTime()) / 1000) + 30;
      },
      error: (error) => {
        console.error(error);
      }
    }
  );
  }

}
