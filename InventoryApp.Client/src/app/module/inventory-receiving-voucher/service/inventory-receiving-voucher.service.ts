import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InventoryReceivingVoucherService {
  private URL = `${environment.serverURL}/InventoryReceivingVoucher`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }

  addInventoryReceivingVoucher(data:any): Observable<any> {
    return this.http.post(this.URL, data, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  getInventoryReceivingVoucher(): Observable<any> {
    let url = `${this.URL}/getInventoryReceivingVoucher`;
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
