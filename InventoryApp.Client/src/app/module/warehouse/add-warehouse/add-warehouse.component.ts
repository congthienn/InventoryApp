import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Select2OptionData } from 'ng-select2';
import Swal from 'sweetalert2';
import { BranchService } from '../../branch/branch.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { Warehouse } from '../model/warehouse';
import { WarehouseService } from '../service/warehouse.service';

@Component({
  selector: 'app-add-warehouse',
  templateUrl: './add-warehouse.component.html',
  styleUrls: ['./add-warehouse.component.css']
})
export class AddWarehouseComponent implements OnInit {
  branchList!: Array<Select2OptionData>;
  submitData = false;
  addWarehouseForm!:FormGroup;
  warehouse:Warehouse;
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService, 
    private branchService: BranchService,
    private warehouseService : WarehouseService,
    private router : Router
    ) {
    this.warehouse = {} as Warehouse;   
  }
  ngOnInit(): void {
    this.addWarehouseForm = new FormGroup({
      name: new FormControl(this.warehouse.name, Validators.required),
      maximumCapacity: new FormControl(this.warehouse.maximumCapacity,[Validators.required, Validators.min(0)]),
      branchId: new FormControl(this.warehouse.branchId,[Validators.required, Validators.min(0)])
    })
    this.getBranchList();
  }
  get name() { return this.addWarehouseForm.get('name'); }
  get maximumCapacity() { return this.addWarehouseForm.get('maximumCapacity'); }
  get branchId() { return this.addWarehouseForm.get('branchId'); }

  addWarehouse(){
    this.submitData = true;
    this.warehouseService.addWarehouse(this.addWarehouseForm.value).subscribe(
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
      this.router.navigate(['/kho-hang'])
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
  refreshBranchData(){
    this.getBranchList();
  }
  getBranchList(){
    var tempData: { id: string; text: string; }[] = [];
    this.branchService.getAllBranch().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.companyName
        }
        tempData.push(data);
      });
      this.branchList = tempData;
    })
  }
  changeBranchValue(data: any){
    if(data != undefined){
      this.addWarehouseForm.patchValue({branchId: data != 'null' ? data : null});
      document.getElementById("branchId")?.focus();
    }
  }
}
