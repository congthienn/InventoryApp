import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public clicked = false;
  @Output() clickButton = new EventEmitter<boolean>();
  
  constructor() { 
  }

  Click(){
    this.clicked = !this.clicked;
    this.clickButton.emit(this.clicked);
  }

  ngOnInit(): void {
  }

}
