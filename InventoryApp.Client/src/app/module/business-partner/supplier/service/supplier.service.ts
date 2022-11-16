import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  private supplierURL = `${environment.serverURL}/Supplier`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  addData(data:any):Observable<any> {
    return this.http.post(this.supplierURL, data, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error:any) =>{
        return throwError(error);
      })
    )
  }
  getSupplierData() : Observable<any> {
    return this.http.get(this.supplierURL, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      })
    )
  }
  deleteData(id:string):Observable<any> {
    let url = `${this.supplierURL}/${id}`;
    return this.http.delete(url, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error:any) =>{
        return throwError(error);
      })
    )
  }
}
