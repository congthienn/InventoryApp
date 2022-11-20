import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import { UserService } from '../../service/user.service';

@Component({
  selector: 'app-button-update-status',
  templateUrl: './button-update-status.component.html',
  styleUrls: ['./button-update-status.component.css']
})
export class ButtonUpdateStatusComponent implements ICellRendererAngularComp {
  public params: any;
  public status!:string;
  public statusName!:string;
  public statusClass!:string;
  constructor(private userService: UserService) { }
  refresh() {
    return true;
  }
  agInit(params: any): void {
    this.params = params; 
    this.getUser();

  }
  getUser(){
    this.userService.getUserById(this.params.value).subscribe(response => {
      this.status = response.status;
      this.statusName = this.status ? "Hoạt động" : "Đã khóa";
      this.statusClass = this.status ? "btn-info" : "btn-secondary";
    })
  }
  
}
