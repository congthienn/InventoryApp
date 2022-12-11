import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions, GridApi, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { CustomerOrderService } from '../../customer-order/service/customer-order.service';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { Material } from '../../material/model/material';
import { MaterialService } from '../../material/service/material.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { ShipmentService } from '../../shipment/service/shipment.service';
import { UserService } from '../../user/service/user.service';
import { WarehouseService } from '../../warehouse/service/warehouse.service';
import { InventoryDeliveryVoucher } from '../model/inventory-delivery-voucher';
import { InventoryDeliveryVoucherDetail } from '../model/inventory-delivery-voucher-detail';
import { InventoryDeliveryVoucherService } from '../service/inventory-delivery-voucher.service';

@Component({
  selector: 'app-add-inventory-delivery-voucher',
  templateUrl: './add-inventory-delivery-voucher.component.html',
  styleUrls: ['./add-inventory-delivery-voucher.component.css']
})
export class AddInventoryDeliveryVoucherComponent implements OnInit {
  public Title = '';
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
      path: '/kho-hang/xuat-kho',
      title: 'Xuất kho',
      active: true
    },
  ]
  today: Date = new Date();
  numericalOrder = 0;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  submitData = false;
  loadData = false;
  material: Material[] = [];
  branchList!: Array<Select2OptionData>;
  branchIdValue!:string;
  orderIdValue!:string;
  quantity = 0;
  warehouseList!: Array<Select2OptionData>;
  orderList!: Array<Select2OptionData>;
  userList!:Array<Select2OptionData>;
  materialList!:Array<Select2OptionData>;
  shipmentList!:Array<Select2OptionData>;
  addInventoryDeliveryVoucherDetailForm!:FormGroup;
  addInventoryDeliveryVoucherForm!:FormGroup;
  inventoryDeliveryVoucherDetail: InventoryDeliveryVoucherDetail;
  inventoryDeliveryVoucher: InventoryDeliveryVoucher;
  showInputQuantity = false;
  public sizePagination = 10;
  public defaultColDef: ColDef = {
    width:160,
    filter: true,
    sortable: true,
    floatingFilter: true,
  };
  public totalSale = 0;
  public totalMaterial = 0;
  public totalDamagedQuantity = 0;
  public rowSelection: 'single' | 'multiple' = 'multiple';
  gridOptions: GridOptions = {
    pagination: true,
    cacheBlockSize: 10,
    paginationPageSize: 10
  };
  private gridApi!: GridApi;
  constructor(public title: Title, 
    private branchService: BranchService, 
    private warehouseService: WarehouseService,
    private materialService: MaterialService,
    private sweetalertService : SweetalertService,
    private customerOrderService: CustomerOrderService,
    private userService: UserService,
    private shipmentService: ShipmentService,
    private inventoryDeliveryVoucherService: InventoryDeliveryVoucherService,
    private authService: AuthService
    ) { 
    this.inventoryDeliveryVoucherDetail = {} as InventoryDeliveryVoucherDetail;
    this.inventoryDeliveryVoucher = {} as InventoryDeliveryVoucher;
  }
  ngOnInit(): void {
    this.title.setTitle("Xuất kho");
    this.Title = "Quản lý xuất kho";
    this.updateColumnDefs();
    this.getBranchData();
    this.materialList = [];

    this.addInventoryDeliveryVoucherDetailForm = new FormGroup({
      materialId: new FormControl(this.inventoryDeliveryVoucherDetail.materialId, [Validators.required]),
      quantityDelivery: new FormControl(this.inventoryDeliveryVoucherDetail.quantityDelivery, [Validators.required, Validators.min(0)]),
      shipmentId: new FormControl(this.inventoryDeliveryVoucherDetail.shipmentId, [Validators.required]),
    });
     
    this.addInventoryDeliveryVoucherForm = new FormGroup({
      branchId: new FormControl(this.inventoryDeliveryVoucher.branchId,[Validators.required]),
      warehouseId: new FormControl(this.inventoryDeliveryVoucher.warehouseId,[Validators.required]),
      orderId: new FormControl(this.inventoryDeliveryVoucher.orderId,[Validators.required]),
      details: new FormControl(this.inventoryDeliveryVoucher.details,[Validators.required]),
      userDeliveryId: new FormControl(this.inventoryDeliveryVoucher.userDeliveryId),
      goodsIssueDate: new FormControl(this.inventoryDeliveryVoucher.goodsIssueDate),
    });
  }
  get materialId() { return this.addInventoryDeliveryVoucherDetailForm.get('materialId'); }
  get quantityDelivery() { return this.addInventoryDeliveryVoucherDetailForm.get('quantityDelivery'); }
  get shipmentId() { return this.addInventoryDeliveryVoucherDetailForm.get('shipmentId'); }


  get branchId() { return this.addInventoryDeliveryVoucherForm.get('branchId'); }
  get warehouseId() { return this.addInventoryDeliveryVoucherForm.get('warehouseId'); }
  get orderId() { return this.addInventoryDeliveryVoucherForm.get('orderId'); }
  get details() { return this.addInventoryDeliveryVoucherForm.get('details'); }
  get userDeliveryId() { return this.addInventoryDeliveryVoucherForm.get('userDeliveryId'); }

  private updateColumnDefs() { 
    this.columnDefs  =  [
      { field: 'shipment', headerName: "LÔ HÀNG", width:300,  cellStyle: {fontWeight: '500'}, resizable:true},
      { field: "code", headerName:"MÃ SẢN PHẨM", cellStyle: {fontWeight: '500'}}, 
      { field: 'name', headerName: "TÊN SẢN PHẨM", width: 300, initialPinned: 'left', cellStyle: {fontWeight: '500'}, resizable:true },
      { field: 'price', headerName: "GIÁ XUẤT", width: 180, cellRendererFramework: CurrencyComponent,},
      { field: 'quantityDelivery', headerName: "SỐ LƯỢNG XUẤT", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'materialCategory', headerName: "NHÓM SẢN PHẨM", width:240 },
    ];
  }
  changeBranchValue(branchId: any){
    this.branchIdValue = branchId; 
    if(branchId != undefined){
      this.getOrderData(branchId);
      this.getWarehouseData(branchId);  
      this.getUserData(branchId);
      this.addInventoryDeliveryVoucherForm.patchValue({branchId: branchId != 'null' ? branchId : null});
      document.getElementById("branchId")?.focus();
    }
  }
  changWarehouseValue(warehouseId: any){
    if(warehouseId == undefined)
      return;
    this.addInventoryDeliveryVoucherForm.patchValue({warehouseId: warehouseId != 'null' ? warehouseId : null});
    document.getElementById("warehouseId")?.focus();
  }
  changeOrderValue(orderId:any){
    this.materialList = [];
    this.orderIdValue = orderId;
    if(orderId != undefined){
      this.getMaterialData();
      this.addInventoryDeliveryVoucherForm.patchValue({orderId: orderId != 'null' ? orderId : null});
      document.getElementById("orderId")?.focus();
    }
  }

  changeUserValue(userId:any){
    if(userId == undefined)
      return;
    this.addInventoryDeliveryVoucherForm.patchValue({userDeliveryId: userId != 'null' ? userId : null});
    document.getElementById("userDeliveryId")?.focus();
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
  getOrderData(branchId:string){
    var tempData: { id: string; text: string; }[] = [];
    this.customerOrderService.getAllOrderByBranchId(branchId).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.code
        }
        tempData.push(data);
      });
      this.orderList = tempData;
    })
  }
  getWarehouseData(branchId:string){
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
    })
  }
  getUserData(branchId:string){
    this.userList = [];
    var tempData: { id: string; text: string; }[] = [];
    this.userService.getUserLisByBranchId(branchId).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.userName
        }
        tempData.push(data);
      });
      this.userList = tempData;
    })
  }
  getMaterialData(){
    var tempData: { id: string; text: string; }[] = [];
    this.customerOrderService.getAllMaterialOrderByOrderId(this.orderIdValue).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.materialList = tempData;
    })
  }
  getShipmentData(){
    var tempData: { id: string; text: string; }[] = [];
    this.shipmentService.getAllShipmentByMaterialIdAndBranchId(this.materialIdValue, this.branchIdValue).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.shipmentId,
          text: `${element.shipment.code} - SL: ${element.quantityInStock}`
        }
        tempData.push(data);
      });
      this.shipmentList = tempData;
    })
  }
  refreshBranchData(){
    this.getBranchData();
  }

  changeInventoryDeliveryVoucherDetailValue(){
    this.addInventoryDeliveryVoucherForm.patchValue({details: this.dataRow });
    document.getElementById("details")?.focus();
  }
 
  materialIdValue = '';
  changMaterialValue(materialId:any){
    this.quantity = 0;
    if(materialId == undefined)
      return;
    this.materialIdValue = materialId;
    this.customerOrderService.getQuantityRequest(this.orderIdValue, materialId).subscribe(
      response => {
        this.quantity = response;
      }
    )
    this.addInventoryDeliveryVoucherDetailForm.patchValue({materialId: materialId != 'null' ? materialId : null});
    document.getElementById("materialId")?.focus();
    this.getShipmentData();
  }
  shipmentName = '';
  changShipmentValue(shipmentId:any){
    if(shipmentId == undefined)
      return;
    this.addInventoryDeliveryVoucherDetailForm.patchValue({shipmentId: shipmentId != 'null' ? shipmentId : null});
    document.getElementById("shipmentId")?.focus();
    this.shipmentName = this.shipmentList.filter(x=>x.id == shipmentId)[0].text;
  }

  addInventoryDeliveryVoucherDetail(){
    var dataRowTemp: any[]= [];
    var materialId = this.addInventoryDeliveryVoucherDetailForm.value.materialId;
    var quantityDelivery = this.addInventoryDeliveryVoucherDetailForm.value.quantityDelivery;
    var shipmentId = this.addInventoryDeliveryVoucherDetailForm.value.shipmentId;
    var shipmentAlreadyExists = this.dataRow.filter(x=>x.shipmentId == shipmentId)[0];
    if(shipmentAlreadyExists != undefined){
      this.sweetalertService.alertMini("Lô hàng đã được nhập", "Vui lòng kiểm tra lại", "error");
    }else if(Number(quantityDelivery) > Number(this.quantity)){
      this.sweetalertService.alertMini("Số lượng sản phẩm xuất không phù hợp", "Vui lòng kiểm tra lại", "error", 500);
    }else{
      this.materialService.getMaterialById(materialId).subscribe(
        response => {
          var data = {
            "shipment": this.shipmentName,
            "shipmentId":shipmentId,
            "materialId":response.id,
            "code": response.code, 
            "name": response.name, 
            "price": response.salePrice,
            "baseMaterialUnit": response.baseMaterialUnit,
            "materialCategory": response.categoryMaterial.name,
            "quantityDelivery": quantityDelivery, 
          }
            dataRowTemp.push(...this.dataRow);
            dataRowTemp.push(data);
            this.dataRow = dataRowTemp;
            this.addInventoryDeliveryVoucherDetailForm.reset();
            this.resetData();
            this.quantity = 0;
            this.materialList = [];
            this.totalMaterial = this.dataRow.reduce((a, b) => a + (b.quantityDelivery || 0), 0);
            this.totalSale = this.dataRow.reduce((a, b) => a + (b.price || 0), 0) * this.totalMaterial;
            this.changeInventoryDeliveryVoucherDetailValue();
        }
      )
    }
  }
  resetData(){
    this.materialList = [];
    this.getMaterialData();
    this.shipmentList = [];
    this.getShipmentData();
  }
  onGridReady(params: GridReadyEvent) {
    this.gridApi = params.api;
  }
  onRemoveSelected() {
    const selectedData = this.gridApi.getSelectedRows();
    if(selectedData.length == 0){
      this.sweetalertService.alertMini("Chọn sản phẩm cần xóa","", "info");
    }
    this.gridApi.applyTransaction({ remove: selectedData })!;
    for(var i = 0; i < selectedData.length; i++){
      const index = this.dataRow.indexOf(selectedData[i]);
      this.dataRow.splice(index, 1);
    }
    this.totalMaterial = this.dataRow.reduce((a, b) => a + (b.quantityDelivery || 0), 0);
    this.totalSale = this.dataRow.reduce((a, b) => a + (b.price || 0), 0) * this.totalMaterial;
    this.changeInventoryDeliveryVoucherDetailValue();
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/kho-hang/danh-sach-phieu-xuat-kho","Tạo phiếu xuất kho thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu", "Vui lòng kiểm tra lại", "error");
  }
  addInventoryDeliveryoucher(){
    this.submitData = true;
    var dateNow = new Date(Date.now());
    var userId = this.authService.getUserId();
    this.addInventoryDeliveryVoucherForm.patchValue({userDeliveryId:userId});
    this.addInventoryDeliveryVoucherForm.patchValue({goodsIssueDate: new Date(dateNow.getTime() + (dateNow.getTimezoneOffset() * 60000))})
    this.inventoryDeliveryVoucherService.addInventoryDeliveryVoucher(this.addInventoryDeliveryVoucherForm.value).subscribe(
      response => {
        this.showSuccess();
      },
      error => {
        this.showError();
        this.submitData = false;
      }
    );
  }
}