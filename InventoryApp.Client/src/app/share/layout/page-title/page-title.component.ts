import { Component, Input, OnInit } from '@angular/core';

export interface PageTitle {
  title: string;
  path:string;
  active:boolean;
}

@Component({
  selector: 'app-page-title',
  templateUrl: './page-title.component.html',
  styleUrls: ['./page-title.component.css']
})
export class PageTitleComponent implements OnInit {

  @Input() title!: string;
  @Input() pageTitle!: PageTitle[];
  constructor() { }

  ngOnInit(): void {
  }

}
