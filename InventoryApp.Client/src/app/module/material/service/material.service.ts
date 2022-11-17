import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  private materialURL = `${environment.serverURL}/material`;
  constructor(private http: HttpClient) { }

  addMaterial(data:any):Observable<any> {
    return this.http.post(this.materialURL, data).pipe(
      tap((response:any) =>{
        return response;
      })
      ,catchError((error:any)=>{
        return throwError(error);
      })
    )
  }
  getAllMaterial(): Observable<any>{
    return this.http.get(this.materialURL).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error:any) =>{
        return throwError(error);
      })
    )
  }
  deleteMaterial(id:string): Observable<any>{
    let url = `${this.materialURL}/${id}`;
    return this.http.delete(url).pipe(
      tap((response:any) =>{
        return response;
      }),
      catchError((error:any) =>{
        return throwError(error);
      })
    )
  }
}
