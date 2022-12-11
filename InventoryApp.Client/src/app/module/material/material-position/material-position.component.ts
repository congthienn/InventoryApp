import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Select2OptionData } from 'ng-select2';
import { AuthService } from 'src/app/auth/auth.service';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { BranchService } from '../../branch/branch.service';
import { Branch } from '../../branch/model/branch';
import { BtnCellRenderer } from '../../share/ag-grid-button/ag-grid-button.component';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { MaterialShipment } from '../../shipment/model/material-shipment';
import { MaterialService } from '../service/material.service';

@Component({
  selector: 'app-material-position',
  templateUrl: './material-position.component.html',
  styleUrls: ['./material-position.component.css']
})
export class MaterialPositionComponent implements OnInit {
  public Title = '';
  public loadData = true;
  branchList!: Array<Select2OptionData>;
  dataRow: any[] = [];
  materialPosistion: MaterialShipment[] = [];
  public rowSelection: 'single' | 'single' = 'single';
  columnDefs : any[]= [];
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
    },
    {
      path: '/san-pham/vi-tri',
      title: 'Vị trí sản phẩm',
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

  constructor(
    private branchService: BranchService, 
    private title: Title, 
    private materialService: MaterialService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.title.setTitle("Vị trí sản phẩm");
    this.Title = "Quản lý vị trí sản phẩm";
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
      var branchs: unknown[] = this.authService.decodeToken().Branch;
      this.branchList = tempData.filter(item => branchs.includes(item.id));
      this.loadData = false;
    })
  }

  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: "material", headerName:"SẢN PHẨM",cellStyle: {fontWeight: '500'}, initialPinned: 'left', width:250, resizable:true}, 
      { field: 'shipment', headerName: "LÔ HÀNG", width:300,  cellStyle: {fontWeight: '500'}, resizable:true },
      { field: 'code', headerName: "MÃ SẢN PHẨM", width:170 },
      { field: 'quantityInStock', headerName: "SỐ LƯỢNG TRONG KHO", width:220, cellStyle: {textAlign  : 'center', fontWeight: '500'}},
      { field: 'position', headerName: "VỊ TRÍ SẢN PHẨM", width:350 },  
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
    this.materialService.getMaterialPositionsByBranchId(branchId).subscribe(
      response =>{
        this.materialPosistion = response;
        var dataRowTemp: any[]= [];
        this.materialPosistion.forEach(element => {
          var data = {
              "material":element.material.name,
              "code": element.material.code,
              "shipment": element.shipment.code, 
              "quantityInStock": element.quantityInStock,
              "position": element.position,
            }
            dataRowTemp.push(data);
        });
        this.dataRow = dataRowTemp;
      }
    )
  }
}
