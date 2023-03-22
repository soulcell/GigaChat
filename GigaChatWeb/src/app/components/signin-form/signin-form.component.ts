import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signin-form',
  templateUrl: './signin-form.component.html',
  styleUrls: ['./signin-form.component.scss']
})
export class SigninFormComponent {
  constructor(private authService: AuthService, private router: Router) { }

  public creds = {
    userName: "",
    password: ""
  }

  public error: any;

  login() {
    this.authService.login(this.creds.userName, this.creds.password)
      .subscribe({
        complete: () => {
          console.log("what");
          this.router.navigateByUrl('/');
        },
        error: (error) => {
          this.error = error;
        }
      })
  }
}
