import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ColDef, GridApi, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import Swal from 'sweetalert2';
import { BranchService } from '../../branch/branch.service';
import { CustomerService } from '../../business-partner/customer/service/customer.service';
import { CategoryMaterialService } from '../../category-material/service/category-material.service';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { Material } from '../../material/model/material';
import { MaterialService } from '../../material/service/material.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { CustomerOrder } from '../model/customer-order';
import { CustomerOrderDetail } from '../model/customer-order-detail';
import { CustomerOrderService } from '../service/customer-order.service';

@Component({
  selector: 'app-add-customer-order',
  templateUrl: './add-customer-order.component.html',
  styleUrls: ['./add-customer-order.component.css']
})
export class AddCustomerOrderComponent implements OnInit {
  public Title = '';
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
    },
    {
      path: '/dat-hang/them-moi',
      title: 'Thêm mới',
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
  supplierList!: Array<Select2OptionData>;
  categoryList!:Array<Select2OptionData>;
  materialList!:Array<Select2OptionData>;
  addOrderDetailForm!:FormGroup;
  addOrderForm!:FormGroup;
  orderDetailValue: CustomerOrderDetail;
  order:CustomerOrder;
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
  constructor(public title: Title, private branchService: BranchService, 
    private customerService: CustomerService, private materialCategoryService: CategoryMaterialService,
    private materialService: MaterialService,
    private sweetalertService : SweetalertService,
    private CustomerOrderService: CustomerOrderService
    ) { 
    this.orderDetailValue = {} as CustomerOrderDetail;
    this.order = {} as CustomerOrder;
  }
  ngOnInit(): void {
    this.title.setTitle("Đơn hàng");
    this.Title = "Quản lý đơn hàng";
    this.updateColumnDefs();
    this.getBranchData();
    this.getCustomerData();
    this.getMaterialCategory();
    this.addOrderDetailForm = new FormGroup({
      materialId: new FormControl(this.orderDetailValue.materialId,[Validators.required]),
      quantityRequest: new FormControl(this.orderDetailValue.quantityRequest,[Validators.required, Validators.min(0)]),
    });
     
    this.addOrderForm = new FormGroup({
      branchId: new FormControl(this.order.branchId,[Validators.required]),
      customerId: new FormControl(this.order.customer,[Validators.required]),
      orderDate: new FormControl(this.order.orderDate),
      orderDetail: new FormControl(this.order.orderDetail, [Validators.required]),
    });
  }
  get materialId() { return this.addOrderDetailForm.get('materialId'); }
  get quantityRequest() { return this.addOrderDetailForm.get('quantityRequest'); }


  get branchId() { return this.addOrderForm.get('branchId'); }
  get customerId() { return this.addOrderForm.get('customerId'); }
  get orderDetail() { return this.addOrderForm.get('orderDetail'); }
  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: "code", headerName:"MÃ SẢN PHẨM",cellStyle: {fontWeight: '500'}}, 
      { field: 'name', headerName: "TÊN SẢN PHẨM", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left',resizable:true },
      { field: 'salePrice', headerName: "GIÁ BÁN", width:180, cellRendererFramework: CurrencyComponent,},
      { field: 'quantityRequest', headerName: "SỐ LƯỢNG YÊU CẦU", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN", width:180, cellStyle: {textAlign: 'center'} },
      { field: 'materialCategory', headerName: "NHÓM SẢN PHẨM", width:240 },
    ];
  }
  changeBranchValue(data: any){
    if(data != undefined){
      this.addOrderForm.patchValue({branchId: data != 'null' ? data : null});
      document.getElementById("branchId")?.focus();
    }
  }
  changeSupplierValue(data: any){
    if(data != undefined){
      this.addOrderForm.patchValue({customerId: data != 'null' ? data : null});
      document.getElementById("customerId")?.focus();
    }
  }
  changeOrderDetailValue(){
    this.addOrderForm.patchValue({orderDetail: this.dataRow });
    document.getElementById("orderDetail")?.focus();
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
  getCustomerData(){
    var tempData: { id: string; text: string; }[] = [];
    this.customerService.getAllCustomerData().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.customerName
        }
        tempData.push(data);
      });
      this.supplierList = tempData;
    })
  }
  getMaterialCategory(){
    var tempData: { id: string; text: string; }[] = [];
    this.materialCategoryService.getAllCategoryMaterial().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.categoryList = tempData;
    })
  }
  refreshBranchData(){
    this.getBranchData();
  }
  refreshCustomerData(){
    this.getCustomerData();
  }
  refreshCategoryData(){
    this.getMaterialCategory();
  }
  changCategoryValue(data:any){
    if(data == undefined){
      return;
    }
    var tempData: { id: string; text: string; }[] = [];
    this.materialCategoryService.getAllMaterialByCategoryId(data).subscribe(response => {
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
  changMaterialValue(data:any){
    this.addOrderDetailForm.patchValue({materialId: data != 'null' ? data : null});
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
          "salePrice": response.salePrice,
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
              this.categoryList = [];
              this.getMaterialCategory();
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
          this.categoryList = [];
          this.getMaterialCategory();
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
    this.sweetalertService.alertAction("/don-hang","Thêm đơn đặt hàng thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu", "Vui lòng kiểm tra lại", "error");
  }
  addOrder(){
    this.submitData = true;
    var dateNow = new Date(Date.now());
    this.addOrderForm.patchValue({orderDate: new Date(dateNow.getTime() + (dateNow.getTimezoneOffset() * 60000))})
    this.CustomerOrderService.addCustomerOrder(this.addOrderForm.value).subscribe(
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
