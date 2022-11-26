import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions, GridApi, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import Swal from 'sweetalert2';
import { BranchService } from '../../branch/branch.service';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { Material } from '../../material/model/material';
import { MaterialService } from '../../material/service/material.service';
import { Order } from '../../order/model/order';
import { OrderDetail } from '../../order/model/order-detail';
import { OrderService } from '../../order/service/order.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { AddShipmentComponent } from '../../shipment/add-shipment/add-shipment.component';
import { ShipmentService } from '../../shipment/service/shipment.service';
import { UserService } from '../../user/service/user.service';
import { WarehouseAreaService } from '../../warehouse-layout/service/warehouse-area.service';
import { WarehouseLineService } from '../../warehouse-layout/service/warehouse-line.service';
import { WarehouseShelveService } from '../../warehouse-layout/service/warehouse-shelve.service';
import { WarehouseService } from '../../warehouse/service/warehouse.service';
import { InventoryReceivingVoucher } from '../model/inventory-receiving-voucher';
import { InventoryReceivingVoucherDetail } from '../model/inventory-receiving-voucher-detail';
import { InventoryReceivingVoucherService } from '../service/inventory-receiving-voucher.service';

@Component({
  selector: 'app-add-inventory-receiving-voucher',
  templateUrl: './add-inventory-receiving-voucher.component.html',
  styleUrls: ['./add-inventory-receiving-voucher.component.css']
})
export class AddInventoryReceivingVoucherComponent implements OnInit {
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
      path: '/kho-hang/nhap-kho',
      title: 'Nhập kho',
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
  branchId!:string;
  orderIdValue!:string;
  quantity = 0;
  warehouseList!: Array<Select2OptionData>;
  orderList!: Array<Select2OptionData>;
  userList!:Array<Select2OptionData>;
  materialList!:Array<Select2OptionData>;
  shipmentList!:Array<Select2OptionData>;
  warehouseArea!:Array<Select2OptionData>;
  warehouseLine!:Array<Select2OptionData>;
  warehouseShelve!:Array<Select2OptionData>;
  addInventoryReceivingVoucherDetailForm!:FormGroup;
  addInventoryReceivingVoucherForm!:FormGroup;
  inventoryReceivingVoucherDetailValue: InventoryReceivingVoucherDetail;
  inventoryReceivingVoucher:InventoryReceivingVoucher;
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
    private orderService: OrderService,
    private userService: UserService,
    private shipmentService: ShipmentService,
    private modalService: NgbModal,
    private warehouseAreaService: WarehouseAreaService,
    private warehouseLineService: WarehouseLineService,
    private warehouseShelveService: WarehouseShelveService,
    private inventoryReceivingVoucherService: InventoryReceivingVoucherService
    ) { 
    this.inventoryReceivingVoucherDetailValue = {} as InventoryReceivingVoucherDetail;
    this.inventoryReceivingVoucher = {} as InventoryReceivingVoucher;
  }
  ngOnInit(): void {
    this.title.setTitle("Nhập kho");
    this.Title = "Quản lý nhập kho";
    this.updateColumnDefs();
    this.getBranchData();
    this.materialList = [];
    this.addInventoryReceivingVoucherDetailForm = new FormGroup({
      materialId: new FormControl(this.inventoryReceivingVoucherDetailValue.materialId, [Validators.required]),
      quantityReceiving: new FormControl(this.inventoryReceivingVoucherDetailValue.quantityReceiving, [Validators.required, Validators.min(0)]),
      shipmentId: new FormControl(this.inventoryReceivingVoucherDetailValue.shipmentId, [Validators.required]),
      damagedQuantity: new FormControl(this.inventoryReceivingVoucherDetailValue.damagedQuantity, [Validators.required]),
      warehouseShelveId: new FormControl(this.inventoryReceivingVoucherDetailValue.warehouseShelveId, [Validators.required]),
    });
     
    this.addInventoryReceivingVoucherForm = new FormGroup({
      branchRequestId: new FormControl(this.inventoryReceivingVoucher.branchRequestId,[Validators.required]),
      warehouseId: new FormControl(this.inventoryReceivingVoucher.warehouseId,[Validators.required]),
      supplierOrderId: new FormControl(this.inventoryReceivingVoucher.supplierOrderId,[Validators.required]),
      detail: new FormControl(this.inventoryReceivingVoucher.detail,[Validators.required]),
      userReceiveId: new FormControl(this.inventoryReceivingVoucher.userReceiveId,[Validators.required]),
      goodsImportDate: new FormControl(this.inventoryReceivingVoucher.goodsImportDate),
    });
  }
  get materialId() { return this.addInventoryReceivingVoucherDetailForm.get('materialId'); }
  get quantityReceiving() { return this.addInventoryReceivingVoucherDetailForm.get('quantityReceiving'); }
  get shipmentId() { return this.addInventoryReceivingVoucherDetailForm.get('shipmentId'); }
  get damagedQuantity() { return this.addInventoryReceivingVoucherDetailForm.get('damagedQuantity'); }
  get warehouseShelveId() { return this.addInventoryReceivingVoucherDetailForm.get('warehouseShelveId'); }


  get branchRequestId() { return this.addInventoryReceivingVoucherForm.get('branchRequestId'); }
  get warehouseId() { return this.addInventoryReceivingVoucherForm.get('warehouseId'); }
  get supplierOrderId() { return this.addInventoryReceivingVoucherForm.get('supplierOrderId'); }
  get detail() { return this.addInventoryReceivingVoucherForm.get('detail'); }
  get userReceiveId() { return this.addInventoryReceivingVoucherForm.get('userReceiveId'); }

  private updateColumnDefs() { 
    this.columnDefs  =  [
      { field: 'shipment', headerName: "LÔ HÀNG", width:240,  cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true},
      { field: "code", headerName:"MÃ SẢN PHẨM", cellStyle: {fontWeight: '500'}}, 
      { field: 'name', headerName: "TÊN SẢN PHẨM", width: 300,  cellStyle: {fontWeight: '500'},resizable:true },
      { field: 'price', headerName: "GIÁ NHẬP", width: 180, cellRendererFramework: CurrencyComponent,},
      { field: 'quantityReceiving', headerName: "SỐ LƯỢNG NHẬP", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'damagedQuantity', headerName: "SỐ LƯỢNG HƯ HẠI", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'materialCategory', headerName: "NHÓM SẢN PHẨM", width:240 },
      { field: 'materialPosistion', headerName: "VỊ TRÍ SẢN PHẨM", width:240 },
    ];
  }
  changeBranchValue(branchId: any){
    this.branchId = branchId; 
    this.warehouseArea = [];
    this.warehouseLine = [];
    this.warehouseShelve = [];
    if(branchId != undefined){
      this.getOrderData(branchId);
      this.getWarehouseData(branchId);  
      this.getUserData(branchId);
      this.getShipmentData();
      this.addInventoryReceivingVoucherForm.patchValue({branchRequestId: branchId != 'null' ? branchId : null});
      document.getElementById("branchRequestId")?.focus();
    }
  }

  warehouseIdValue = '';
  changWarehouseValue(warehouseId: any){
    if(warehouseId == undefined)
      return;
    this.warehouseIdValue = warehouseId;
    this.warehouseArea = [];
    this.warehouseLine = [];
    this.warehouseShelve = [];
    this.getWarehouseArea();
    this.addInventoryReceivingVoucherForm.patchValue({warehouseId: warehouseId != 'null' ? warehouseId : null});
    document.getElementById("warehouseId")?.focus();
  }

  changeOrderValue(orderId:any){
    this.materialList = [];
    this.orderIdValue = orderId;
    if(orderId != undefined){
      this.getMaterialData();
      this.addInventoryReceivingVoucherForm.patchValue({supplierOrderId: orderId != 'null' ? orderId : null});
      document.getElementById("supplierOrderId")?.focus();
    }
  }

  changeUserValue(userId:any){
    if(userId == undefined)
      return;
    this.addInventoryReceivingVoucherForm.patchValue({userReceiveId: userId != 'null' ? userId : null});
    document.getElementById("userReceiveId")?.focus();
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
      this.branchList = tempData;
      this.loadData = false;
      document.body.style.overflow = '';
    },
    error =>{
      this.loadData = true;
    })
  }
  getOrderData(branchId:string){
    var tempData: { id: string; text: string; }[] = [];
    this.orderService.getAllSupplierOrder(branchId).subscribe(response => {
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
    this.orderService.getAllMaterialOrderByOrderId(this.orderIdValue).subscribe(response => {
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
    this.shipmentService.getAllShipmentsByBranchId(this.branchId).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.code
        }
        tempData.push(data);
      });
      this.shipmentList = tempData;
    })
  }
  refreshBranchData(){
    this.getBranchData();
  }
  getWarehouseArea(){ 
    var tempData: { id: string; text: string; }[] = [];
    this.warehouseAreaService.getAllWarehouseByWarehouseId(this.warehouseIdValue).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.warehouseArea = tempData;
    })
  }
  getWarehouseLine(warehouseAreaId:string){ 
    var tempData: { id: string; text: string; }[] = [];
    this.warehouseLineService.getAllWarehouseLineByWarehouseAreaId(warehouseAreaId).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.warehouseLine = tempData;
    })
  }
  changeInventoryReceivingVoucherDetailValue(){
    this.addInventoryReceivingVoucherForm.patchValue({detail: this.dataRow });
    document.getElementById("detail")?.focus();
  }
  getWarehouseShelve(warehouseLineId:string){ 
    var tempData: { id: string; text: string; }[] = [];
    this.warehouseShelveService.getAllWarehouseShelveByWarehouseLineId(warehouseLineId).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.warehouseShelve = tempData;
    })
  }
  warehouseAreaName = '';
  changWarehouseAreaValue(warehouseAreaId: any){
    if(warehouseAreaId ==  undefined)
      return;
    this.warehouseShelve = [];
    this.getWarehouseLine(warehouseAreaId);
    this.warehouseAreaName = this.warehouseArea.filter(x=>x.id == warehouseAreaId)[0].text;
  }

  warehouseLineName = '';
  changWarehouseLineValue(warehouseLineId: any){
    if(warehouseLineId ==  undefined)
      return;
    this.getWarehouseShelve(warehouseLineId);
    this.warehouseLineName = this.warehouseLine.filter(x=>x.id == warehouseLineId)[0].text;
  }

  warehouseShelveName = '';
  changWarehouseShelveValue(warehouseShelveId:any){ 
    if(warehouseShelveId == undefined)
      return;
    this.addInventoryReceivingVoucherDetailForm.patchValue({warehouseShelveId: warehouseShelveId != 'null' ? warehouseShelveId : null});
    document.getElementById("warehouseShelveId")?.focus();
    this.warehouseShelveName = this.warehouseShelve.filter(x=>x.id == warehouseShelveId)[0].text;
  }

  changMaterialValue(materialId:any){
    this.quantity = 0;
    if(materialId == undefined)
      return;
    this.addInventoryReceivingVoucherDetailForm.patchValue({materialId: materialId != 'null' ? materialId : null});
    document.getElementById("materialId")?.focus();
    this.orderService.getQuantityRequest(this.orderIdValue, materialId).subscribe(
      response => {
        this.quantity = response;
      }
    )
    this.addInventoryReceivingVoucherDetailForm.patchValue({materialId: materialId != 'null' ? materialId : null});
      document.getElementById("materialId")?.focus();
  }
  shipmentName = '';
  changShipmentValue(shipmentId:any){
    if(shipmentId == undefined)
      return;
    this.addInventoryReceivingVoucherDetailForm.patchValue({shipmentId: shipmentId != 'null' ? shipmentId : null});
    document.getElementById("shipmentId")?.focus();
    this.shipmentName = this.shipmentList.filter(x=>x.id == shipmentId)[0].text;
  }

  addInventoryReceivingVoucherDetail(){

    var dataRowTemp: any[]= [];
    var materialId = this.addInventoryReceivingVoucherDetailForm.value.materialId;
    var quantityReceiving = this.addInventoryReceivingVoucherDetailForm.value.quantityReceiving;
    var damagedQuantity = this.addInventoryReceivingVoucherDetailForm.value.damagedQuantity;
    var shipmentId = this.addInventoryReceivingVoucherDetailForm.value.shipmentId;
    var warehouseShelveId = this.addInventoryReceivingVoucherDetailForm.value.warehouseShelveId;
    var materialAlreadyExists = this.dataRow.filter(x=>x.materialId == materialId)[0];
    var shipmentAlreadyExists = this.dataRow.filter(x=>x.shipmentId == shipmentId)[0];
    var warehouseShelveExits = this.dataRow.filter(x=>x.warehouseShelveId == warehouseShelveId)[0];
    if(materialAlreadyExists != undefined){
      this.sweetalertService.alertMini("Sản phẩm đã được nhập", "Vui lòng kiểm tra lại", "error");
    }else if(shipmentAlreadyExists != undefined){
      this.sweetalertService.alertMini("Lô hàng đã được nhập", "Vui lòng kiểm tra lại", "error");
    }else if(warehouseShelveExits != undefined){
      this.sweetalertService.alertMini("Kệ hàng đã có sản phẩm", "Vui lòng kiểm tra lại", "error");
    }
    else{
      this.materialService.getMaterialById(materialId).subscribe(
        response => {
          var data = {
            "shipment": this.shipmentName,
            "warehouseShelveId":warehouseShelveId,
            "shipmentId":shipmentId,
            "damagedQuantity":damagedQuantity,
            "materialId":response.id,
            "code": response.code, 
            "name": response.name, 
            "price": response.costPrice,
            "baseMaterialUnit": response.baseMaterialUnit,
            "materialCategory": response.categoryMaterial.name,
            "quantityReceiving": quantityReceiving, 
            "materialPosistion": `${this.warehouseAreaName}, ${this.warehouseLineName}, ${this.warehouseShelveName}`
          }
            dataRowTemp.push(...this.dataRow);
            dataRowTemp.push(data);
            this.dataRow = dataRowTemp;
            this.addInventoryReceivingVoucherDetailForm.reset();
            this.resetData();
            this.quantity = 0;
            this.materialList = [];
            this.totalMaterial = this.dataRow.reduce((a, b) => a + (b.quantityReceiving || 0), 0);
            this.totalSale = this.dataRow.reduce((a, b) => a + (b.price || 0), 0) * this.totalMaterial;
            this.totalDamagedQuantity = this.dataRow.reduce((a, b) => a + (b.damagedQuantity || 0), 0);
            this.changeInventoryReceivingVoucherDetailValue();
            console.log(this.addInventoryReceivingVoucherForm);
        }
      )
    }
  }
  resetData(){
    this.materialList = [];
    this.getMaterialData();
    this.shipmentList = [];
    this.getShipmentData();
    this.warehouseArea = [];
    this.getWarehouseArea();
    this.warehouseLine = [];
    this.warehouseShelve = [];
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
    this.totalMaterial = this.dataRow.reduce((a, b) => a + (b.quantityRequest || 0), 0);
    this.totalSale = this.dataRow.reduce((a, b) => a + (b.salePrice || 0), 0) * this.totalMaterial;
    this.changeInventoryReceivingVoucherDetailValue();
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/kho-hang/danh-sach-phieu-nhap-kho","Thêm đơn đặt hàng thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu", "Vui lòng kiểm tra lại", "error");
  }
  addInventoryReceivingVoucher(){
    this.submitData = true;
    var dateNow = new Date(Date.now());
    this.addInventoryReceivingVoucherForm.patchValue({goodsImportDate: new Date(dateNow.getTime() + (dateNow.getTimezoneOffset() * 60000))})
    this.inventoryReceivingVoucherService.addInventoryReceivingVoucher(this.addInventoryReceivingVoucherForm.value).subscribe(
      response => {
        this.showSuccess();
      },
      error => {
        this.showError();
        this.submitData = false;
      }
    );
  }
  openModalAddShipment() {	
    if(this.branchId == undefined)
      return;
    const modalRef = this.modalService.open(AddShipmentComponent);
    modalRef.componentInstance.branchIdInput = this.branchId;
    modalRef.result.then(
      (result) => {
        this.getShipmentData();
      },(reason) => {
        this.getShipmentData();
      });
  }
}