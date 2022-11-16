import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SweetalertService } from 'src/app/module/share/sweetalert/sweetalert.service';
import Swal from 'sweetalert2';
import { AddCustomerComponent } from '../../add-customer/add-customer.component';
import { CustomerGroup } from '../../model/customerGroup';
import { CustomerGroupService } from '../../service/customer-group.service';
import { CustomerGroupComponent } from '../customer-group.component';

@Component({
  selector: 'app-add-customer-group',
  templateUrl: './add-customer-group.component.html',
  styleUrls: ['./add-customer-group.component.css']
})
export class AddCustomerGroupComponent implements OnInit {

  submitData = false;
  addCustomerGroupForm!:FormGroup;
  customerGroup:CustomerGroup;
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService, 
    private customerFroupService: CustomerGroupService,
    private modalService: NgbModal
    ) {
    this.customerGroup = {} as CustomerGroup;   
  }
  ngOnInit(): void {
    this.addCustomerGroupForm = new FormGroup({
      name: new FormControl(this.customerGroup.name,Validators.required)
    })
  }
  get name() { return this.addCustomerGroupForm.get('name'); }

  addCustomerGroup(){
    this.submitData = true;
    this.customerFroupService.addData(this.addCustomerGroupForm.value).subscribe(
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
      text: 'Thêm mới nhóm khách hàng thành công',
      icon: "success",
      confirmButtonText: 'Done'
    }).then((result) => {
      this.modalService.dismissAll();
      this.modalService.open(CustomerGroupComponent);
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}
