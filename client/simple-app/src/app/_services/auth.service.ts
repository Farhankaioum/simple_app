import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

import { environment } from '../../environments/environment';
import { User } from '../_models/user';
import { Role } from '../_models/role';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodeToken: any;
  currentUser: User;
  user: User;

  constructor(private http: HttpClient) { }

  loadUser() {
    this.user = JSON.parse(localStorage.getItem('user'));
  }

  login(model: any){
  return this.http.post(this.baseUrl + 'login', model)
    .pipe(
      map((response: any) => {
        const user = response;
        if (user){
          localStorage.setItem('auth-token', user.token);
          localStorage.setItem('user', JSON.stringify(user.user));
          localStorage.setItem('user-role', user.isAdmin);
          this.loadUser();
          console.log('user', this.user);
          this.currentUser = user.user;
          this.decodeToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
}

  register(user: User){
    return this.http.post(this.baseUrl + 'register', user);
  }

  loggedIn(){
    const token = localStorage.getItem('auth-token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  isAdmin(): boolean {
    const role = localStorage.getItem('user-role');
    return role === 'true';
  }
}
