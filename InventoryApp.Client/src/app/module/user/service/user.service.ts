import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private userURL = `${environment.serverURL}/user`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  getAllUser():Observable<any>{
    return this.http.get(this.userURL).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getUserById(id:string):Observable<any>{
    let url = `${this.userURL}/${id}`;
    return this.http.get(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  addUser(data: any):Observable<any>{
    return this.http.post(this.userURL, data, this.httpOptions).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
}
