import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  isAuthenticated: boolean = false;

  userSub: Subscription = new Subscription()

  constructor(private authService: AuthService,public router:Router) {}

  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe({
      next: (data) => {
        this.isAuthenticated = data ? true : false;
      }
    })
  }

  logout(){
    this.authService.logOut();
  }

  goToLogIn(){
    this.router.navigateByUrl('login');
  }

  goToResources(){
    this.router.navigateByUrl('resources');
  }

  goToDesign(){
    this.router.navigateByUrl('design');
  }

  goToDevelopment(){
    this.router.navigateByUrl('development');
  }
}
