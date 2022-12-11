import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  private shipmentURL = `${environment.serverURL}/Shipment`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }

  getAllShipments(): Observable<any> {
    return this.http.get(this.shipmentURL).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getAllShipmentsByBranchId(branchId:string): Observable<any> {
    let url = `${this.shipmentURL}/GetAllShipmentsByBranchId/${branchId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  GetAllShipmentHasProductByBranchId(branchId:string): Observable<any> {
    let url = `${this.shipmentURL}/GetAllShipmentHasProductByBranchId/${branchId}`;
    return this.http.get(url).pipe(
      tap((response: any) =>{
        return response;
      }), 
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  addShipment(data: any) : Observable<any> {
    return this.http.post(this.shipmentURL, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  getAllShipmentByMaterialIdAndBranchId(materialId:string, branchId:string): Observable<any> {
    let url = `${this.shipmentURL}/GetAllShipmentByMaterialIdAndBranchId/${materialId}/${branchId}`;
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
