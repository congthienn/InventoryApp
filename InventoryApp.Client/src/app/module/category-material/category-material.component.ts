import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { AuthService } from 'src/app/auth/auth.service';
import { ActionButtonComponent } from './action-button/action-button.component';
import { AddCategoryMaterialComponent } from './add-category-material/add-category-material.component';
import { CategoryMaterialService } from './service/category-material.service';

@Component({
  selector: 'app-category-material',
  templateUrl: './category-material.component.html',
  styleUrls: ['./category-material.component.css']
})
export class CategoryMaterialComponent implements OnInit {
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
    private categoryMaterialService: CategoryMaterialService,
    private authService: AuthService
    ) {}
  enableButton = this.authService.getRole() === "Quản trị hệ thống";
  ngOnInit(): void {
    this.columnDefs  =  [
      { field: "name", headerName:"LOẠI SẢN PHẨM",width:400, cellStyle: {fontWeight: '500'}}, 
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign : 'right'},
        cellRenderer: ActionButtonComponent,
      }, 
    ];
    this.getAllCategory();
  }
  getAllCategory(){
    this.categoryMaterialService.getAllCategoryMaterial().subscribe(
      response => {  
        this.dataRow = response;
      }
    ) 
  }
  openAddCategoryMaterial(){
   this.modalService.open(AddCategoryMaterialComponent)
  }
  closeModal(){ 
    this.activeModal.dismiss();
  }
}
