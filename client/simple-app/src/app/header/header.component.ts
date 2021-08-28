import { Component, OnInit } from '@angular/core';

import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/']);
    });
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

  isAdmin(){
    return this.authService.isAdmin();
  }

  logOut(){
    localStorage.removeItem('auth-token');
    localStorage.removeItem('user');
    localStorage.removeItem('user-role');
    this.authService.decodeToken = null;
    this.authService.currentUser = null;
    this.alertify.message('logged out');
    this.router.navigate(['/']);
  }

}
