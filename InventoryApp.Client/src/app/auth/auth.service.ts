import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginModel } from './login/model/loginModel';
import { catchError, iif, Observable, tap, throwError } from 'rxjs';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authURL = `${environment.serverURL}/auth`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient, private router: Router) { }

  signIn(user: LoginModel): Observable<any> {

    if(this.stillConfirmedRememberLogin())
        this.router.navigate(['/dashboard']);

    const url = `${this.authURL}/signIn`;
    return this.http.post(url, user, this.httpOptions).pipe(
          tap((response: any) =>{
            localStorage.setItem('access_token', response.access_token);
            if(user.remember){
              var time = new Date();
              time.setDate(time.getDate() + 3);
              localStorage.setItem('remember', time.toString());
            }
            this.router.navigate(['/dashboard']);
          }),
          catchError((error: HttpErrorResponse): Observable<any> =>{
              return throwError(error);
          }) 
      )
  }
  logOut() {
    let removeToken = localStorage.removeItem('access_token');
    localStorage.removeItem('remember');
    if (removeToken == null) {
      this.router.navigate(['/login']);
    }
  }

  getToken() {
    return localStorage.getItem('access_token');
  }
  stillConfirmedRememberLogin() : boolean {
    var rememberLogin = localStorage.getItem('remember');
    if(rememberLogin == null)
        return false;
    if(new Date() > new Date(rememberLogin)){
      return false;
    }       
    return true;
  }

  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
    return authToken !== null ? true : false;
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
