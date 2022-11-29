import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private userURL = `${environment.serverURL}/employee`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }

  addEmployee(data: any):Observable<any>{
    return this.http.post(this.userURL, data).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }
  
  getAllEmployee():Observable<any>{
    let url = `${this.userURL}/GetAllEmployee`;
    return this.http.get(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  getEmployeeById(employeeId:string):Observable<any>{
    let url = `${this.userURL}/GetEmployeeById/${employeeId}`;
    return this.http.get(url).pipe(
      tap((response: any) => {
        return response;
      }),
      catchError((error: any) => {
        return throwError(error);
      })
    )
  }

  deleteEmployeeById(employeeId:string):Observable<any>{
    let url = `${this.userURL}/DeleteEmployeeById/${employeeId}`;
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
