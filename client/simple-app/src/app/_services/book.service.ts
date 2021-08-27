import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { Book } from '../_models/book';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = environment.apiUrl+ 'book/';
  user: User = JSON.parse(localStorage.getItem('user')) ;

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]>{
    return this.http.get<Book[]>(this.baseUrl + this.user.id);
  }

  getBookById(id: string): Observable<Book[]>{
    let params = new HttpParams();
    params = params.append('userId', this.user.id.toString());
    params = params.append('bookId', id);

    return this.http.get<Book[]>(this.baseUrl + 'GetById');
  }
}
