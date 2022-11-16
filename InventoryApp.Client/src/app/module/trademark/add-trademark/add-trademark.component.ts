import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { Trademark } from '../model/trademark';
import { TrademarkService } from '../service/trademark.service';
import { TrademarkComponent } from '../trademark.component';

@Component({
  selector: 'app-add-trademark',
  templateUrl: './add-trademark.component.html',
  styleUrls: ['./add-trademark.component.css']
})
export class AddTrademarkComponent implements OnInit {
  submitData = false;
  addTrademarkForm!:FormGroup;
  trademark: Trademark;
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService, 
    private trademarkService: TrademarkService,
    private modalService: NgbModal
    ) {
    this.trademark = {} as Trademark;   
  }
  ngOnInit(): void {
    this.addTrademarkForm = new FormGroup({
      name: new FormControl(this.trademark.name, Validators.required)
    })
  }
  get name() { return this.addTrademarkForm.get('name'); }

  addTrademark(){
    this.submitData = true;
    this.trademarkService.addData(this.addTrademarkForm.value).subscribe(
      response => {
        this.showSuccess();
      },
      error => {
        this.showError();
        this.submitData = false;
      }
    )
  }
  showSuccess() {  
    Swal.fire({
      title: 'Success!',
      text: 'Thêm mới thương hiệu sản phẩm thành công',
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.modalService.dismissAll();
      this.modalService.open(TrademarkComponent);
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}