import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { WarehouseArea } from '../model/warehouse-area';
import { WarehouseLine } from '../model/warehouse-line';
import { WarehouseAreaService } from '../service/warehouse-area.service';
import { WarehouseLineService } from '../service/warehouse-line.service';

@Component({
  selector: 'app-add-warehouse-line',
  templateUrl: './add-warehouse-line.component.html',
  styleUrls: ['./add-warehouse-line.component.css']
})
export class AddWarehouseLineComponent implements OnInit {
  @Input() warehouseData : any;
  @Input() warehouseAreaData : any;
  submitData = false;
  addWarehouseLineForm!:FormGroup;
  warehouseLine:WarehouseLine; 
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService,
    private warehouseLLineService: WarehouseLineService,
    ) 
  {
    this.warehouseLine = {} as WarehouseLine;   
  }
  ngOnInit(): void {
    this.addWarehouseLineForm = new FormGroup({
      name: new FormControl(this.warehouseLine.name, Validators.required),
      warehouseAreaId: new FormControl(this.warehouseLine.warehouseId)
    });
    this.addWarehouseLineForm.patchValue({warehouseAreaId: this.warehouseAreaData.id})
  }
  get name() { return this.addWarehouseLineForm.get('name'); }
  get warehouseAreaId() { return this.addWarehouseLineForm.get('warehouseAreaId'); }

  addWarehouseLine(){
    this.submitData = true;
    this.warehouseLLineService.addWarehouseLine(this.addWarehouseLineForm.value).subscribe(
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