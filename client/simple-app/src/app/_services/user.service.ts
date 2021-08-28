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
    let params = new HttpParams();
    params = params.append('id', id);
    return this.http.get<User>(this.baseUrl + 'admin/GetUserByUserId', {params});
  }

  updateUser(id: number, user: User){
    let params = new HttpParams();
    params = params.append('id', id.toString());
    return this.http.put(this.baseUrl + 'admin/UpdateUser/', user, {params});
  }

  deleteUser(id) {
    let params = new HttpParams();
    params = params.append('userId', id);
    return this.http.delete(this.baseUrl + 'admin/DeleteUser/', {params});
  }
}
