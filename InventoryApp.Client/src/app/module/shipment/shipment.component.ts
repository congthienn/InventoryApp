import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ColDef, GridOptions } from 'ag-grid-community';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';

@Component({
  selector: 'app-shipment',
  templateUrl: './shipment.component.html',
  styleUrls: ['./shipment.component.css']
})
export class ShipmentComponent implements OnInit {
  dataRow: any[] = [];
  columnDefs : any[]= [];
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
  constructor(private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("Lô hàng");
    this.Title = "Quản lý lô hàng";
    this.updateColumnDefs();
  }
  private updateColumnDefs() {
    this.columnDefs  =  [
      { field: 'id',  
        width: 60, 
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign  : 'left'},
        initialPinned: 'left',
        // cellRenderer: BtnCellRenderer,
      }, 
      { field: "code", headerName:"MÃ LÔ HÀNG",cellStyle: {fontWeight: '500'}, initialPinned: 'left'}, 
      { field: 'material', headerName: "SẢN PHẨM" },
      { field: 'branch', headerName: "CHI NHÁNH", width:300,  cellStyle: {fontWeight: '500'},resizable:true },
      { field: 'materialQuantity', headerName: "SỐ LƯỢNG NHẬP KHO" },
      { field: 'quantityInStock', headerName: "SỐ LƯỢNG TRONG KHO" },
      { field: 'expirationDate', headerName: "NGÀY HẾT HẠN" },
    ];
  }
  onPageSizeChanged() {
    var text = (<HTMLInputElement>document.getElementById('page-size')).value;
    this.sizePagination = Number(text);
  }
}
