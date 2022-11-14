import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  private branchURL = `${environment.serverURL}/branch`
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient, private router: Router) { }
  ObjectAvailable(action: string, name: string): Observable<any> {
    var url = `${this.branchURL}/${action}/${name}`;
    return this.http.get<any>(url,this.httpOptions).pipe(
      tap((response: boolean) =>{
        return response;
      })
    )
  }
  addBranch(data: any): Observable<any> {
    return this.http.post(this.branchURL, data, this.httpOptions).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: HttpErrorResponse): Observable<any> =>{
        return throwError(error);
      })
    );
  }
  getAllBranch():Observable<any>{
    return this.http.get(this.branchURL, this.httpOptions).pipe(
      tap((response: any) => {
        return response
      }),
      catchError((error: HttpErrorResponse): Observable<any> =>{
          return throwError(error);
      }) 
    )
  }
}
