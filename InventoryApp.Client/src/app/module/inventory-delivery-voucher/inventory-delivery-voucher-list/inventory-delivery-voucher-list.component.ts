import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { GridApi, ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { Order } from '../../order/model/order';
import { InventoryDeliveryVoucher } from '../model/inventory-delivery-voucher';
import { InventoryDeliveryVoucherService } from '../service/inventory-delivery-voucher.service';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';

@Component({
  selector: 'app-inventory-delivery-voucher-list',
  templateUrl: './inventory-delivery-voucher-list.component.html',
  styleUrls: ['./inventory-delivery-voucher-list.component.css']
})
export class InventoryDeliveryVoucherListComponent implements OnInit {

  public Title = '';
  private gridApi!: GridApi;
  public rowSelection: 'single' | 'single' = 'single';
  public loadData = true;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  orderData: Order[] = [];
  inventoryDeliveryVoucher : InventoryDeliveryVoucher[] = [];
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
      path: '/danh-sach-phieu-xuat-kho/',
      title: 'Danh sách phiếu xuất kho',
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
        private title: Title, 
        private inventoryDeliveryVoucherService : InventoryDeliveryVoucherService,
  ) {}

  ngOnInit(): void {
    this.title.setTitle("Phiếu xuất kho");
    this.Title = "Quản lý phiếu xuất kho";
    this.updateColumnDefs();
    this.getInventoryReceivingVoucher();
  }

  getInventoryReceivingVoucher(){
    document.body.style.overflow = 'hidden';
      this.inventoryDeliveryVoucherService.getInventoryDeliveryVoucher().subscribe(
        response =>{
        this.inventoryDeliveryVoucher = response;
        var dataRowTemp: any[]= [];
        this.inventoryDeliveryVoucher.forEach(element => {
          var date = new Date(element.goodsIssueDate);
          var data = {
            "id":element.id,
            "code":element.code,
            "customer": element.order.customer.customerName,
            "branch": element.branch.companyName,
            "warehouse": element.warehouse.name, 
            "priceTotal": element.code,
            "order":element.order.code,
            "orderDate":  `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
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
      { field: "id", width: 68,
        headerName: "",
        suppressFilter: false,  
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButtonViewDetailComponent,}, 
      { field: "code", headerName:"MÃ XUẤT KHO", width:180, cellStyle: {fontWeight: '500'}, initialPinned: 'left'}, 
      { field: "order", headerName:"MÃ HÓA ĐƠN", width:180, cellStyle: {fontWeight: '500'}}, 
      { field: 'customer', headerName: "KHÁCH HÀNG", width:300, cellStyle: {fontWeight: '500'},resizable:true },
      { field: 'branch', headerName: "CHI NHÁNH", resizable:true, width:230 },
      { field: 'warehouse', headerName: "KHO HÀNG", resizable:true, width:230 },
      { field: 'orderDate', headerName: "NGÀY XUẤT KHO", resizable:true, width:200},
    ];
  }

  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
  refreshData(){
    this.getInventoryReceivingVoucher();
  }
  onGridReady(params: GridReadyEvent) {
    this.gridApi = params.api;
  }

}
