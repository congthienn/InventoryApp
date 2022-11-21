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
import { WarehouseService } from '../../warehouse/service/warehouse.service';

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
  orderId!:string;
  quantity!:string;
  warehouseList!: Array<Select2OptionData>;
  orderList!: Array<Select2OptionData>;
  userList!:Array<Select2OptionData>;
  materialList!:Array<Select2OptionData>;
  shipmentList!:Array<Select2OptionData>;
  addOrderDetailForm!:FormGroup;
  addOrderForm!:FormGroup;
  orderDetailValue: OrderDetail;
  order:Order;
  showInputQuantity = false;
  public sizePagination = 10;
  public defaultColDef: ColDef = {
    width:160,
    filter: true,
    sortable: true,
    floatingFilter: true,
  };
  public totalSale =0;
  public totalMaterial = 0;
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
    private modalService: NgbModal
    ) { 
    this.orderDetailValue = {} as OrderDetail;
    this.order = {} as Order;
  }
  ngOnInit(): void {
    this.title.setTitle("Nhập kho");
    this.Title = "Quản lý nhập kho";
    this.updateColumnDefs();
    this.getBranchData();
    this.materialList = [];
    this.addOrderDetailForm = new FormGroup({
      materialId: new FormControl(this.orderDetailValue.materialId,[Validators.required]),
      quantityRequest: new FormControl(this.orderDetailValue.quantityRequest,[Validators.required, Validators.min(0)]),
    });
     
    this.addOrderForm = new FormGroup({
      branchRequestId: new FormControl(this.order.branchRequestId,[Validators.required]),
      supplierId: new FormControl(this.order.supplierId,[Validators.required]),
      orderDate: new FormControl(this.order.orderDate),
      supplierOrderDetail: new FormControl(this.order.supplierOrderDetail, [Validators.required]),
    });
  }
  get materialId() { return this.addOrderDetailForm.get('materialId'); }
  get quantityRequest() { return this.addOrderDetailForm.get('quantityRequest'); }


  get branchRequestId() { return this.addOrderForm.get('branchRequestId'); }
  get supplierId() { return this.addOrderForm.get('supplierId'); }
  get supplierOrderDetail() { return this.addOrderForm.get('supplierOrderDetail'); }
  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: 'materialCategory', headerName: "LÔ HÀNG", width:240, initialPinned: 'left' },
      { field: "code", headerName:"MÃ SẢN PHẨM",cellStyle: {fontWeight: '500'}}, 
      { field: 'name', headerName: "TÊN SẢN PHẨM", width: 300,  cellStyle: {fontWeight: '500'},resizable:true },
      { field: 'costPrice', headerName: "GIÁ NHẬP", width: 180, cellRendererFramework: CurrencyComponent,},
      { field: 'quantityRequest', headerName: "SỐ LƯỢNG", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'materialCategory', headerName: "NHÓM SẢN PHẨM", width:240 },
    ];
  }
  changeBranchValue(branchId: any){
    this.branchId = branchId;
    if(branchId != undefined){
      this.getOrderData(branchId);
      this.getWarehouseData(branchId);  
      this.getUserData(branchId);
      this.getShipmentData(branchId);
      this.addOrderForm.patchValue({branchRequestId: branchId != 'null' ? branchId : null});
      document.getElementById("branchRequestId")?.focus();
    }
  }
  changeOrderValue(orderId:any){
    this.materialList = [];
    this.orderId = orderId;
    if(orderId != undefined){
      this.getMaterialData(orderId);
    }
  }
  changeOrderDetailValue(){
    this.addOrderForm.patchValue({supplierOrderDetail: this.dataRow });
    document.getElementById("supplierOrderDetail")?.focus();
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
  getMaterialData(orderId:string){
    var tempData: { id: string; text: string; }[] = [];
    this.orderService.getAllMaterialOrderByOrderId(orderId).subscribe(response => {
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
  getShipmentData(branchId:string){
    var tempData: { id: string; text: string; }[] = [];
    this.shipmentService.getAllShipmentsByBranchId(branchId).subscribe(response => {
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
 
  changMaterialValue(materialId:any){
    this.quantity = '';
    if(materialId == undefined)
      return;
    this.orderService.getQuantityRequest(this.orderId, materialId).subscribe(
      response => {
        this.quantity = response;
      }
    )
    this.addOrderDetailForm.patchValue({materialId: materialId != 'null' ? materialId : null});
      document.getElementById("materialId")?.focus();
  }
  addOrderDetail(){
    var materialAlreadyExists = false;
    var dataRowTemp: any[]= [];
    this.numericalOrder ++;
    var materialId = this.addOrderDetailForm.value.materialId;
    var quantityRequest = this.addOrderDetailForm.value.quantityRequest;
   
    this.materialService.getMaterialById(materialId).subscribe(
      response => {
        var data = {
          "materialId":response.id,
          "code": response.code, 
          "name": response.name, 
          "costPrice": response.costPrice,
          "baseMaterialUnit": response.baseMaterialUnit,
          "materialCategory": response.categoryMaterial.name,
          "quantityRequest": quantityRequest
        }
        this.dataRow.forEach(item => {
          if(item.code == response.code){
              materialAlreadyExists = true;
          }
        })
        if(materialAlreadyExists){
          Swal.fire({
            title: 'Sản phẩm đã có trong đơn đặt hàng',
            text: "Bạn có muốn cập nhật số lượng",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Cập nhật',
            cancelButtonText: 'Hủy bỏ'
          }).then((result) => {
            if (result.isConfirmed) {    
              var index = this.dataRow.findIndex((item => item.code == response.code));
              this.dataRow[index].quantityRequest += quantityRequest;
              dataRowTemp.push(...this.dataRow);
              this.dataRow = dataRowTemp;
              this.addOrderDetailForm.reset();
              this.materialList = [];   
              this.totalMaterial = this.dataRow.reduce((a, b) => a + (b.quantityRequest || 0), 0);
              this.totalSale = this.dataRow.reduce((a, b) => a + (b.salePrice || 0), 0) * this.totalMaterial;
              this.changeOrderDetailValue();
            }
          })
        }
        else{
          dataRowTemp.push(...this.dataRow);
          dataRowTemp.push(data);
          this.dataRow = dataRowTemp;
          this.addOrderDetailForm.reset();
          this.materialList = [];
          this.totalMaterial = this.dataRow.reduce((a, b) => a + (b.quantityRequest || 0), 0);
          this.totalSale = this.dataRow.reduce((a, b) => a + (b.salePrice || 0), 0) * this.totalMaterial;
          this.changeOrderDetailValue();
        }  
      }
    )
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
    this.changeOrderDetailValue();
  }
  showSuccess() {  
    this.sweetalertService.alertAction("/dat-hang","Thêm đơn đặt hàng thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu", "Vui lòng kiểm tra lại", "error");
  }
  addOrder(){
    this.submitData = true;
    var dateNow = new Date(Date.now());
    this.addOrderForm.patchValue({orderDate: new Date(dateNow.getTime() + (dateNow.getTimezoneOffset() * 60000))})
    this.orderService.addOrder(this.addOrderForm.value).subscribe(
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
        this.getShipmentData(this.branchId);
      },(reason) => {
        this.getShipmentData(this.branchId);
      });
  }
}