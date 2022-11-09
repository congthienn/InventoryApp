import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./../../../assets/css/theme.min.css','./login.component.css']
})
export class LoginComponent implements OnInit {
  signinForm!: FormGroup;

  constructor(
    public formBuild: FormBuilder,
    public authService: AuthService,
    public router: Router
  ) { 
    this.signinForm = this.formBuild.group({
      email: [''],
      password: [''],
    });

  }

  ngOnInit(): void {
  }

}
