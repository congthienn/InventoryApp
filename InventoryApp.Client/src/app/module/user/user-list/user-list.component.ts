import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { Branch } from '../../branch/model/branch';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { AddUserComponent } from '../add-user/add-user.component';
import { User } from '../model/user';
import { UserService } from '../service/user.service';
import { ActionButtonComponent } from './action-button/action-button.component';
import { ButtonUpdateStatusComponent } from './button-update-status/button-update-status.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  public Title = '';
  public loadData = true;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  public rowSelection: 'single' | 'single' = 'single';
  user: User[] = [];
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/tai-khoan/',
      title: 'Tài khoản',
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

  constructor(private userService: UserService, private title: Title, 
    public sweetalertService: SweetalertService,
    private modalService: NgbModal
    ) {}

  ngOnInit(): void {
    this.title.setTitle("Tài khoản");
    this.Title = "Quản lý tài khoản";
    this.updateColumnDefs();
    this.getAllUser();
  }
  public getAllUser(){
    document.body.style.overflow = 'hidden';
    this.userService.getAllUser().subscribe(
      response =>{
        this.user = response;
        var dataRowTemp: any[]= [];
        this.user.forEach(element => {
          var data = {
              "id": element.id,
              "userName": element.userName,
              "email": element.email,
              "phoneNumber": element.phoneNumber,
              "status": element.id,
              "role": element.role?.name,
              "branch": this.getBranchList(element.branch)
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

  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: 'id',  
        width: 65,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: ActionButtonComponent,
      }, 
      { field: 'status', headerName: "TRẠNG THÁI", width: 150, initialPinned: 'left', cellRenderer: ButtonUpdateStatusComponent}, 
      { field: "userName", headerName:"TÊN TÀI KHOẢN",width: 210 ,cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true }, 
      { field: 'email', headerName: "EMAIL", width:250,  cellStyle: {fontWeight: '500'}, resizable:true },
      { field: 'phoneNumber', headerName: "SỐ ĐIỆN THOẠI"},
      { field: 'branch', headerName: "CHI NHÁNH", width: 250, resizable:true}, 
      { field: 'role', headerName: "VAI TRÒ", width: 200}, 
    
    ];
  }
  private getBranchList(data: Branch[]): string{
    var branchName = '';
    for(var i = 0; i < data.length; i++){
      branchName = branchName.concat(i== 0 ? "" : " - " , data[i].companyName);
    }
    return branchName;
  }
  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
  refreshData(){
    this.getAllUser();
  }
  openModalAddUser(){
    const modalRef = this.modalService.open(AddUserComponent).result.then((result) => {
      this.getAllUser();
    },(reason) => {
      this.getAllUser();
    });
  }
}
