import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions, ICellRendererParams } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { SupplierService } from '../service/supplier.service';
import { Supplier } from '../model/supplier';
import { ActionButtonComponent } from './action-button/action-button.component';

@Component({
  selector: 'app-supplier-list',
  templateUrl: './supplier-list.component.html',
  styleUrls: ['./supplier-list.component.css']
})
export class SupplierListComponent implements OnInit {
  public Title = '';
  public loadData = true;
  public sizePagination = 10;
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/nha-cung-cap/',
      title: 'Nhà cung cấp',
      active: true
    }
  ]
  constructor(private title: Title, private supplierService: SupplierService) { }
   supplier: Supplier[] = [];
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
      this.title.setTitle("Nhà cung cấp");
      this.Title = "Quản lý nhà cung cấp";
      this.updateColumnDefs();
      this.getAllSupplier();
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
        { field: "code", headerName:"MÃ NCC", cellStyle: {fontWeight: '500'}}, 
        { field: 'supplierName', headerName: "NHÀ CUNG CẤP", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true },
        { field: 'phoneNumber', headerName: "SỐ ĐIỆN THOẠI"},
        { field: 'supplierGroup', headerName: "NHÓM NHÀ CUNG CẤP", width:250, resizable:true},
        { field: 'email', headerName: "EMAIL", width:250},
        { field: 'fax', headerName: "SỐ FAX"},
        { field: 'taxCode', headerName: "MÃ SỐ THUẾ"},
        { field: 'address', headerName: "ĐỊA CHỈ", resizable:true,  width: 500},
        { field: 'status', headerName: "TRẠNG THÁI", resizable:true, cellRenderer: fragRenderer},      
      ];
    }
    public getAllSupplier(){
      document.body.style.overflow = 'hidden';
      this.supplierService.getSupplierData().subscribe(
        response =>{
          this.supplier = response;
          console.log(response);
          var dataRowTemp: any[]= [];
          this.supplier.forEach(element => {
              var data = {
                "id": element.id,
                "code": element.code, 
                "supplierName": element.supplierName, 
                "phoneNumber": element.phoneNumber,
                "supplierGroup": element.supplierGroup.name,
                "email": element.email,
                "fax": element.fax,
                "taxCode": element.taxCode,
                "address":`${element.address}, ${element.ward.name}, ${element.district.name}, ${element.province.name}`,
                "status": element.status ? "Đang hợp tác": "Ngừng hợp tác"
              }
              dataRowTemp.push(data);
          });
          this.dataRow = dataRowTemp;
          this.loadData = false;
          document.body.style.overflow = '';
      },error => {
        this.loadData = true;
      })
    }
    onPageSizeChanged() {
      var text = (<HTMLInputElement>document.getElementById('page-size')).value;
      this.sizePagination = Number(text);
    }
    refreshData(){
      this.getAllSupplier();
    }
}
function fragRenderer(params: ICellRendererParams) {
  const statusClass = params.value ? "btn-success" : "btn-secondary";
  return `<button type="button" class="btn ${statusClass} btn-sm-custom">${params.value}</button>`;
}
