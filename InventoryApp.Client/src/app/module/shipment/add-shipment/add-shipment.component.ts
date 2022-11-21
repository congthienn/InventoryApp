import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { BranchService } from '../../branch/branch.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { Shipment } from '../model/shipment';
import { ShipmentService } from '../service/shipment.service';

@Component({
  selector: 'app-add-shipment',
  templateUrl: './add-shipment.component.html',
  styleUrls: ['./add-shipment.component.css']
})
export class AddShipmentComponent implements OnInit {
  submitData = false;
  addShipmentForm!:FormGroup;
  shipment: Shipment;
  @Input() branchIdInput: any;
  constructor(public activeModal: NgbActiveModal,
    private branchService: BranchService,
    private sweetalertService: SweetalertService,
    private shipmentService: ShipmentService
    ) {
    this.shipment = {} as Shipment;   
  }
  ngOnInit(): void {
    this.addShipmentForm = new FormGroup({
      code: new FormControl(this.shipment.code, Validators.required),
      expirationDate: new FormControl(this.shipment.expirationDate, Validators.required),
      branchId: new FormControl(this.shipment.branchId),
      branchName: new FormControl()
    });
    this.getBranch();
  }
  getBranch(){
    this.branchService.getBranchById( this.branchIdInput).subscribe(
      response => {
        this.addShipmentForm.patchValue({branchId:response.id});
        this.addShipmentForm.patchValue({branchName:response.companyName});
      }
    )
  }
  get code() { return this.addShipmentForm.get('code'); }
  get expirationDate() { return this.addShipmentForm.get('expirationDate'); }
  get branchId() { return this.addShipmentForm.get('branchId'); }
  get branchName() { return this.addShipmentForm.get('branchName'); }
  addShipmentData(){
    this.shipmentService.addShipment(this.addShipmentForm.value).subscribe(
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
      text: 'Thêm mới kho hàng thành công',
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.activeModal.close();
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}
