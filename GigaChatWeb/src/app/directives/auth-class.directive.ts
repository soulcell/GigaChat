import { Directive, ElementRef, Input } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Directive({
  selector: '[appAuthClass]',
})
export class AuthClassDirective {
  @Input() appAuthClass = '';

  constructor(private el: ElementRef, private authService: AuthService) {
    if (this.authService.authenticated && this.appAuthClass) {
      this.el.nativeElement.classList.add(this.appAuthClass);
    }
  }

}
