import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GridApi, ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { Order } from '../../order/model/order';

import { OrderService } from '../../order/service/order.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { InventoryReceivingVoucher } from '../model/inventory-receiving-voucher';
import { InventoryReceivingVoucherService } from '../service/inventory-receiving-voucher.service';
import { ActionButtonViewDetailComponent } from './action-button-view-detail/action-button-view-detail.component';

@Component({
  selector: 'app-inventory-receiving-voucher-list',
  templateUrl: './inventory-receiving-voucher-list.component.html',
  styleUrls: ['./inventory-receiving-voucher-list.component.css']
})
export class InventoryReceivingVoucherListComponent implements OnInit {

  public Title = '';
  private gridApi!: GridApi;
  branchId!:string;
  public rowSelection: 'single' | 'single' = 'single';
  public loadData = true;
  branchList!: Array<Select2OptionData>;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  orderData: Order[] = [];
  inventoryReceivingVoucher : InventoryReceivingVoucher[] = [];
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
        private inventoryReceivingVoucherService : InventoryReceivingVoucherService,
        private authService: AuthService,
        private branchService: BranchService,
  ) {}

  ngOnInit(): void {
    this.title.setTitle("Phiếu nhập kho");
    this.Title = "Quản lý phiếu nhập kho";
    this.updateColumnDefs();
    this.getBranchData();
  }

  getInventoryReceivingVoucher(){
    document.body.style.overflow = 'hidden';
      this.inventoryReceivingVoucherService.getInventoryReceivingVoucher().subscribe(
        response =>{
        this.inventoryReceivingVoucher = response;
        this.inventoryReceivingVoucher = this.inventoryReceivingVoucher.filter(item => item.branchRequestId == this.branchId);
        var dataRowTemp: any[]= [];
        this.inventoryReceivingVoucher.forEach(element => {
          var date = new Date(element.goodsImportDate);
          var data = {
            "id":element.id,
            "code":element.code,
            "supplier": element.supplierOrder.supplier.supplierName, 
            "branchRequest": element.branchRequest.companyName,
            "branchId": element.branchRequest.id,
            "warehouse": element.warehouse.name, 
            "priceTotal": element.code,
            "supplierOrder":element.supplierOrder.code,
            "orderDate":  `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
            }
            dataRowTemp.push(data);
        });
        var branchs: unknown[] = this.authService.decodeToken().Branch;
        this.dataRow = dataRowTemp.filter(item => branchs.includes(item.branchId));
        this.loadData = false;
        document.body.style.overflow = '';
      },
      error => {
        this.loadData = true;
      })
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
    this.getInventoryReceivingVoucher();
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
      { field: "code", headerName:"MÃ NHẬP KHO", width:180, cellStyle: {fontWeight: '500'}, initialPinned: 'left'}, 
      { field: "supplierOrder", headerName:"MÃ HÓA ĐƠN", width:180, cellStyle: {fontWeight: '500'}}, 
      { field: 'supplier', headerName: "NHÀ CUNG CẤP", width:300, cellStyle: {fontWeight: '500'},resizable:true },
      { field: 'branchRequest', headerName: "CHI NHÁNH", resizable:true, width:230 },
      { field: 'warehouse', headerName: "KHO HÀNG", resizable:true, width:230 },
      { field: 'orderDate', headerName: "NGÀY NHẬP KHO", resizable:true, width:200},
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
