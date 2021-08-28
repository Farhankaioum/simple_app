import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Permission } from '../_models/permission';

@Injectable({
  providedIn: 'root'
})
export class SettingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getPermission(): Observable<Permission[]>{
    return this.http.get<Permission[]>(this.baseUrl + 'admin/AllActionPermission');
  }

  updatePermission(id, value): Observable<any>{
    console.log('id', id);
    console.log('value', value);
    var body = {
      'id': id,
      'value': value
    };
    return this.http.put(this.baseUrl + 'admin/UpdatePermission', body)
  }
}
