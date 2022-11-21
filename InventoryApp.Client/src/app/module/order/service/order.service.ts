import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private orderURL = `${environment.serverURL}/SupplierOrder`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }

  addOrder(data: any): Observable<any> {
    return this.http.post(this.orderURL, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getAllOrder(): Observable<any> {
    return this.http.get(this.orderURL).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getOrderByCode(id:string):Observable<any> {
    let url = `${this.orderURL}/Code/${id}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  updateStatus(code:string):Observable<any>{
    let url = `${this.orderURL}/updateStatus/${code}`;
    let data = "updateStatus";
    return this.http.put(url, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getAllSupplierOrder(branchId:string): Observable<any> {
    let url = `${this.orderURL}/GetAllSupplierOrder/${branchId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getAllMaterialOrderByOrderId(orderId: string): Observable<any>{
    let url = `${this.orderURL}/getAllMaterialOrderByOrderId/${orderId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getQuantityRequest(id:string, materialId:string):Observable<any> {
    let url =`${this.orderURL}/GetQuantityRequest/${id}/${materialId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
}
