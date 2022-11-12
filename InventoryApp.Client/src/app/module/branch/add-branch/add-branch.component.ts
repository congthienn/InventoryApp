import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';

@Component({
  selector: 'app-add-branch',
  templateUrl: './add-branch.component.html',
  styleUrls: ['./add-branch.component.css']
})
export class AddBranchComponent implements OnInit {
  public Title = '';
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/chi-nhanh/',
      title: 'Chi nhánh',
      active: false
    },
    {
      path: '/chi-nhanh/them-moi',
      title: 'Thêm mới',
      active: true
    },
  ]
  constructor(public title: Title) { }
  
  ngOnInit(): void {
    this.title.setTitle("Quản lý chi nhánh");
    this.Title = this.title.getTitle();
  }
}
