import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Book } from '../_models/book';
import { BookService } from '../_services/book.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class UserBookListResolver implements Resolve<Book[]>{
    constructor(private bookService: BookService, private router: Router,
        private alertify: AlertifyService){ }

        resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Book[] | Observable<Book[]> | Promise<Book[]> {
            return this.bookService.getUserBookList().pipe(
                catchError(error => {
                    this.alertify.error('Problem retrieving data');
                    this.router.navigate(['']);
                    return of(null);
                })
            );
        }    
}