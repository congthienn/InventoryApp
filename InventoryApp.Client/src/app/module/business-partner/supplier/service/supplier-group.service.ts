import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SupplierGroupService {

  private supplierGroupURL = `${environment.serverURL}/SupplierGroup`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  
  getAllSupplierGroups(): Observable<any>{
    return this.http.get(this.supplierGroupURL, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      })
    )
  }
  addData(data:any): Observable<any> {
    return this.http.post(this.supplierGroupURL, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
  deleteData(id:string):Observable<any>{
    let url = `${this.supplierGroupURL}/${id}`;
    return this.http.delete(url, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),catchError((error:any) =>{
        return throwError(error);
      })
    )
  }
}
