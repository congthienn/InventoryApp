import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificationAnimationType, NotificationsService, NotificationType, Options } from 'angular2-notifications';
import { AuthService } from '../auth.service';
import { LoginModule } from './login.module';
import { LoginModel } from './model/loginModel';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./../../../assets/css/theme.min.css','./login.component.css']
})
export class LoginComponent implements OnInit {
  signinForm!: FormGroup;
  userLogin!: LoginModel;
  
  constructor(
    private authService: AuthService,
    private notification: NotificationsService
  ) { 
    this.userLogin = {} as LoginModel;  
  }
  public options : Options = {
    position: ["top", "right"],
    timeOut: 3000,
    showProgressBar: true,
    pauseOnHover: true,
    clickToClose: true,
    animate: NotificationAnimationType.FromRight
  }

  showErrorMessage = false;
  loginUser() {
    this.authService.signIn(this.signinForm.value).subscribe(
      (response) =>{
        this.showErrorMessage = false;
      },
      (error) => {
        this.notification.error('', 'Đăng nhập không thành công');
    });   
  }
  ngOnInit(): void {
    this.signinForm = new FormGroup({
      email: new FormControl(this.userLogin.email, [
        Validators.required,
        Validators.email
      ]),
      password: new FormControl(this.userLogin.password,Validators.required),
      remember:new FormControl(this.userLogin.remember)
    });
  }
  get email() { return this.signinForm.get('email'); }
  get password() { return this.signinForm.get('password'); }
}
