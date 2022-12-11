import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DeliveryCompanyService {
  private DeliveryCompanyURL = `${environment.serverURL}/DeliveryCompany`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  addDeliveryCompanyData(data:any): Observable<any> {
    return this.http.post(this.DeliveryCompanyURL, data, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error:any) =>{
        return throwError(error);
      })
    )
  }

  getAllDeliveryCompanyDataByBranchId(branchId:string) : Observable<any>{
    let url = `${this.DeliveryCompanyURL}/GetAllDeliveryCompanyByBranchId/${branchId}`;
    return this.http.get(url, this.httpOptions).pipe(
      tap((response:any) =>{
        return response;
      })
    )
  }
}