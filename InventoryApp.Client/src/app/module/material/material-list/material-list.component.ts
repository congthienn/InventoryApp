import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions, ICellRendererParams } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { Branch } from '../../branch/model/branch';
import { Material } from '../model/material';
import { MaterialService } from '../service/material.service';
import { ActionButtonMaterialComponent } from './action-button-material/action-button-material.component';
import { CurrencyComponent } from './currency/currency.component';

@Component({
  selector: 'app-material-list',
  templateUrl: './material-list.component.html',
  styleUrls: ['./material-list.component.css']
})
export class MaterialListComponent implements OnInit {
  public Title = '';
  public material: Material[] = [];
  public loadData = true;
  public deleteData = false;
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/san-pham/',
      title: 'Sản phẩm',
      active: false
    }
  ]
  dataRow: any[] = [];
  columnDefs : any[]= [];
  branchData: Branch[] = [];
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

  constructor(private title: Title, private materialService: MaterialService) { }

  ngOnInit(): void {
    this.title.setTitle("Sản phẩm");
    this.Title = "Quản lý sản phẩm";
    this.updateColumnDefs();
    this.getAllMaterial();
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
        cellRenderer: ActionButtonMaterialComponent,
      }, 
      { field: "code", headerName:"MÃ SP", cellStyle: {fontWeight: '500'}}, 
      { field: 'name', headerName: "TÊN SẢN PHẨM", width:300,  cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true },
      { field: 'costPrice', headerName: "GIÁ NHẬP KHO",  cellRendererFramework: CurrencyComponent,},
      { field: 'salePrice', headerName: "GIÁ BÁN RA", cellRendererFramework: CurrencyComponent,},
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN"},
      { field: 'categoryMaterial', headerName: "NHÓM SẢN PHẨM", width:200},
      { field: 'trademark', headerName: "THƯƠNG HIỆU"},
      { field: 'minimumInventory', headerName: "ĐỊNH MỰC TỐI THIỂU", cellStyle: {textAlign: 'center'}, width:200},
      { field: 'maximumInventory', headerName: "ĐỊNH MỨC TỐI ĐA", cellStyle: {textAlign: 'center'}, width:200},      
      { field: 'stopBusiness', headerName: "TRẠNG THÁI", cellRenderer: fragRenderer},        
    ];
  }
  public getAllMaterial(){
    document.body.style.overflow = 'hidden';
    this.materialService.getAllMaterial().subscribe(
      response => {
        this.material = response;
        var dataRowTemp: any[]= [];
        this.material.forEach(element => {
          var data = {
              "id":element.id,
              "code": element.code, 
              "name": element.name, 
              "salePrice": element.salePrice,
              "costPrice": element.costPrice,
              "baseMaterialUnit": element.baseMaterialUnit,
              "categoryMaterial": element.categoryMaterial.name,
              "trademark": element.trademark.name,
              "minimumInventory": element.minimumInventory,
              "maximumInventory":element.maximumInventory,
              "stopBusiness" : element.stopBusiness ? 'Ngừng kinh doanh' : "Đang kinh doanh"
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
    this.getAllMaterial();
  }
}
function fragRenderer(params: ICellRendererParams) {
  const statusClass = params.value ? "btn-success" : "btn-secondary";
  return `<button type="button" class="btn ${statusClass} btn-sm-custom">${params.value}</button>`;
}

