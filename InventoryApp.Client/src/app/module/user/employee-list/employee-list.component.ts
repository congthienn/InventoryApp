import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { BtnCellRenderer } from '../../share/ag-grid-button/ag-grid-button.component';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { Employee } from '../model/employee';
import { EmployeeService } from '../service/employee.service';
import { ActionButtonComponent } from './action-button/action-button.component';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  public Title = '';
  public loadData = true;
  branchList!: Array<Select2OptionData>;
  branchId!: string;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  employeeData: Employee[] = [];
  public rowSelection: 'single' | 'single' = 'single';
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/nhan-vien/',
      title: 'Nhân viên',
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

  constructor(private employeeService: EmployeeService, 
    private title: Title, 
    public sweetalertService: SweetalertService,
    private branchService: BranchService,
    private authService: AuthService
    ) {}

  ngOnInit(): void {
    this.title.setTitle("Nhân viên");
    this.Title = "Quản lý thông tin nhân viên";
    this.updateColumnDefs();
    this.getBranchData();
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
      { field: "code", headerName:"MÃ NHÂN VIÊN",cellStyle: {fontWeight: '500'}}, 
      { field: 'name', headerName: "HỌ VÀ TÊN", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true },
      { field: 'phoneNumber', headerName: "SỐ ĐIỆN THOẠI"},
      { field: 'identityCard', headerName: "CCCD / CMND"},
      { field: 'email', headerName: "EMAIL", width:250},
      { field: 'sex', headerName: "GIỚI TÍNH"},
      { field: 'branch', headerName: "CHI NHÁNH", width:250},
      { field: 'address', headerName: "ĐỊA CHỈ", resizable:true,  width: 500}, 
      { field: 'status', headerName: "TRẠNG THÁI", width: 150, cellRenderer: ButtonUpdateStatusComponent},  
    ];
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
    this.getAllEmployee();
  }
  getAllEmployee(){ 
    document.body.style.overflow = 'hidden';
    this.employeeService.getEmployeeByBranchId(this.branchId).subscribe(
      response =>{
        this.employeeData = response;
        console.log(response)
        var dataRowTemp: any[]= [];
        this.employeeData.forEach(element => {
          var data = {
              "id":element.id,
              "code": element.code, 
              "name": element.name,
              "branch": element.branch.companyName, 
              "phoneNumber": element.phoneNumber,
              "email": element.email,
              "identityCard":element.identityCard,
              "sex": element.sex ? "Nam" : "Nữ",
              "address":`${element.address}, ${element.ward.name}, ${element.district.name}, ${element.province.name}`,
              "status":element.id
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

  }
}
