import { Component, OnInit } from '@angular/core';

import { ICellRendererAngularComp } from 'ag-grid-angular';
import {  }  from '@fortawesome/free-solid-svg-icons';
import { SweetalertService } from '../sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { BranchService } from '../../branch/branch.service';
import { BranchListComponent } from '../../branch/branch-list/branch-list.component';
@Component({
  selector: 'app-ag-grid-button',
  templateUrl: './ag-grid-button.component.html',
  styleUrls: ['./ag-grid-button.component.css']
})
export class BtnCellRenderer implements ICellRendererAngularComp {
  public clickDelete = false;
  constructor(private sweetalertService: SweetalertService, private branchService: BranchService, private branchComponent: BranchListComponent){}
  refresh() {
    return false;
  }
  private params: any;

  agInit(params: any): void {
    this.params = params;
  }

  btnDelete() {  
    this.clickDelete = true;
    Swal.fire({
      title: 'Bạn muốn xóa dữ liệu?',
      text: "Có thể sẽ ảnh hưởng đến những dữ liệu khác",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Xóa dữ liệu',
      cancelButtonText: 'Hủy bỏ'
    }).then((result) => {
      this.clickDelete = false;
      if (result.isConfirmed) {    
        this.deleteBranch(this.params.value)
      }
    })
  }

  deleteBranch(id:string){
    this.branchService.deleteBranch(id).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: 'Xóa dữ liệu thành công',
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
          this.branchComponent.getAllBranch();
        })
      },
      error => {
        this.sweetalertService.alertMini("Không thể xóa dữ liệu", "Vui lòng kiểm tra lại dữ liệu!", 'error');
      }
    )
  }
  btnUpdate(){
    console.log(this.params.value);
  } 
}
