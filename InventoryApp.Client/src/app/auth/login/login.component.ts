import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
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
  clickLogin = false;
  constructor(
    private authService: AuthService,
    private sweetalertService: SweetalertService,
    private router: Router
  ) { 
    this.userLogin = {} as LoginModel;  
  }
  showErrorMessage = false;
  loginUser() {
    this.clickLogin = true;
    this.authService.signIn(this.signinForm.value).subscribe(
      response => {
        this.router.navigate(['/tong-quan']);
      },
      error => {
        this.loginFailed();
        this.clickLogin = false;
    });   
  }
  loginFailed() {
    this.sweetalertService.alertMini("Đăng nhập thất bại!","Email hoặc mật khẩu không chính xác","error");
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
