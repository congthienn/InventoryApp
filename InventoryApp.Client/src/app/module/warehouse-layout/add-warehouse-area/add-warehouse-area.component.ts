import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';;
import { WarehouseArea } from '../model/warehouse-area';
import { WarehouseAreaService } from '../service/warehouse-area.service';

@Component({
  selector: 'app-add-warehouse-area',
  templateUrl: './add-warehouse-area.component.html',
  styleUrls: ['./add-warehouse-area.component.css']
})
export class AddWarehouseAreaComponent implements OnInit {
  @Input() warehouseData : any;
  submitData = false;
  addWarehouseAreaForm!:FormGroup;
  warehouseArea:WarehouseArea; 
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService,
    private warehouseAreaService: WarehouseAreaService
    ) {
    this.warehouseArea = {} as WarehouseArea;   
  }
  ngOnInit(): void {
    this.addWarehouseAreaForm = new FormGroup({
      name: new FormControl(this.warehouseArea.name, Validators.required),
      warehouseId: new FormControl(this.warehouseArea.warehouseId)
    });
    this.addWarehouseAreaForm.patchValue({warehouseId: this.warehouseData.id})
  }
  get name() { return this.addWarehouseAreaForm.get('name'); }
  get warehouseId() { return this.addWarehouseAreaForm.get('warehouseId'); }

  addWarehouseArea(){
    this.submitData = true;
    this.warehouseAreaService.addWarehouseArea(this.addWarehouseAreaForm.value).subscribe(
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
      text: 'Thêm mới khu vực kho hàng thành công',
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