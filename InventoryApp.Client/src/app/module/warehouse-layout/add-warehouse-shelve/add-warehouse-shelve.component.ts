import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { WarehouseShelve } from '../model/warehouse-shelve';
import { WarehouseShelveService } from '../service/warehouse-shelve.service';

@Component({
  selector: 'app-add-warehouse-shelve',
  templateUrl: './add-warehouse-shelve.component.html',
  styleUrls: ['./add-warehouse-shelve.component.css']
})
export class AddWarehouseShelveComponent implements OnInit {
  @Input() warehouseData : any;
  @Input() warehouseAreaData : any;
  @Input() warehouseLineData : any;
  submitData = false;
  addWarehouseShelveForm!:FormGroup;
  warehouseShelve:WarehouseShelve; 
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService,
    private warehouseShelveService: WarehouseShelveService,
    ) 
  {
    this.warehouseShelve = {} as WarehouseShelve;   
  }
  ngOnInit(): void {
    this.addWarehouseShelveForm = new FormGroup({
      name: new FormControl(this.warehouseShelve.name, Validators.required),
      warehouseLineId: new FormControl(this.warehouseShelve.warehouseLineId)
    });
    this.addWarehouseShelveForm.patchValue({warehouseLineId: this.warehouseLineData.id})
  }
  get name() { return this.addWarehouseShelveForm.get('name'); }
  get warehouseLineId() { return this.addWarehouseShelveForm.get('warehouseLineId'); }

  addWarehouseShelve(){
    this.submitData = true;
    this.warehouseShelveService.addWarehouseShelve(this.addWarehouseShelveForm.value).subscribe(
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
      text: 'Thêm mới dãy hàng thành công',
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