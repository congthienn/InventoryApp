import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificationAnimationType, NotificationsService, NotificationType, Options } from 'angular2-notifications';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./../../../assets/css/theme.min.css','./login.component.css']
})
export class LoginComponent implements OnInit {
  signinForm!: FormGroup;
  @ViewChild('errorLogin') errorLogin!: TemplateRef<any>;
  constructor(
    private formBuild: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private notification: NotificationsService
  ) { 
    this.signinForm = this.formBuild.group({
      email: [''],
      password: [''],
      remember:[]
    });
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
  }

}
