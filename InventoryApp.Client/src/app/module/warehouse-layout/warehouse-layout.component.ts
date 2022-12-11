import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../branch/branch.service';
import { CompanyService } from '../general/company.service';
import { SweetalertService } from '../share/sweetalert/sweetalert.service';
import { WarehouseService } from '../warehouse/service/warehouse.service';
import { ActionButonComponent } from './add-warehouse-area/action-buton/action-buton.component';
import { AddWarehouseAreaComponent } from './add-warehouse-area/add-warehouse-area.component';
import { ActionButtonWarehouseLineComponent } from './add-warehouse-line/action-button-warehouse-line/action-button-warehouse-line.component';
import { AddWarehouseLineComponent } from './add-warehouse-line/add-warehouse-line.component';
import { ActionButtonWarehouseShelveComponent } from './add-warehouse-shelve/action-button-warehouse-shelve/action-button-warehouse-shelve.component';
import { AddWarehouseShelveComponent } from './add-warehouse-shelve/add-warehouse-shelve.component';
import { WarehouseArea } from './model/warehouse-area';
import { WarehouseLine } from './model/warehouse-line';
import { WarehouseAreaService } from './service/warehouse-area.service';
import { WarehouseLineService } from './service/warehouse-line.service';
import { WarehouseShelveService } from './service/warehouse-shelve.service';

@Component({
  selector: 'app-warehouse-layout',
  templateUrl: './warehouse-layout.component.html',
  styleUrls: ['./warehouse-layout.component.css']
})
export class WarehouseLayoutComponent implements OnInit {
  public Title = '';
  public loadData = false;
  dataWarehouse: any;
  warehouseAreaItem: any;
  warehouseLineItem: any;
  dataWarehouseArea: any[] = [];
  dataWarehouseLine : any[]= [];
  dataWarehouseShelve : any[]= [];
  warehouseArea: WarehouseArea[]= [];
  warehouseLine: WarehouseLine[] = [];
  columnDefsWarehouseArea : any[]= [];
  columnDefsWarehouseLine : any[]= [];
  columnDefsWarehouseShelve : any[]= [];
  warehouseId!:string;
  warehouseAreaId!:string;
  warehouseLineId!:string;
  public rowSelectionWarehouseArea: 'single' | 'single' = 'single';
  public rowSelectionWarehouseLine: 'single' | 'single' = 'single';

