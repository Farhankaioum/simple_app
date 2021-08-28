import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { Book } from '../_models/book';
import { User } from '../_models/user';
import { BookParams } from '../_models/bookParams';
import { AuthService } from '../_services/auth.service'

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = environment.apiUrl+ 'book/';
  user: User;

  constructor(private http: HttpClient, private authService: AuthService) { }

  loadUser() {
    this.user = JSON.parse(localStorage.getItem('user'));
  }

  getBooks(): Observable<Book[]>{
    let params = new HttpParams();
    this.loadUser();
    params = params.append('userId', this.user.id.toString());
    return this.http.get<Book[]>(this.baseUrl, {params});
  }

  getBookById(id: string): Observable<Book[]>{
    let params = new HttpParams();
    params = params.append('userId', this.user.id.toString());
    params = params.append('bookId', id);

    return this.http.get<Book[]>(this.baseUrl + 'GetById', {observe: 'response', params})
    .pipe(
      map((response: any) => {
        const books = response.body;
        console.log(books);
        return books;
      }));
  }

  postBook(book: Book){
    let params = new HttpParams();
    this.loadUser();
    params = params.append('userId', this.user.id.toString());
    return this.http.post(this.baseUrl, book, {params});
  }

  updateBook(book: Book){
    let params = new HttpParams();
    this.loadUser();
    params = params.append('userId', this.user.id.toString());
    return this.http.put(this.baseUrl, book, {params});
  }

  deleteBook(bookId: any){
    let params = new HttpParams();
    params = params.append('userId', this.user.id.toString());
    params = params.append('bookId', bookId);

    return this.http.delete(this.baseUrl, {params});
  }

  getArchiveBooks(): Observable<Book[]>{
    let params = new HttpParams();
    this.loadUser();
    params = params.append('userId', this.user.id.toString());
    return this.http.get<Book[]>(this.baseUrl + 'GetAllArchive/', {params});
  }

  archiveBook(bookId: any){
    this.loadUser();
    var body = new BookParams(bookId, this.user.id);

    return this.http.post(this.baseUrl + 'archive/', body);
  }

  retoreBookById(bookId: any){
    this.loadUser();
    var body = new BookParams(bookId, this.user.id);

    return this.http.post(this.baseUrl + 'restore', body);
  }

  retoreAllBook(){
    this.loadUser();
    var body = {
      'userId': this.user.id
    };
    return this.http.post(this.baseUrl + 'restoreAll/', body);
  }

}

