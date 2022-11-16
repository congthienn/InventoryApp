import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerGroupService {

  private customerGroupURL = `${environment.serverURL}/customergroup`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  getAllCustomerGroup():Observable<any>{
    return this.http.get(this.customerGroupURL, this.httpOptions).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: HttpErrorResponse) => {
        return throwError(error);
      })
    )
  }
  addData(data:any):Observable<any>{
    return this.http.post(this.customerGroupURL,data,this.httpOptions).pipe(
      tap((response:any) => {
        return response;
      }),
      catchError((error:any) => {
        return throwError(error);
      })
    )
  }
  deleteData(id:string):Observable<any>{
    let url = `${this.customerGroupURL}/${id}`;
    return this.http.delete(url, this.httpOptions).pipe(
      tap((response:any) => {
        return response;
      }),
      catchError((error:any) => {
        return throwError(error);
      })
    )
  }
}
