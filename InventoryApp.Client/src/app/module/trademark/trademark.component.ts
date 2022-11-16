import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColDef, GridOptions } from 'ag-grid-community';
import { AddTrademarkComponent } from './add-trademark/add-trademark.component';
import { TrademarkService } from './service/trademark.service';
import { TrademarkActionButtonComponent } from './trademark-action-button/trademark-action-button.component';

@Component({
  selector: 'app-trademark',
  templateUrl: './trademark.component.html',
  styleUrls: ['./trademark.component.css']
})
export class TrademarkComponent implements OnInit {
  public sizePagination = 10;
  columnDefs : any[]= [];
  dataRow: any[] = [];
  public defaultColDef: ColDef = {
    width:160,
    filter: true,
    sortable: true,
    floatingFilter: true,
  };
  gridOptions:GridOptions = {
    pagination: true,
    cacheBlockSize: 10,
    paginationPageSize: 10
  };

	constructor(public activeModal: NgbActiveModal, 
    private modalService: NgbModal, 
    private trademarkService: TrademarkService) {}
  ngOnInit(): void {
    this.columnDefs  =  [
      { field: "name", headerName:"THƯƠNG HIỆU",width:400, cellStyle: {fontWeight: '500'}}, 
      { field: 'id',  
        width: 100,
        headerName: "",
        suppressFilter: false,
        filter: false,
        cellStyle: {textAlign : 'right'},
        cellRenderer: TrademarkActionButtonComponent,
      }, 
    ];
    this.getAllTrademark();
  }
  getAllTrademark(){
    this.trademarkService.getAllTrademark().subscribe(
      response => {  
        this.dataRow = response;
      }
    ) 
  }
  openAddTraderGroup(){
    this.modalService.open(AddTrademarkComponent);
  }
  closeModal(){ 
    this.activeModal.dismiss();
  }
}
