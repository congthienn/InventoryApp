import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ColDef, GridApi, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import Swal from 'sweetalert2';
import { BranchService } from '../../branch/branch.service';
import { CustomerService } from '../../business-partner/customer/service/customer.service';
import { CategoryMaterialService } from '../../category-material/service/category-material.service';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { Material } from '../../material/model/material';
import { MaterialService } from '../../material/service/material.service';
import { ProvinceService } from '../../province/province.service';
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
  provinceList!: Array<Select2OptionData>;
  districtList!: Array<Select2OptionData>;
  wardList!: Array<Select2OptionData>;
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
    private CustomerOrderService: CustomerOrderService,
    private provinceService: ProvinceService,
    private authService: AuthService
    ) { 
    this.orderDetailValue = {} as CustomerOrderDetail;
    this.order = {} as CustomerOrder;
  }
  ngOnInit(): void {
    this.title.setTitle("Đơn hàng");
    this.Title = "Quản lý đơn hàng";
    this.updateColumnDefs();
    this.getBranchData();
    this.getMaterialCategory();
    this.getProvinceList();
    this.addOrderDetailForm = new FormGroup({
      materialId: new FormControl(this.orderDetailValue.materialId,[Validators.required]),
      quantityRequest: new FormControl(this.orderDetailValue.quantityRequest,[Validators.required, Validators.min(1)]),
    });
     
    this.addOrderForm = new FormGroup({
      branchId: new FormControl(this.order.branchId,[Validators.required]),
      customerId: new FormControl(this.order.customer,[Validators.required]),
      prepayment: new FormControl(this.order.prepayment,[Validators.required]),
      paid: new FormControl(this.order.paid,[Validators.required]),
      orderDate: new FormControl(this.order.orderDate),
      orderDetail: new FormControl(this.order.orderDetail, [Validators.required]),
      provinceId: new FormControl(this.order.provinceId, Validators.required),
      districtId: new FormControl(this.order.districtId, Validators.required),
      wardId: new FormControl(this.order.wardId, Validators.required),
      address: new FormControl(this.order.address, Validators.required),
      deliveryAddress: new FormControl(this.order.address)
    });
  }
  get materialId() { return this.addOrderDetailForm.get('materialId'); }
  get quantityRequest() { return this.addOrderDetailForm.get('quantityRequest'); }


  get branchId() { return this.addOrderForm.get('branchId'); }
  get customerId() { return this.addOrderForm.get('customerId'); }
  get prepayment() { return this.addOrderForm.get('prepayment'); }
  get paid() { return this.addOrderForm.get('paid'); }
  get orderDetail() { return this.addOrderForm.get('orderDetail'); }
  get provinceId() { return this.addOrderForm.get('provinceId'); }
  get districtId() { return this.addOrderForm.get('districtId'); }
  get wardId() { return this.addOrderForm.get('wardId'); }
  get address() { return this.addOrderForm.get('address'); }
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

  public branchIdValue = '';
  changeBranchValue(branchId: any){
    if(branchId == undefined)
      return;
    this.addOrderForm.patchValue({branchId: branchId != 'null' ? branchId : null});
    document.getElementById("branchId")?.focus();
    this.branchIdValue = branchId;
    this.getCustomerData(branchId);
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
  getProvinceList(){
    this.provinceService.getProvinceList().subscribe(response => { 
        this.provinceList = response;
    })
  }
  getDistrictList(provinceId:string){
    this.provinceService.getDistrictList(provinceId).subscribe(response => {
        this.districtList = response;
    })
  }
  getWardtList(districtId:string){
    this.provinceService.getWardList(districtId).subscribe(response => {
        this.wardList = response;
    })
  }
  changeProvinceValue(data: any){
    if(data == undefined)
      return;
    this.addOrderForm.patchValue({provinceId: data != 'null' ? data : null});
    this.getDistrictList(data); 
  }
  changeDistrictValue(data: any){
    this.addOrderForm.patchValue({districtId: data != 'null' ? data : null});
    document.getElementById("district")?.focus();
    this.getWardtList(data == undefined ? "2022" : data);
  }
  changeWardValue(data: any){
    this.addOrderForm.patchValue({wardId: data != 'null' ? data : null});
    document.getElementById("ward")?.focus();
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
  getCustomerData(branchId:string){
    var tempData: { id: string; text: string; }[] = [];
    this.customerService.getAllCustomerDataByBranchId(branchId).subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: `${element.customerName} - ${element.phoneNumber}` 
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
    this.getCustomerData(this.branchIdValue);
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
  materialName = '';
  changMaterialValue(materialId:any){
    this.addOrderDetailForm.patchValue({materialId: materialId});
    document.getElementById("materialId")?.focus();
    this.materialName = this.materialList.filter(x=>x.id == materialId)[0].text;
  }
  addOrderDetail(){
    var materialAlreadyExists = false;
    var dataRowTemp: any[]= [];
    this.numericalOrder ++;
    var materialId = this.addOrderDetailForm.value.materialId;
    var quantityRequest = this.addOrderDetailForm.value.quantityRequest;
    if(this.branchIdValue == ''){
      this.sweetalertService.alertMini(`Vui lòng chọn chi nhánh nhập đơn hàng`,'Để hệ thống kiểm tra số lượng sản phẩm', "warning", 500);
        return;
    }
    this.materialService.getMaterialQuantityByMaterialIdAndBranchId(this.branchIdValue, materialId).subscribe(
      response => {
        if(Number(response) < Number(quantityRequest)){
          this.sweetalertService.alertMini(`Số lượng sản phẩm trong kho không đủ `, `${this.materialName} còn ${response} sản phẩm`, "warning", 500);
          return;
        }
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
    
    var provinceId = this.addOrderForm.get('provinceId')?.value;
    var districtId = this.addOrderForm.get('districtId')?.value;
    var wardId = this.addOrderForm.get('wardId')?.value;
    var address = this.addOrderForm.get('address')?.value;
    var provinceName = this.provinceList.filter(x=>x.id == provinceId)[0].text;
    var districtName = this.districtList.filter(x=>x.id == districtId)[0].text;
    var wardName = this.wardList.filter(x=>x.id == wardId)[0].text;
    var deliveryAddress = `${address}, ${wardName}, ${districtName}, ${provinceName}`;
    this.addOrderForm.patchValue({deliveryAddress: deliveryAddress});
    
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
