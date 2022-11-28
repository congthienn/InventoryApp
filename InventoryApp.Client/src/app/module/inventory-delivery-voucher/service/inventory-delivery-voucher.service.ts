import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InventoryDeliveryVoucherService {
  private URL = `${environment.serverURL}/InventoryDeliveryVoucher`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }

  addInventoryDeliveryVoucher(data:any): Observable<any> {
    return this.http.post(this.URL, data, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  getInventoryDeliveryVoucher(): Observable<any> {
    return this.http.get(this.URL).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  getInventoryDeliveryVoucherById(id:string): Observable<any>{
    let url = `${this.URL}/GetInventoryDeliveryVoucherById/${id}`;
    return this.http.get(url).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
}