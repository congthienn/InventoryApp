import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { Material } from '../../material/model/material';
import { MaterialService } from '../../material/service/material.service';
import { MaterialShipment } from '../../shipment/model/material-shipment';
import { ButtonStatusComponent } from './button-status/button-status.component';

@Component({
  selector: 'app-product-statistics',
  templateUrl: './product-statistics.component.html',
  styleUrls: ['./product-statistics.component.css']
})
export class ProductStatisticsComponent implements OnInit {
  public Title = '';
  public loadData = true;
  branchList!: Array<Select2OptionData>;
  dataRow: any[] = [];
  material: Material[] = [];
  public rowSelection: 'single' | 'single' = 'single';
  columnDefs : any[]= [];
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/kho-hang/',
      title: 'Kho hàng',
      active: false
    },
    {
      path: '/kho-hang/thong-ke-san-pham',
      title: 'Thống kê sản phẩm',
      active: true
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

  constructor(private branchService: BranchService, private title: Title, private materialService: MaterialService) {}

  ngOnInit(): void {
    this.title.setTitle("Thống kê sản phẩm");
    this.Title = "Thống kê số lượng sản phẩm";
    this.updateColumnDefs();
    this.getAllBranch();
  }
  public getAllBranch(){
    var tempData: { id: string; text: string; }[] = [];
    this.branchService.getAllBranch().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.companyName
        }
        tempData.push(data);
      }); 
      this.branchList = tempData;
      this.loadData = false;
    })
  }

  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: "material", headerName:"SẢN PHẨM",cellStyle: {fontWeight: '500'}, initialPinned: 'left', width:250, resizable:true}, 
      { field: 'code', headerName: "MÃ SẢN PHẨM", width:180,  cellStyle: {fontWeight: '500'}, resizable:true },
      { field: 'status', headerName: "TRẠNG THÁI", width:180, cellRenderer: ButtonStatusComponent },  
      { field: 'totalQuantity', headerName: "SỐ LƯỢNG HIỆN CÓ", width:200, cellStyle: {textAlign  : 'center', fontWeight: '500'}},  
      { field: 'minimumInventory', headerName: "ĐỊNH MỨC TỐI THIỂU", width:200, cellStyle: {textAlign  : 'center'}},
      { field: 'maximumInventory', headerName: "ĐỊNH MỨC TỐI ĐA", width:200, cellStyle: {textAlign  : 'center'}},
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN", width:180, cellStyle: {textAlign  : 'center'}},  
    ];
  }

  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
  refreshData(){
    this.getAllBranch();
  }
  onChangeBranch(branchId:any) {
    if(branchId == undefined) 
      return;
    this.materialService.getAllMaterialAndQuantityByBranchId(branchId).subscribe(
      response =>{
        this.material = response;
        var dataRowTemp: any[]= [];
        this.material.forEach(element => {
          var data = {
              "material":element.name,
              "code": element.code, 
              "status": this.setStatus(Number(element.totalQuantity), Number(element.minimumInventory), Number(element.maximumInventory)),
              "minimumInventory": element.minimumInventory, 
              "maximumInventory": element.maximumInventory,
              "baseMaterialUnit":element.baseMaterialUnit,
              "totalQuantity": element.totalQuantity,
            }
            dataRowTemp.push(data);
        });
        this.dataRow = dataRowTemp;
      }
    )
  }
  private setStatus(totalQuantity: number, minimumInventory:number, maximumInventory:number): string{
    if(totalQuantity < minimumInventory + 10 && totalQuantity != 0)
      return "Sắp hết hàng";
    if(totalQuantity == 0)
      return "Hết hàng";
    if(totalQuantity > maximumInventory)
      return "Vượt giới hạn";
    return "Mức ổn định";
  }
}