  warehouseList!: Array<Select2OptionData>;
  branchList!: Array<Select2OptionData>;
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
    },
    {
      path: '/kho-hang/bo-cuc-kho',
      title: 'Bố cục kho',
      active: true
    }
  ]
  public sizePaginationWarehouseArea = 10;
  public sizePaginationWarehouseLine = 10;
  public sizePaginationWarehouseShelve = 10;
  public defaultCol: ColDef = {
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
  public showButtonAddWarehouseArea = false;
  public showButtonAddWarehouseLine = false;
  public showButtonAddWarehouseShelve = false;
  constructor(
    private warehouseService: WarehouseService, 
    private authService: AuthService,
    private branchService: BranchService,
    private title: Title, 
    private warehouseAreaService: WarehouseAreaService,
    private warehouseLineServicie: WarehouseLineService,
    private warehouseShelveServicie: WarehouseShelveService,
    public sweetalertService: SweetalertService,
    private modalService: NgbModal) {}
    
  ngOnInit(): void {
    this.title.setTitle("Bố cục kho");
    this.Title = "Quản lý bố cục kho hàng";
    this.updateColumnDefsWarehouseArea();
    this.updateColumnDefsWarehouseLine();
    this.updateColumnDefsWarehouseShelve();
    this.getBranchData();

  }
  getBranchData(){
    document.body.style.overflow = 'hidden';
    var tempData: { id: string; text: string; }[] = [];
    this.branchService.getAllBranch().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.companyName
        }
        tempData.push(data);
      });
      var branchs: unknown[] = this.authService.decodeToken().Branch;
      this.branchList = tempData.filter(item => branchs.includes(item.id));
      this.loadData = false;
      document.body.style.overflow = '';
    },
    error =>{
      this.loadData = true;
    })
  }

  changeBranchValue(branchId:any){
    if(branchId == undefined) 
      return;
    this.getWarehouseList(branchId);
  }

  private updateColumnDefsWarehouseArea() {
    this.columnDefsWarehouseArea  =  [
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButonComponent,
      }, 
      { field: "name", headerName:"KHU VỰC KHO",width:'290px'}, 
    ];
  }
  private updateColumnDefsWarehouseLine() {
    this.columnDefsWarehouseLine  =  [
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButtonWarehouseLineComponent
      }, 
      { field: "name", headerName:"TÊN DÃY",width:'290px'}, 
    ];
  }
  private updateColumnDefsWarehouseShelve() {
    this.columnDefsWarehouseShelve  =  [
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButtonWarehouseShelveComponent
      }, 
      { field: "name", headerName:"TÊN KỆ HÀNG",width:'290px'}, 
    ];
  }
  getWarehouseList(branchId:any){
    this.loadData = true;
    var tempData: { id: string; text: string; }[] = [];
    this.warehouseService.getAllWarehouseByBranchId(branchId).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      }); 
      this.warehouseList = tempData;
      this.loadData = false;
    })
  }
  onChangeWarehouse(warehouseId:any){
    if(warehouseId == undefined)
      return;
    this.warehouseId = warehouseId;
    this.dataWarehouseLine = [];
    this.dataWarehouseShelve =[];
    this.getWarehouseArea();
    this.showButtonAddWarehouseArea = true;
    this.showButtonAddWarehouseLine = false;
    this.dataWarehouse = this.warehouseList.filter(x=>x.id == warehouseId)[0];
  }
  getWarehouseArea(){ 
    this.warehouseAreaService.getAllWarehouseByWarehouseId(this.warehouseId).subscribe(
      response =>{
        this.warehouseArea = response;
        var dataRowTemp: any[]= [];
        this.warehouseArea.forEach(element => {
          var data = {
              "id":element.id,
              "name": element.name, 
              "code":element.code
            }
            dataRowTemp.push(data);
        });
        this.dataWarehouseArea = dataRowTemp;
        this.loadData = false;
      })
  }
  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePaginationWarehouseArea = Number(text);
  }

  warehouseAreaClicked(dataRow:any) {
    this.showButtonAddWarehouseLine = true;
    this.dataWarehouseShelve = [];
    this.warehouseAreaId = dataRow.data.id;
    this.getWarehouseLine();
    this.warehouseAreaItem = this.dataWarehouseArea.filter(x=>x.id == this.warehouseAreaId)[0];
  }
  warehouseLineClicked(dataRow:any) {
    this.showButtonAddWarehouseShelve = true;
    this.warehouseLineId = dataRow.data.id;
    this.getWarehouseShelve();
    this.warehouseLineItem = this.dataWarehouseLine.filter(x=>x.id == this.warehouseLineId)[0];
  }

  getWarehouseLine(){
    this.warehouseLineServicie.getAllWarehouseLineByWarehouseAreaId(this.warehouseAreaId).subscribe(
      response => {
        this.warehouseLine = response;
        var dataRowTemp: any[]= [];
        this.warehouseLine.forEach(element => {
          var data = {
              "id":element.id,
              "name": element.name, 
              "code":element.code
            }
            dataRowTemp.push(data);
        });
        this.dataWarehouseLine = dataRowTemp;
        this.loadData = false;
      }
    )
  }

  getWarehouseShelve(){
    this.warehouseShelveServicie.getWarehouseShelveByWarehouseLineId(this.warehouseLineId).subscribe(
      response => {
        this.warehouseLine = response;
        var dataRowTemp: any[]= [];
        this.warehouseLine.forEach(element => {
          var data = {
              "id":element.id,
              "name": element.name, 
              "code":element.code
            }
            dataRowTemp.push(data);
        });
        this.dataWarehouseShelve = dataRowTemp;
        this.loadData = false;
      }
    )
  }

  openModalAddWarehouseArea(){
    const modalRef = this.modalService.open(AddWarehouseAreaComponent);
    modalRef.componentInstance.warehouseData = this.dataWarehouse;
    modalRef.result.then((result) => {
      this.getWarehouseArea();
    },(reason) => {
      this.getWarehouseArea();
    });
  }

  openModalAddWarehouseLine(){
    const modalRef = this.modalService.open(AddWarehouseLineComponent);
    modalRef.componentInstance.warehouseData = this.dataWarehouse;
    modalRef.componentInstance.warehouseAreaData = this.warehouseAreaItem;
    modalRef.result.then((result) => {
      this.getWarehouseLine();
    },(reason) => {
      this.getWarehouseLine();
    });
  }
  openModalAddWarehouseShelve(){
    const modalRef = this.modalService.open(AddWarehouseShelveComponent);
    modalRef.componentInstance.warehouseData = this.dataWarehouse;
    modalRef.componentInstance.warehouseAreaData = this.warehouseAreaItem;
    modalRef.componentInstance.warehouseLineData = this.warehouseLineItem;

    modalRef.result.then((result) => {
      this.getWarehouseShelve();
    },(reason) => {
      this.getWarehouseShelve();
    });
  }
}
