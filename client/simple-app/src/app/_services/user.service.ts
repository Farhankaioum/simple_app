import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl + 'admin/GetAllUser');
  }

  getUser(id): Observable<User>{
    return this.http.get<User>(this.baseUrl + 'admin/GetUserByUserId/' + id);
  }

  updateUser(id: number, user: User){
    return this.http.put(this.baseUrl + 'admin/UpdateUser/' + id, user);
  }
}
