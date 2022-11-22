import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WarehouseAreaService {

  private WarehouseAreaURL = `${environment.serverURL}/WarehouseArea`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  getAllWarehouseByWarehouseId(warehouseId: string): Observable<any>{
    let url = `${this.WarehouseAreaURL}/GetAllWarehouseAreaByWarehouseId/${warehouseId}`;
    return this.http.get(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  addWarehouseArea(data: any): Observable<any>{
    return this.http.post(this.WarehouseAreaURL, data, this.httpOptions).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  deleteWarehouseArea(warehouseId: string): Observable<any>{
    let url = `${this.WarehouseAreaURL}/${warehouseId}`;
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
