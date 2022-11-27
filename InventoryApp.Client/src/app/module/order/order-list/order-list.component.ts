import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridApi, GridOptions, GridReadyEvent, ICellRendererParams } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
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
        private sweetalertService: SweetalertService,
        private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.title.setTitle("Đặt hàng");
    this.Title = "Quản lý đặt hàng";
    this.updateColumnDefs();
    this.getAllOrder();
  }
  public getAllOrder(){
    document.body.style.overflow = 'hidden';
    this.orderService.getAllOrder().subscribe(
      response =>{
        this.orderData = response;
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
      { field: 'orderDate', headerName: "NGÀY YÊU CẦU ĐẶT HÀNG", resizable:true},
    ];
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