import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public clicked = false;
  @Output() clickButton = new EventEmitter<boolean>();

  public userName:string = this.authService.getUserName();
  public CardImage:string = this.authService.getCardImage();
  constructor(public authService: AuthService, public router: Router) { 
  }

  Click(){
    this.clicked = !this.clicked;
    this.clickButton.emit(this.clicked);
  }

  logOut(){
    this.authService.logOut();
  }


  ngOnInit(): void {
  }

}
