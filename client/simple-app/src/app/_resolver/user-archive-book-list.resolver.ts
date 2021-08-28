import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { User } from '../_models/user';
import { BookService } from '../_services/book.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class UserArchiveBookListResolver implements Resolve<User[]>{
    constructor(private bookService: BookService, private router: Router,
        private alertify: AlertifyService){ }

        resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): User[] | Observable<User[]> | Promise<User[]> {
            return this.bookService.getUserArchiveBooks().pipe(
                catchError(error => {
                    this.alertify.error('Problem retrieving data');
                    this.router.navigate(['']);
                    return of(null);
                })
            );
        }    
}