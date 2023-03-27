import { Directive, ElementRef, Input, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Directive({
  selector: '[appAuthClass]',
})
export class AuthClassDirective implements OnInit {
  @Input() appAuthClass = '';

  constructor(private el: ElementRef, private authService: AuthService) { }
  ngOnInit(): void {
    console.log(this.appAuthClass);
    if (this.authService.isAuthenticated()) {
      (this.el.nativeElement as HTMLElement).classList.add(this.appAuthClass);
    }
  }

  

}
