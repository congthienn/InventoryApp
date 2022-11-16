import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { CategoryMaterialComponent } from '../category-material.component';
import { CategoryMaterial } from '../model/category-material';
import { CategoryMaterialService } from '../service/category-material.service';

@Component({
  selector: 'app-add-category-material',
  templateUrl: './add-category-material.component.html',
  styleUrls: ['./add-category-material.component.css']
})
export class AddCategoryMaterialComponent implements OnInit {
  submitData = false;
  addCategoryMaterialForm!:FormGroup;
  categoryMaterial: CategoryMaterial;
  constructor(public activeModal: NgbActiveModal,
    private sweetalertService: SweetalertService, 
    private categoryMaterialService: CategoryMaterialService,
    private modalService: NgbModal
    ) {
    this.categoryMaterial = {} as CategoryMaterial;   
  }
  ngOnInit(): void {
    this.addCategoryMaterialForm = new FormGroup({
      name: new FormControl(this.categoryMaterial.name, Validators.required)
    })
  }
  get name() { return this.addCategoryMaterialForm.get('name'); }

  addCategoryMaterial(){
    this.submitData = true;
    this.categoryMaterialService.addData(this.addCategoryMaterialForm.value).subscribe(
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
      this.modalService.open(CategoryMaterialComponent);
    })
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}
