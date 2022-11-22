import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WarehouseLineService {
  private WarehouseLineURL = `${environment.serverURL}/WarehouseLine`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  getAllWarehouseLineByWarehouseAreaId(warehouseAreaId: string): Observable<any>{
    let url = `${this.WarehouseLineURL}/GetAllWarehouseLineByWarehouseAreaId/${warehouseAreaId}`;
    return this.http.get(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  addWarehouseLine(data: any): Observable<any>{
    return this.http.post(this.WarehouseLineURL, data, this.httpOptions).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  deleteWarehouseLine(warehouseLineId: string): Observable<any>{
    let url = `${this.WarehouseLineURL}/${warehouseLineId}`;
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
