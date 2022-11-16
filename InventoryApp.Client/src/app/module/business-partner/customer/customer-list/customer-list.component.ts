import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { CustomerService } from '../service/customer.service';
import { Customer } from '../model/customer';
import { ActionButtonComponent } from './action-button/action-button.component';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  public Title = '';
  public sizePagination = 10;
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/khach-hang/',
      title: 'Khách hàng',
      active: true
    }
  ]
  constructor(private title:Title, private customerService: CustomerService) { }
   customer: Customer[] = [];
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
      this.title.setTitle("Khách hàng");
      this.Title = "Quản lý khách hàng";
      this.customerService.getAllCustomerData().subscribe(response => {
        console.log(response);
      })
      this.updateColumnDefs();
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
        { field: "code", headerName:"MÃ KH", cellStyle: {fontWeight: '500'}}, 
        { field: 'customerName', headerName: "KHÁCH HÀNG", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true },
        { field: 'phoneNumber', headerName: "SỐ ĐIỆN THOẠI"},
        { field: 'branch', headerName: "CHI NHÁNH", resizable:true },
        { field: 'customerGroup', headerName: "NHÓM KHÁCH HÀNG", width:250, resizable:true},
        { field: 'email', headerName: "EMAIL", width:250},
        { field: 'fax', headerName: "SỐ FAX"},
        { field: 'taxCode', headerName: "MÃ SỐ THUẾ"},
        { field: 'address', headerName: "ĐỊA CHỈ", resizable:true,  width: 500},       
      ];
    }
    public getAllCustomer(){
      this.customerService.getAllCustomerData().subscribe(response =>{
        this.customer = response;
        var dataRowTemp: any[]= [];
        this.customer.forEach(element => {
          var data = {
              "id":element.id,
              "code": element.code, 
              "customerName": element.customerName, 
              "phoneNumber": element.phoneNumber,
              "branch": element.branch.companyName,
              "customerGroup": element.customerGroup.name,
              "email": element.email,
              "fax": element.fax,
              "taxCode": element.taxCode,
              "address":`${element.address}, ${element.ward.name}, ${element.district.name}, ${element.province.name}`
            }
            dataRowTemp.push(data);
        });
        this.dataRow = dataRowTemp;
      })
    }
    onPageSizeChanged() {
      var text = (<HTMLInputElement>document.getElementById('page-size')).value;
      this.sizePagination = Number(text);
    }
}
