import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {

  private warehouseURL = `${environment.serverURL}/warehouse`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  
  getAllWarehouse(): Observable<any>{
    return this.http.get(this.warehouseURL, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
  addWarehouse(data:any): Observable<any> {
    return this.http.post(this.warehouseURL, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
  deleteWarehouse(id:string): Observable<any> {
    let url = `${this.warehouseURL}/${id}`;
    return this.http.delete(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
  getAllWarehouseByBranchId(branchId: string): Observable<any>{
    let url = `${this.warehouseURL}/GetAllWarehouseByBranchId/${branchId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
}
