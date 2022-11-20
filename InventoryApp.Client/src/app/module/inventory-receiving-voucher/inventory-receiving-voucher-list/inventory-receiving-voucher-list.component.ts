import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GridApi, ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { Order } from '../../order/model/order';
import { ActionButtonViewDetailComponent } from '../../order/order-list/action-button-view-detail/action-button-view-detail.component';
import { ButtonUpdateStatusComponent } from '../../order/order-list/button-update-status/button-update-status.component';
import { OrderService } from '../../order/service/order.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';

@Component({
  selector: 'app-inventory-receiving-voucher-list',
  templateUrl: './inventory-receiving-voucher-list.component.html',
  styleUrls: ['./inventory-receiving-voucher-list.component.css']
})
export class InventoryReceivingVoucherListComponent implements OnInit {

  public Title = '';
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
      path: '/kho-hang/',
      title: 'Kho hàng',
      active: false
    },
    {
      path: '/danh-sach-phieu-nhap-kho/',
      title: 'Danh sách phiếu nhập kho',
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
    this.title.setTitle("Phiếu nhập kho");
    this.Title = "Quản lý phiếu nhập kho";
    this.updateColumnDefs();
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
      { field: "code", headerName:"MÃ NHẬP KHO", width:180, cellStyle: {fontWeight: '500'}, initialPinned: 'left'}, 
      { field: "code", headerName:"MÃ HÓA ĐƠN", width:180, cellStyle: {fontWeight: '500'}}, 
      { field: 'supplier', headerName: "NHÀ CUNG CẤP",width:300, cellStyle: {fontWeight: '500'},resizable:true },
      { field: 'branchRequest', headerName: "CHI NHÁNH", resizable:true, width:230 },
      { field: 'branchRequest', headerName: "KHO HÀNG", resizable:true, width:230 },
      { field: 'priceTotal', headerName: "TỔNG GIÁ TRỊ", cellRendererFramework: CurrencyComponent},
      { field: 'orderDate', headerName: "NGÀY NHẬP KHO", resizable:true, width:200},
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
