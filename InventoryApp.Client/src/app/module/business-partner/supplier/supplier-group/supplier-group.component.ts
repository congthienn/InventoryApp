import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { SupplierGroupService } from '../service/supplier-group.service';
import { ActionButtonComponent } from './action-button/action-button.component';
import { AddSupplierGroupComponent } from './add-supplier-group/add-supplier-group.component';

@Component({
  selector: 'app-supplier-group',
  templateUrl: './supplier-group.component.html',
  styleUrls: ['./supplier-group.component.css']
})
export class SupplierGroupComponent implements OnInit {
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

	constructor(public activeModal: NgbActiveModal, private modalService: NgbModal, private supplierGroupService: SupplierGroupService) {}
  ngOnInit(): void {
    this.columnDefs  =  [
      { field: "name", headerName:"NHÓM NHÀ CUNG CẤP",width:400, cellStyle: {fontWeight: '500'}}, 
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign : 'right'},
        cellRenderer: ActionButtonComponent
      }, 
    ];
    this.getAllSupplierGroup();
  }
  getAllSupplierGroup(){
    this.supplierGroupService.getAllSupplierGroups().subscribe(
      response => {  
        this.dataRow = response;
      }
    ) 
  }
  openAddSupplierGroup(){
    this.modalService.open(AddSupplierGroupComponent).result.then(
      response => {
        this.getAllSupplierGroup();
      },reason => {
        this.getAllSupplierGroup();
      }
    )
  }
  closeModal(){ 
    this.activeModal.dismiss();
  }
} 
