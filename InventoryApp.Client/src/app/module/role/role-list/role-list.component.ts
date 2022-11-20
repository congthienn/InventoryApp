import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { AddRoleComponent } from '../add-role/add-role.component';
import { RoleService } from '../service/role.service';
import { ActionButtonComponent } from './action-button/action-button.component';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.css']
})
export class RoleListComponent implements OnInit {

  public sizePagination = 10;
  columnDefs : any[]= [];
  dataRow: any[] = [];
  public defaultColDef: ColDef = {
    width:160,
    filter: true,
    sortable: true,
    floatingFilter: true,
  };
  gridOptions:GridOptions = {
    pagination: true,
    cacheBlockSize: 10,
    paginationPageSize: 10
  };

	constructor(public activeModal: NgbActiveModal, 
    private modalService: NgbModal, 
    private roleService: RoleService) {}
  ngOnInit(): void {
    this.columnDefs  =  [
      { field: "name", headerName:"VAI TRÒ",width:400, cellStyle: {fontWeight: '500'}}, 
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign : 'right'},
        cellRenderer: ActionButtonComponent,
      }, 
    ];
    this.getAllRole();
  }
  closeModal(){ 
    this.activeModal.dismiss();
  }
  getAllRole(){
    this.roleService.getAllRole().subscribe(response =>{
      this.dataRow = response;
    })
  }
  openModalAddRole(){
    this.modalService.open(AddRoleComponent);
  }
}
