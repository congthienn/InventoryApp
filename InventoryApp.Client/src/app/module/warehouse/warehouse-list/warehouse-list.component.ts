import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { AddWarehouseComponent } from '../add-warehouse/add-warehouse.component';
import { Warehouse } from '../model/warehouse';
import { WarehouseService } from '../service/warehouse.service';
import { ActionButtonWarehouseComponent } from './action-button-warehouse/action-button-warehouse.component';

@Component({
  selector: 'app-warehouse-list',
  templateUrl: './warehouse-list.component.html',
  styleUrls: ['./warehouse-list.component.css']
})
export class WarehouseListComponent implements OnInit {
  public Title = '';
  public loadData = true;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  public rowSelection: 'single' | 'single' = 'single';
  warehouseData: Warehouse[] = [];
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/kho-hang/',
      title: 'Kho hàng',
      active: false
    }
  ]
  public sizePagination = 10;
  public defaultColDef: ColDef = {
    width:160,
    filter: true,
    sortable: true,
    floatingFilter: true,
  };
  gridOptions: GridOptions = {
    pagination: true,
    cacheBlockSize: 10,
    paginationPageSize: 10
  };

  constructor(private warehouseService: WarehouseService, 
    private title: Title, 
    public sweetalertService: SweetalertService,
    private modalService: NgbModal) {}

  ngOnInit(): void {
    this.title.setTitle("Kho hàng");
    this.Title = "Quản lý kho hàng";
    this.updateColumnDefs();
  }
  public getAllWarehouse(){
    document.body.style.overflow = 'hidden';
    this.warehouseService.getAllWarehouse().subscribe(
      response =>{
        this.warehouseData = response;
        var dataRowTemp: any[]= [];
        this.warehouseData.forEach(element => {
          var data = {
              "id":element.id,
              "code": element.code, 
              "name": element.name, 
              "branch": element.branch.companyName,
              "maximumCapacity": `${element.maximumCapacity} sản phẩm`,
              "blank":  `${element.blank} sản phẩm`,
            }
            dataRowTemp.push(data);
        });
        this.dataRow = dataRowTemp;
        this.loadData = false;
        document.body.style.overflow = '';
      },
      error => {
        this.loadData = true;
      })
     
  }
  refreshData(){
    this.getAllWarehouse();
  }
  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButtonWarehouseComponent,
      }, 
      { field: "code", headerName:"MÃ KHO HÀNG",cellStyle: {fontWeight: '500'}}, 
      { field: 'name', headerName: "KHO HÀNG", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left',resizable:true },
      { field: 'branch', headerName: "CHI NHÁNH", width:250},
      { field: 'maximumCapacity', headerName: "SỨC CHỨA TỐI ĐA", width:190},
      { field: 'blank', headerName: "CÒN TRỐNG"},
    ];
  }

  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
  openModalAddWarehouse() {	
    const modalRef = this.modalService.open(AddWarehouseComponent).result.then((result) => {
      this.getAllWarehouse();
    },(reason) => {
      this.getAllWarehouse();
    });
  }
  onGridReady(params:any) {
    this.getAllWarehouse();
  }
}