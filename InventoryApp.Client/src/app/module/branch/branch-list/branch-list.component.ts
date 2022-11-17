import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import Swal from 'sweetalert2';
import { BtnCellRenderer } from '../../share/ag-grid-button/ag-grid-button.component';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { BranchService } from '../branch.service';
import { Branch } from '../model/branch';


@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.css']
})

export class BranchListComponent implements OnInit {
  public Title = '';
  public loadData = true;
  dataRow: any[] = [];
  columnDefs : any[]= [];
  branchData: Branch[] = [];
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/chi-nhanh/',
      title: 'Chi nhánh',
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

  constructor(private branchService: BranchService, private title: Title, public sweetalertService: SweetalertService) {}

  ngOnInit(): void {
    this.title.setTitle("Chi nhánh");
    this.Title = "Quản lý chi nhánh";
    this.updateColumnDefs();
    this.getAllBranch();
  }
  public getAllBranch(){
    document.body.style.overflow = 'hidden';
    this.branchService.getAllBranch().subscribe(
      response =>{
        this.branchData = response;
        var dataRowTemp: any[]= [];
        this.branchData.forEach(element => {
          var data = {
              "id":element.id,
              "code": element.code, 
              "companyName": element.companyName, 
              "phoneNumber": element.phoneNumber,
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

  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        cellRenderer: BtnCellRenderer,
      }, 
      { field: "code", headerName:"MÃ CHI NHÁNH",cellStyle: {fontWeight: '500'}}, 
      { field: 'companyName', headerName: "CHI NHÁNH", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left',resizable:true },
      { field: 'phoneNumber', headerName: "SỐ ĐIỆN THOẠI"},
      { field: 'email', headerName: "EMAIL", width:250},
      { field: 'taxCode', headerName: "MÃ SỐ THUẾ"},
      { field: 'fax', headerName: "SỐ FAX"},
      { field: 'address', headerName: "ĐỊA CHỈ", resizable:true,  width: 500},  
    ];
  }

  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
}
