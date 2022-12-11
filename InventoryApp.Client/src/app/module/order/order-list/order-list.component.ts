import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridApi, GridOptions, GridReadyEvent, ICellRendererParams } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { Branch } from '../../branch/model/branch';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { Order } from '../model/order';
import { OrderService } from '../service/order.service';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  public Title = '';
  branchList!: Array<Select2OptionData>;
  public rowSelection: 'single' | 'single' = 'single';
  private gridApi!: GridApi;
  public loadData = true;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  orderData: Order[] = [];
  
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/dat-hang/',
      title: 'Đặt hàng',
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

  constructor(private orderService: OrderService, 
        private title: Title, 
       private branchService: BranchService,
       private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.title.setTitle("Đặt hàng");
    this.Title = "Quản lý đặt hàng";
    this.updateColumnDefs();
    this.getBranchData();
  }
  branchId!:string;
  public getAllOrder(){
    document.body.style.overflow = 'hidden';
    this.orderService.getSupplierOrderListByBranchId(this.branchId).subscribe(
      response =>{
        this.orderData = response;
        console.log(response)
        var dataRowTemp: any[]= [];
        this.orderData.forEach(element => {
          var date = new Date(element.orderDate);
          var data = {
              "code":element.code,
              "supplier": element.supplier.supplierName, 
              "branchRequest": element.branchRequest.companyName, 
              "priceTotal": element.priceTotal,
              "orderDate":  `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
              "status": element.code,
              "employeeName": element.employeeName
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
  private updateColumnDefs() {
    this.columnDefs  =  [ 
      { field: "code", width: 68,
        headerName: "",
        suppressFilter: false,  
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButtonViewDetailComponent,}, 
      { field: 'status', headerName: "TRẠNG THÁI", width:180, initialPinned: 'left', cellRenderer: ButtonUpdateStatusComponent},
      { field: "code", headerName:"MÃ ĐƠN ĐẶT HÀNG",width:240, cellStyle: {fontWeight: '500'}, initialPinned: 'left'}, 
      { field: 'supplier', headerName: "NHÀ CUNG CẤP",width:300, cellStyle: {fontWeight: '500'},resizable:true },
      { field: 'branchRequest', headerName: "CHI NHÁNH", resizable:true, width:230 },
      { field: 'priceTotal', headerName: "TỔNG GIÁ TRỊ", cellRendererFramework: CurrencyComponent},
      { field: 'employeeName', headerName: "NHÂN VIÊN LẬP PHIẾU", resizable:true,  width: 250, cellStyle: {fontWeight: '500'} },
      { field: 'orderDate', headerName: "NGÀY YÊU CẦU ĐẶT HÀNG", resizable:true},
    ];
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
    this.branchId = branchId;
    this.getAllOrder();
  }
  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
  refreshData(){
    this.getAllOrder();
  }
  onGridReady(params: GridReadyEvent) {
    this.gridApi = params.api;
  }
}