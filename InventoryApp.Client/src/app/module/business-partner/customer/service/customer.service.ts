import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private customerURL = `${environment.serverURL}/customer`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  addCustomerData(data:any): Observable<any> {
    return this.http.post(this.customerURL, data, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error:any) =>{
        return throwError(error);
      })
    )
  }
  getAllCustomerData() : Observable<any>{
    return this.http.get(this.customerURL, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      })
    )
  }
  deleteCustomerData(id:string):Observable<any> {
    let url = `${this.customerURL}/${id}`
    return this.http.delete(url, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error:any) => {
        return throwError(error);
      })
    )
  }
}
