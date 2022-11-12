import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { HeaderComponent } from './share/layout/header/header.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private title:Title){}
  ngOnInit(){
    this.title.setTitle("InventoryApp");
  }
}
