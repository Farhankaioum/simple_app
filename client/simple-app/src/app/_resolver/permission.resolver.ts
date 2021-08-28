import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Permission } from '../_models/permission';
import { SettingService } from '../_services/setting.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class PermissionResolver implements Resolve<Permission[]>{
    constructor(private settingService: SettingService, private router: Router,
        private alertify: AlertifyService){ }

        resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Permission[] | Observable<Permission[]> | Promise<Permission[]> {
            return this.settingService.getPermission().pipe(
                catchError(error => {
                    this.alertify.error('Problem retrieving data');
                    this.router.navigate(['']);
                    return of(null);
                })
            );
        }    
}