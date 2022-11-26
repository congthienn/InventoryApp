import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WarehouseShelveService {
  private WarehouseShelveURL = `${environment.serverURL}/WarehouseShelve`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  getWarehouseShelveNoHasProductByWarehouseLineId(warehouseLineId: string): Observable<any>{
    let url = `${this.WarehouseShelveURL}/GetWarehouseShelveNoHasProductByWarehouseLineId/${warehouseLineId}`;
    return this.http.get(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getWarehouseShelveByWarehouseLineId(warehouseLineId: string): Observable<any>{
    let url = `${this.WarehouseShelveURL}/getWarehouseShelveByWarehouseLineId/${warehouseLineId}`;
    return this.http.get(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  addWarehouseShelve(data: any): Observable<any>{
    return this.http.post(this.WarehouseShelveURL, data, this.httpOptions).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  deleteWarehouseShelve(warehouseShelveId: string): Observable<any>{
    let url = `${this.WarehouseShelveURL}/${warehouseShelveId}`;
    return this.http.delete(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
}
