import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { EmployeeService } from '../../service/employee.service';;

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
  constructor(private employeeService: EmployeeService) { }
  refresh() {
    return true;
  }
  agInit(params: any): void {
    this.params = params; 
    this.getUser();

  }
  getUser(){
    this.employeeService.getEmployeeById(this.params.value).subscribe(response => {
      this.status = response.status;
      this.statusName = this.status ? "Đang làm việc" : "Đã nghỉ việc";
      this.statusClass = this.status ? "btn-info" : "btn-secondary";
    })
  }
}