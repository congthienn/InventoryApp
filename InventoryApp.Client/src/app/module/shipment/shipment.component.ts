import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../branch/branch.service';
import { ButtonShipmentStatusComponent } from './button-shipment-status/button-shipment-status.component';
import { MaterialShipment } from './model/material-shipment';
import { ShipmentService } from './service/shipment.service';

@Component({
  selector: 'app-shipment',
  templateUrl: './shipment.component.html',
  styleUrls: ['./shipment.component.css']
})
export class ShipmentComponent implements OnInit {
  dataRow: any[] = [];
  columnDefs : any[]= [];
  branchList!: Array<Select2OptionData>;
  materialShipment: MaterialShipment[]= [];
  public rowSelection: 'single' | 'single' = 'single';
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/lo-hang/',
      title: 'Lô hàng',
      active: false
    }
  ]
  loadData = true;
  public Title = '';
  public sizePagination = 10;
  public defaultColDef: ColDef = {
    width: 200,
    filter: true,
    sortable: true,
    floatingFilter: true,
  };

  gridOptions: GridOptions = {
    pagination: true,
    cacheBlockSize: 10,
    paginationPageSize: 10
  };
  constructor(private title: Title,
    private shipmentService: ShipmentService,
    private branchService: BranchService,
    private authService: AuthService
    ) { }

  ngOnInit(): void {
    this.title.setTitle("Lô hàng");
    this.Title = "Quản lý lô hàng";
    this.updateColumnDefs();
    this.getBranchData();
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
    this.getAllShipment(branchId);
  }
  public getAllShipment(branchId:any){
    document.body.style.overflow = 'hidden';
    this.shipmentService.GetAllShipmentHasProductByBranchId(branchId).subscribe(
      response =>{
        console.log(response)
        this.materialShipment = response;
        var dataRowTemp: any[]= [];
        this.materialShipment.forEach(element => {
          var date = new Date(element.shipment.expirationDate);
          var data = {
              "code":element.shipment.code,
              "material": element.material.name, 
              "branch": element.shipment.branch.companyName, 
              "materialQuantity": element.materialQuantity,
              "quantityInStock": element.quantityInStock,
              "baseMaterialUnit":element.material.baseMaterialUnit,
              "status":element.quantityInStock,
              "expirationDate": `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
            }
            dataRowTemp.push(data);
        });
        this.dataRow = dataRowTemp;
        console.log(dataRowTemp)
        this.loadData = false;
        document.body.style.overflow = '';
      },
      error => {
        this.loadData = true;
      })
  }
  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: "code", headerName:"MÃ LÔ HÀNG", width:300, cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true},
      { field: "status", headerName:"TRẠNG THÁI", width:150, cellRenderer: ButtonShipmentStatusComponent}, 
      { field: 'material', headerName: "SẢN PHẨM", resizable:true, width:300},
      { field: 'branch', headerName: "CHI NHÁNH", width:300,  cellStyle: {fontWeight: '500'}, resizable:true },
      { field: 'materialQuantity', headerName: "SỐ LƯỢNG NHẬP KHO", cellStyle: {textAlign  : 'center'}},
      { field: 'quantityInStock', headerName: "SỐ LƯỢNG TRONG KHO" , cellStyle: {textAlign  : 'center'}},
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN", cellStyle: {textAlign  : 'center'}},
      { field: 'expirationDate', headerName: "NGÀY HẾT HẠN" },
    ];
  }
  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
}
