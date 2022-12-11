import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { BranchService } from 'src/app/module/branch/branch.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { DeliveryCompany } from '../model/delivery-company';
import { DeliveryCompanyService } from '../service/delivery-company.service';
import { ActionButtonComponent } from './action-button/action-button.component';

@Component({
  selector: 'app-delivery-company-list',
  templateUrl: './delivery-company-list.component.html',
  styleUrls: ['./delivery-company-list.component.css']
})
export class DeliveryCompanyListComponent implements OnInit {
  branchList! : Array<Select2OptionData>;
  public Title = '';
  public loadData = true;
  public sizePagination = 10;
  public rowSelection: 'single' | 'single' = 'single';
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/don-vi-giao-hang/',
      title: 'Đơn vị giao hàng',
      active: true
    }
  ]
  constructor(private title:Title, 
    private deliveryCompanyService: DeliveryCompanyService,
    private authService: AuthService, private branchService : BranchService) { }
  enableButton = this.authService.getRole() === "Quản trị hệ thống";
    deliveryCompany: DeliveryCompany[] = [];
   branchId!:string;
    dataRow: any[] = [];
    columnDefs : any[]= [];
    public defaultColDef: ColDef = {
      width:150,
      filter: true,
      sortable: true,
      floatingFilter: true,
    };
    gridOptions: GridOptions = {
      pagination: true,
      cacheBlockSize: 10,
      paginationPageSize: 10
    };
   
    ngOnInit(): void {
      this.title.setTitle("Đơn vị giao hàng");
      this.Title = "Quản lý đơn vị giao hàng";
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
        this.branchId = branchId;
      this.getAllCustomer();
    }
    private updateColumnDefs() {
      this.columnDefs  =  [
        { field: 'id',  
          width: 100,
          headerName: "",
          suppressFilter: false,
          filter: false,
          cellStyle: {textAlign  : 'left'},
          initialPinned: 'left',
          cellRenderer: ActionButtonComponent,
        }, 
        { field: "code", headerName:"MÃ ĐƠN VỊ", cellStyle: {fontWeight: '500'}}, 
        { field: 'customerName', headerName: "ĐƠN VỊ GIAO HÀNG", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true },
        { field: 'phoneNumber', headerName: "SỐ ĐIỆN THOẠI"},  
        { field: 'email', headerName: "EMAIL", width:250},
        { field: 'fax', headerName: "SỐ FAX"},
        { field: 'taxCode', headerName: "MÃ SỐ THUẾ"},
        { field: 'address', headerName: "ĐỊA CHỈ", resizable:true,  width: 500}, 
        { field: 'branch', headerName: "CHI NHÁNH", resizable:true ,width: 200},      
      ];
    }
    public getAllCustomer(){
      document.body.style.overflow = 'hidden';
      this.deliveryCompanyService.getAllDeliveryCompanyDataByBranchId(this.branchId).subscribe(
        response =>{
        this.deliveryCompany = response;
        var dataRowTemp: any[]= [];
        this.deliveryCompany.forEach(element => {
          var data = {
              "id":element.id,
              "code": element.code, 
              "customerName": element.name, 
              "phoneNumber": element.phoneNumber,
              "branch": element.branch.companyName,
              "email": element.email,
              "fax": element.fax,
              "taxCode": element.taxCode,
              "address":`${element.address}, ${element.ward.name}, ${element.district.name}, ${element.province.name}`
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
    onPageSizeChanged() {
      var text = (<HTMLInputElement>document.getElementById('page-size')).value;
      this.sizePagination = Number(text);
    }
    refreshData(){
      this.getBranchData();
    }
}