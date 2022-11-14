import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginModel } from './login/model/loginModel';
import { catchError, Observable, tap, throwError } from 'rxjs';
import jwt_decode from "jwt-decode";
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authURL = `${environment.serverURL}/auth`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true
  };
  constructor(private http: HttpClient, private router: Router) { }

  signIn(user: LoginModel): Observable<any> {

    if(this.stillConfirmedRememberLogin())
        this.router.navigate(['/tong-quan']);

    const url = `${this.authURL}/signIn`;
    return this.http.post(url, user, this.httpOptions).pipe(
          tap((response: any) =>{
            localStorage.setItem(environment.keyToken, response.access_token);
            if(user.remember){
              var time = new Date();
              time.setDate(time.getDate() + 3);
              localStorage.setItem('remember', time.toString());
            }
          }),
          catchError((error: HttpErrorResponse): Observable<any> =>{
              return throwError(error);
          }) 
      )
  }
  logOut() {
    let removeToken = localStorage.removeItem(environment.keyToken);
    localStorage.removeItem('remember');
    if (removeToken == null) {
      this.router.navigate(['/login']);
    }
  }
  
  getToken() {
    return localStorage.getItem(environment.keyToken);
  }
  stillConfirmedRememberLogin() : boolean {
    let rememberLogin = localStorage.getItem('remember');
    if(rememberLogin == null)
        return false;
    if(new Date() > new Date(rememberLogin)){
      return false;
    }       
    return true;
  }

  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem(environment.keyToken);
    return authToken !== null ? true : false;
  }
  
  getUserName(): any{
    let token = localStorage.getItem(environment.keyToken);
    if(token !== null){
      const tokenPayload = jwt_decode<any>(token);
      return tokenPayload.UserName;
    }
    return false;
  }

  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error.message;
    } else {
      // server-side error
      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }
}
