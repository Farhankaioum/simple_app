import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { AuthService } from '../_services/auth.service';
import { AlertifyService} from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private authService: AuthService,
              private router: Router,
              private alertify: AlertifyService){}
              
  canActivate(): boolean {
    if (this.authService.isAdmin()){
       return true;
    }
    this.router.navigate(['/']);
    return false;
  }
}


