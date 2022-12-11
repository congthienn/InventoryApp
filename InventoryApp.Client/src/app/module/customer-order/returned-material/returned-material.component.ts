import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridApi, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import Swal from 'sweetalert2';
import { CompanyService } from '../../general/company.service';
import { CurrencyComponent } from '../../material/material-list/currency/currency.component';
import { Material } from '../../material/model/material';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { CustomerOrder } from '../model/customer-order';
import { CustomerOrderDetail } from '../model/customer-order-detail';
import { ReturnedMaterial } from '../model/returned-material';
import { ReturnedMaterialDetail } from '../model/returned-material-detail';
import { CustomerOrderService } from '../service/customer-order.service';

@Component({
  selector: 'app-returned-material',
  templateUrl: './returned-material.component.html',
  styleUrls: ['./returned-material.component.css']
})
export class ReturnedMaterialComponent implements OnInit {
  @Input() id:any;
  public loadData = false;
  public company:any;
  public dateOrder:any;
  public needToPay = 0;
  public paidString = '';
  public paidStatus = ''
  public order!:CustomerOrder;
  addReturnedMaterialDetailForm!:FormGroup;
  addReturnedMaterialForm!:FormGroup;
  returnMaterialDetail: ReturnedMaterialDetail;
  materialList!:Array<Select2OptionData>;
  returnMaterial: ReturnedMaterial;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  public sizePagination = 10;
  public defaultColDef: ColDef = {
    width:160,
    filter: true,
    sortable: true,
    floatingFilter: true,
  };
  orderDetail : CustomerOrderDetail[] = [];
  public rowSelection: 'single' | 'multiple' = 'multiple';
  gridOptions: GridOptions = {
    pagination: true,
    cacheBlockSize: 10,
    paginationPageSize: 10
  };
  public reason!:string;
  modules = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],
      ['blockquote'],
      [{ 'list': 'ordered' }, { 'list': 'bullet' }],
      [{ 'script': 'sub' }, { 'script': 'super' }],
      [{ 'indent': '-1' }, { 'indent': '+1' }],
      [{ 'direction': 'rtl' }],
      [{ 'size': ['small', false, 'large', 'huge'] }],
      [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
      [{ 'color': []}, { 'background': []}],
      [{ 'align': [] }],
      ['clean']
    ]
  };
  private gridApi!: GridApi;
  constructor(private companyService: CompanyService,
      private customerOrderService: CustomerOrderService,
      private sweetalertService: SweetalertService,
      public activeModal: NgbActiveModal,
    ) {
      this.returnMaterialDetail = {} as ReturnedMaterialDetail;
      this.returnMaterial = {} as ReturnedMaterial;
    }

  ngOnInit(): void {
      this.getOrder(this.id);
      this.getCompanyName();
      this.updateColumnDefs();
      this.addReturnedMaterialDetailForm = new FormGroup({
        materialId: new FormControl(this.returnMaterialDetail.materialId,[Validators.required]),
        quantity: new FormControl(this.returnMaterialDetail.quantity,[Validators.required, Validators.min(1)]),
        quantityInOrder: new FormControl(this.returnMaterialDetail.quantityInOrder,[Validators.required, Validators.min(1)]),
      });

      this.addReturnedMaterialForm = new FormGroup({
        orderId: new FormControl(this.returnMaterial.orderId),
        reason: new FormControl(this.returnMaterial.reason,[Validators.required]),
        formula: new FormControl(this.returnMaterial.formula,[Validators.required]),
        detail: new FormControl(this.returnMaterial.detail,[Validators.required]),
      });
  }
  changeMaterialValue(materialId:any){
      this.addReturnedMaterialDetailForm.patchValue({materialId:materialId});
      var quantityInOrder = this.orderDetail.filter(x=>x.materialId == materialId)[0].quantityRequest;
      this.addReturnedMaterialDetailForm.patchValue({quantityInOrder:quantityInOrder});
  }
  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: "code", headerName:"MÃ SẢN PHẨM",cellStyle: {fontWeight: '500'}},
      { field: 'name', headerName: "TÊN SẢN PHẨM", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left',resizable:true },
      { field: 'price', headerName: "GIÁ BÁN", width:200, cellRendererFramework: CurrencyComponent,},
      { field: 'quantity', headerName: "SỐ LƯỢNG TRẢ", width:180, cellStyle: {textAlign: 'center'} },
    ];
  }
  onGridReady(params: GridReadyEvent) {
    this.gridApi = params.api;
  }
  getCompanyName(){
    this.companyService.getCompanyInfomation().subscribe(company => {
      this.company = company;
    })
  }
  changeReason(){
    this.addReturnedMaterialForm.patchValue({reason: this.reason});
  }

  changeReturnedMaterialDetail(){ 
    this.addReturnedMaterialForm.patchValue({detail: this.dataRow});
  }

  getOrder(id:string){
    this.loadData = true;
    var tempData: { id: string; text: string; }[] = [];
    this.customerOrderService.getCustomerOrderByCode(id).subscribe(response =>{
      this.order = response;
      let date = new Date(this.order.orderDate);
      this.dateOrder = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
      this.orderDetail = this.order.orderDetail;
      this.order.orderDetail.forEach(item => {
          item.priceTotalItem = Number(item.materialPrice) * Number(item.quantityRequest);
          var data = {
            id: item.materialId,
            text: item.material.name
          }
          tempData.push(data);
      })
      this.materialList = tempData;
      this.loadData = false;
      this.needToPay = Number(this.order.priceTotal) - Number(this.order.prepayment);
      this.paidString = this.order.paid ? "Đã thanh toán đủ" : "Chưa thanh toán đủ";
      this.paidStatus = this.order.paid ? "ĐÃ THANH TOÁN" : "CẦN THANH TOÁN";
    })
  }
  addReturnedMaterialDetail(){
    var dataRowTemp: any[]= [];
    var quantity = this.addReturnedMaterialDetailForm.value.quantity;
    var quantityInOrder = this.addReturnedMaterialDetailForm.value.quantityInOrder;
    var materialId = this.addReturnedMaterialDetailForm.value.materialId;
    var orderDetailItem : CustomerOrderDetail = this.orderDetail.filter(x=>x.materialId == materialId)[0];
    if(quantity > quantityInOrder){
      this.sweetalertService.alertMini("Không thể thêm sản phẩm trả lại", "Số lượng sản phẩm không hợp lệ", "error", 450);
      return;
    }
    var data = {
      "code": orderDetailItem.material.code,
      "name": orderDetailItem.material.name,
      "price": orderDetailItem.materialPrice,
      "quantity": quantity,
      "materialId": materialId
    }
    dataRowTemp.push(...this.dataRow);
    dataRowTemp.push(data);
    this.dataRow = dataRowTemp;
    this.addReturnedMaterialDetailForm.reset();
    this.materialList = this.materialList.filter(x=>x.id != materialId);
    this.changeReturnedMaterialDetail();
  }
  onRemoveSelected() {
    const selectedData = this.gridApi.getSelectedRows();
    if(selectedData.length == 0){
      this.sweetalertService.alertMini("Chọn sản phẩm cần xóa","", "info");
      return;
    }
    this.gridApi.applyTransaction({ remove: selectedData })!;
    for(var i = 0; i < selectedData.length; i++){
      const index = this.dataRow.indexOf(selectedData[i]);
      this.dataRow.splice(index, 1);
      var material: Material = this.orderDetail.filter(x=>x.material.code == selectedData[i].code)[0].material;
      var dataTemp: any[]= [];
      var data = {
        id: material.id,
        text: material.name
      }
      dataTemp.push(...this.materialList);
      dataTemp.push(data);
      this.materialList = dataTemp;   
    }
    this.changeReturnedMaterialDetail();
  }

  showSuccess() {  
    this.sweetalertService.alertAction("/don-hang","Thêm phiếu trả hàng thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu", "Vui lòng kiểm tra lại", "error");
  }
  addReturnedMaterial(){
    this.addReturnedMaterialForm.patchValue({orderId: this.order.id});
    this.customerOrderService.addReturnMaterial(this.addReturnedMaterialForm.value).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: "Thêm phiếu trả hàng thành công",
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
            this.activeModal.close();
        })
      },
      error => {
        this.showError();
      }
    );
  }
}