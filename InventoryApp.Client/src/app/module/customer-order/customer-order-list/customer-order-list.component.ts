import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridApi, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { CustomerOrderDetailComponent } from '../customer-order-detail/customer-order-detail.component';
import { CustomerOrder } from '../model/customer-order';
import { CustomerOrderService } from '../service/customer-order.service';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';
import { ButtonPaymentStatusComponent } from './button-payment-status/button-payment-status.component';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';

@Component({
  selector: 'app-customer-order-list',
  templateUrl: './customer-order-list.component.html',
  styleUrls: ['./customer-order-list.component.css']
})
export class CustomerOrderListComponent implements OnInit {
  public Title = '';
  branchList!: Array<Select2OptionData>;
  branchId!: string;
  private gridApi!: GridApi;
  public loadData = true;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  public rowSelection: 'single' | 'single' = 'single';
  orderData: CustomerOrder[] = [];
  
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/don-hang/',
      title: 'Đơn hàng',
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

  constructor(
    private customerOrderService: CustomerOrderService, 
        private title: Title, 
        private authService: AuthService, 
        private branchService: BranchService,
  ) {}

  ngOnInit(): void {
    this.title.setTitle("Đơn hàng");
    this.Title = "Quản lý đơn hàng";
    this.updateColumnDefs();
    this.getBranchData();
  }
  public getAllOrder(){
    document.body.style.overflow = 'hidden';
    this.customerOrderService.getOrderListByBranchId(this.branchId).subscribe(
      response =>{
        console.log(response);
        this.orderData = response;
        var dataRowTemp: any[]= [];
        this.orderData.forEach(element => {
          var date = new Date(element.orderDate);
          var data = {
              "code":element.code,
              "customer": element.customer.customerName, 
              "branch": element.branch.companyName, 
              "priceTotal": element.priceTotal,
              "orderDate":  `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
              "status": element.code,
              "paid": element.code
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
      { field: "code", width: 170,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButtonViewDetailComponent,
        resizable:true 
      }, 
      { field: 'status', headerName: "TRẠNG THÁI", width: 200, initialPinned: 'left', cellRenderer: ButtonUpdateStatusComponent, },
      { field: "code", headerName:"MÃ ĐƠN HÀNG", width: 170, cellStyle: {fontWeight: '500'}, initialPinned: 'left'}, 
      { field: 'paid', headerName: "THANH TOÁN", width: 180, cellRenderer: ButtonPaymentStatusComponent},
      { field: 'branch', headerName: "CHI NHÁNH", resizable:true, width: 230 },
      { field: 'priceTotal', headerName: "TỔNG GIÁ TRỊ", cellRendererFramework: CurrencyComponent},
      { field: 'orderDate', headerName: "NGÀY LẬP ĐƠN HÀNG", resizable:true},
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
