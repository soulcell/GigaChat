import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup-form',
  templateUrl: './signup-form.component.html',
  styleUrls: ['./signup-form.component.scss'],
})
export class SignupFormComponent {
  constructor(private authService: AuthService, private router: Router) {}

  public creds = {
    userName: '',
    password: '',
    repeatPassword: '',
  };

  public error: any;

  signup() {
    this.authService.signup(this.creds.userName, this.creds.password).subscribe({
      complete: () => {
        this.router.navigateByUrl('/');
      },
      error: (error) => {
        this.error = error;
      },
    });
  }
}
