import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import Swal from 'sweetalert2';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { TrademarkService } from '../service/trademark.service';
import { TrademarkComponent } from '../trademark.component';

@Component({
  selector: 'app-trademark-action-button',
  templateUrl: './trademark-action-button.component.html',
  styleUrls: ['./trademark-action-button.component.css']
})
export class TrademarkActionButtonComponent implements ICellRendererAngularComp {
  private params: any;
  clickDelete = false;
  constructor(private sweetalertService: SweetalertService, 
    private trademarkService: TrademarkService,
    private modalService: NgbModal
  ) { }
  refresh() {
    return false;
  }
  agInit(params: any): void {
    this.params = params;
  }
  btnDelete() {  
    this.clickDelete = true;
    Swal.fire({
      title: 'Bạn muốn xóa dữ liệu?',
      text: "Có thể sẽ ảnh hưởng đến những dữ liệu khác",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Xóa dữ liệu',
      cancelButtonText: 'Hủy bỏ'
    }).then((result) => {
      this.clickDelete = false;
      if (result.isConfirmed) {    
        this.deleteTrademark(this.params.value)
      }
    })
  }

  deleteTrademark(id:string){
    this.trademarkService.deleteData(id).subscribe(
      response => {
        Swal.fire({
          title: 'Success!',
          text: 'Xóa dữ liệu thành công',
          icon: "success",
          confirmButtonText: 'Done'
        }).then((result) => {
          this.modalService.dismissAll();
          this.modalService.open(TrademarkComponent);
        })
      },
      error => {
        this.sweetalertService.alertMini("Không thể xóa dữ liệu", "Vui lòng kiểm tra lại dữ liệu!", 'error');
      }
    )
  }
  btnUpdate(){
    console.log(this.params.value);
  } 

}

