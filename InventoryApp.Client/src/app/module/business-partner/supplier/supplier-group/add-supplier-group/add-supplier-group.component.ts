import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { SupplierGroup } from '../../model/supplierGroup';
import { SupplierGroupService } from '../../service/supplier-group.service';
import { SupplierGroupComponent } from '../supplier-group.component';

@Component({
  selector: 'app-add-supplier-group',
  templateUrl: './add-supplier-group.component.html',
  styleUrls: ['./add-supplier-group.component.css']
})
export class AddSupplierGroupComponent implements OnInit {
  submitData = false;
  addSupplierGroupForm!:FormGroup;
  supplierGroup: SupplierGroup;
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService, 
    private supplierGroupService: SupplierGroupService,
    private modalService: NgbModal
    ) {
    this.supplierGroup = {} as SupplierGroup;   
  }
  ngOnInit(): void {
    this.addSupplierGroupForm = new FormGroup({
      name: new FormControl(this.supplierGroup.name,Validators.required)
    })
  }
  get name() { return this.addSupplierGroupForm.get('name'); }

  addSupplierGroup(){
    this.submitData = true;
    this.supplierGroupService.addData(this.addSupplierGroupForm.value).subscribe(
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
      text: 'Thêm mới nhóm nhà cung cấp thành công',
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.modalService.dismissAll();
      this.modalService.open(SupplierGroupComponent);
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}
