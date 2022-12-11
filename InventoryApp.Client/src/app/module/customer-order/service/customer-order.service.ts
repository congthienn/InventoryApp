import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerOrderService {
  private customerOrderURL = `${environment.serverURL}/Order`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }

  getAllCustomerOrder(): Observable<any>{
    return this.http.get(this.customerOrderURL).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError(error => {
        return throwError(error);
      })
    )
  }
  addCustomerOrder(data: any): Observable<any> {
    return this.http.post(this.customerOrderURL, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  addReturnMaterial(data: any): Observable<any> {
    let url = `${this.customerOrderURL}/addReturnMaterial`;
    return this.http.post(url, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  

  getCustomerOrderByCode(id:string):Observable<any> {
    let url = `${this.customerOrderURL}/Code/${id}`;
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
    let url = `${this.customerOrderURL}/updateStatus/${code}`;
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

  updateOrderPayment(code:string):Observable<any>{
    let url = `${this.customerOrderURL}/UpdateOrderPayment/${code}`;
    let data = "UpdateOrderPayment";
    return this.http.put(url, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  getAllOrderByBranchId(branchId: string): Observable<any>{
    let url = `${this.customerOrderURL}/GetAllOrderByBranchId/${branchId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError(error => {
        return throwError(error);
      })
    )
  }
  getOrderListByBranchId(branchId: string): Observable<any>{
    let url = `${this.customerOrderURL}/GetOrderListByBranchId/${branchId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError(error => {
        return throwError(error);
      })
    )
  }

  getAllMaterialOrderByOrderId(orderId:string): Observable<any>{
    let url = `${this.customerOrderURL}/GetAllMaterialOrderByOrderId/${orderId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError(error => {
        return throwError(error);
      })
    )
  }
  getQuantityRequest(id:string, materialId:string):Observable<any> {
    let url =`${this.customerOrderURL}/GetQuantityRequest/${id}/${materialId}`;
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
