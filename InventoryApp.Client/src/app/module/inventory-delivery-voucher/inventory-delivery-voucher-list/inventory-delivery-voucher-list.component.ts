import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { GridApi, ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
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
  branchList!: Array<Select2OptionData>;
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
      path: '/kho-hang/danh-sach-phieu-xuat-kho/',
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
    private authService : AuthService,
    private branchService: BranchService,
  ){}

  ngOnInit(): void {
    this.title.setTitle("Phiếu xuất kho");
    this.Title = "Quản lý phiếu xuất kho";
    this.updateColumnDefs();
    this.getInventoryReceivingVoucher();
    this.getBranchData();
  }
  branchId!:string;
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
  getInventoryReceivingVoucher(){
    document.body.style.overflow = 'hidden';
      this.inventoryDeliveryVoucherService.getInventoryDeliveryVoucher().subscribe(
        response =>{
        this.inventoryDeliveryVoucher = response;
        this.inventoryDeliveryVoucher =  this.inventoryDeliveryVoucher.filter(item => item.branchId == this.branchId);
        var dataRowTemp: any[]= [];
        this.inventoryDeliveryVoucher.forEach(element => {
          var date = new Date(element.goodsIssueDate);
          var data = {
            "id":element.id,
            "code":element.code,
            "customer": element.order.customer.customerName,
            "branch": element.branch.companyName,
            "branchId": element.branch.id,
            "warehouse": element.warehouse.name, 
            "priceTotal": element.code,
            "order":element.order.code,
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
      { field: "order", headerName:"MÃ HÓA ĐƠN", width:200, cellStyle: {fontWeight: '500'}}, 
      { field: 'branch', headerName: "CHI NHÁNH", resizable:true, width:250 },
      { field: 'warehouse', headerName: "KHO HÀNG", resizable:true, width:250 },
      { field: 'orderDate', headerName: "NGÀY XUẤT KHO", resizable:true, width:210},
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
