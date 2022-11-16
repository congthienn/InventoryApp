import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TrademarkService {

  private trademarkURL = `${environment.serverURL}/trademark`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  
  getAllTrademark():Observable<any>{
    return this.http.get(this.trademarkURL, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      })
    )
  }
  addData(data: any):Observable<any> {
    return this.http.post(this.trademarkURL, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  deleteData(id: string):Observable<any> {
    let url = `${this.trademarkURL}/${id}`;
    return this.http.delete(url, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
}
