import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
 
  private generalURL = `${environment.serverURL}/general`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true
  };
  constructor(private http: HttpClient) { }
  getCompanyInfomation(): Observable<any>{
    var url = `${this.generalURL}/companyInformation`;
    return this.http.get<any>(url, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      })
    )
  }
}