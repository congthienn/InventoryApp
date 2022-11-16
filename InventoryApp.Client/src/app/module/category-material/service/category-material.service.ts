import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryMaterialService {
  private categoryMaterialURL = `${environment.serverURL}/materialcategory`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }

  getAllCategoryMaterial(){
    return this.http.get(this.categoryMaterialURL, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      })
    )
  }
  addData(data: any): Observable<any>{
    return this.http.post(this.categoryMaterialURL, data, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
  deleteData(id: any): Observable<any>{
    let url = `${this.categoryMaterialURL}/${id}`;
    return this.http.delete(url, this.httpOptions).pipe(
      tap((response: any) =>{
        return response;
      }),
      catchError((error: any) =>{
        return throwError(error);
      })
    )
  }
}
