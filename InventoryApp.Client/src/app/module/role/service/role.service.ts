import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private roleURL = `${environment.serverURL}/role`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  getAllRole():Observable<any>{
    return this.http.get(this.roleURL).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
  deleteRole(id:string):Observable<any>{
    let url = `${this.roleURL}/${id}`;
    return this.http.delete(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
  addRole(data:any):Observable<any>{
    return this.http.post(this.roleURL,data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
}
