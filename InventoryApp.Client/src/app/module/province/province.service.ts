import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { District } from './model/district';
import { Province } from './model/province';
import { Ward } from './model/ward';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {

  private provinceURL = `${environment.serverURL}/province`
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };
  constructor(private http: HttpClient) { }
  getProvinceList():Observable<any>{
    return this.http.get<any>(this.provinceURL, this.httpOptions).pipe(
      map((provinces: Province[]) => provinces.map((province: any) => ({id: province.code, text: province.name})))
    ) 
  }
  getDistrictList(provinceId:string):Observable<any>{
    const url = `${this.provinceURL}/districts/${provinceId}`;
    return this.http.get<any>(url).pipe(
      map((districts: District[]) => districts.map((district: any) => ({id: district.code, text: district.name})))
    )
  }
  getWardList(districtId:string):Observable<any>{
    const url = `${this.provinceURL}/wards/${districtId}`;
    return this.http.get<any>(url).pipe(
      map((wards: Ward[]) => wards.map((ward : any) =>({id: ward.code, text: ward.name})))
    )
  }
}
