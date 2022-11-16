import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { BtnCellRenderer } from 'src/app/module/share/ag-grid-button/ag-grid-button.component';
import { CustomerGroup } from '../model/customerGroup';
import { CustomerGroupService } from '../service/customer-group.service';
import { AddCustomerGroupComponent } from './add-customer-group/add-customer-group.component';
import { ButtonComponent } from './button/button.component';

@Component({
  selector: 'app-customer-group',
  templateUrl: './customer-group.component.html',
  styleUrls: ['./customer-group.component.css']
})
export class CustomerGroupComponent implements OnInit{
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

	constructor(public activeModal: NgbActiveModal, private modalService: NgbModal, private customerGroupService: CustomerGroupService) {}
  ngOnInit(): void {
    this.columnDefs  =  [
      { field: "name", headerName:"TÊN NHÓM KHÁCH HÀNG",width:400, cellStyle: {fontWeight: '500'}}, 
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign : 'right'},
        cellRenderer: ButtonComponent,
      }, 
    ];
    this.getAllCustomerGroup();
  }
  getAllCustomerGroup(){
    this.customerGroupService.getAllCustomerGroup().subscribe(
      response => {  
        this.dataRow = response;
      }
    ) 
  }
  openAddCustomerGroup(){
    const modalRef = this.modalService.open(AddCustomerGroupComponent);
  }
  closeModal(){ 
    this.activeModal.dismiss();
  }
} 
