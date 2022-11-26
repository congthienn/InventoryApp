import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
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
  materialShipment: MaterialShipment[]= [];
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
    private shipmentService: ShipmentService
    ) { }

  ngOnInit(): void {
    this.title.setTitle("Lô hàng");
    this.Title = "Quản lý lô hàng";
    this.updateColumnDefs();
    this.getAllShipment();
  }
  public getAllShipment(){
    document.body.style.overflow = 'hidden';
    this.shipmentService.getAllShipments().subscribe(
      response =>{
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
              "expirationDate": `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`,
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
      { field: "code", headerName:"MÃ LÔ HÀNG", width:300, cellStyle: {fontWeight: '500'}, initialPinned: 'left', resizable:true}, 
      { field: 'material', headerName: "SẢN PHẨM", resizable:true, width:300},
      { field: 'branch', headerName: "CHI NHÁNH", width:300,  cellStyle: {fontWeight: '500'}, resizable:true },
      { field: 'materialQuantity', headerName: "SỐ LƯỢNG NHẬP KHO", cellStyle: {textAlign  : 'center'}},
      { field: 'quantityInStock', headerName: "SỐ LƯỢNG TRONG KHO" , cellStyle: {textAlign  : 'center'}},
      { field: 'baseMaterialUnit', headerName: "ĐƠN VỊ CƠ BẢN"},
      { field: 'expirationDate', headerName: "NGÀY HẾT HẠN" },
    ];
  }
  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
}
