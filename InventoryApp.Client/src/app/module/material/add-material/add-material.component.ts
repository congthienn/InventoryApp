import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Select2OptionData } from 'ng-select2';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { CategoryMaterialComponent } from '../../category-material/category-material.component';
import { CategoryMaterialService } from '../../category-material/service/category-material.service';
import { SweetalertService } from '../../share/sweetalert/sweetalert.service';
import { TrademarkService } from '../../trademark/service/trademark.service';
import { TrademarkComponent } from '../../trademark/trademark.component';
import { Material } from '../model/material';
import { MaterialService } from '../service/material.service';

@Component({
  selector: 'app-add-material',
  templateUrl: './add-material.component.html',
  styleUrls: ['./add-material.component.css']
})
export class AddMaterialComponent implements OnInit {
  public Title = '';
  public submitData = false;
  public description!:string;
  public pageTite : PageTitle[] = [
    {
      path: '/tong-quan',
      title: 'Trang chủ',
      active: false
    },
    {
      path: '/san-pham/',
      title: 'Sản phẩm',
      active: false
    },
    {
      path: '/san-pham/them-moi',
      title: 'Thêm mới',
      active: true
    },
  ]
  modules = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],
      ['blockquote'],
      [{ 'list': 'ordered' }, { 'list': 'bullet' }],
      [{ 'script': 'sub' }, { 'script': 'super' }],
      [{ 'indent': '-1' }, { 'indent': '+1' }],
      [{ 'direction': 'rtl' }],
      [{ 'size': ['small', false, 'large', 'huge'] }],
      [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
      [{ 'color': []}, { 'background': []}],
      [{ 'align': [] }],
      ['clean']
    ]
  };
    files: File[] = [];
  addMaterialForm!:FormGroup;
  material: Material;
  categoryMaterialList!: Array<Select2OptionData>;
  trademarkList!: Array<Select2OptionData>;
  constructor(private title:Title,
     private modalService: NgbModal,
    private categoryMaterialService : CategoryMaterialService ,
    private trademarkService : TrademarkService,
    private materialService : MaterialService,
    private sweetalertService : SweetalertService
    ) { 
    this.material = {} as Material;
  }
  getCategoryMaterialList(){
    var tempData: { id: string; text: string; }[] = [];
    this.categoryMaterialService.getAllCategoryMaterial().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.categoryMaterialList = tempData;
    })
  }
  getTrademarkList(){
    var tempData: { id: string; text: string; }[] = [];
    this.trademarkService.getAllTrademark().subscribe(response => {
      response.forEach((element: any) => {
        var data = {
          id: element.id,
          text: element.name
        }
        tempData.push(data);
      });
      this.trademarkList = tempData;
    })
  }
	onSelect(event: { addedFiles: any; }) {
		this.files.push(...event.addedFiles);
    console.log(this.files);
	}

	onRemove(event: File) {
		this.files.splice(this.files.indexOf(event), 1);
	}
 
  ngOnInit(): void {
    this.title.setTitle("Sản phẩm");
    this.Title = "Quản lý sản phẩm";
    this.addMaterialForm = new FormGroup({
      name: new FormControl(this.material.name,[Validators.required]),
      salePrice: new FormControl(this.material.salePrice,[Validators.required, Validators.min(0)]),
      costPrice: new FormControl(this.material.costPrice,[Validators.required, Validators.min(0)]),
      baseMaterialUnit: new FormControl(this.material.baseMaterialUnit,[Validators.required]),
      categoryMaterialId: new FormControl(this.material.categoryMaterialId,[Validators.required]),
      trademarkId: new FormControl(this.material.trademarkId,[Validators.required]),
      minimumInventory: new FormControl(this.material.minimumInventory,[Validators.required, Validators.min(0)]),
      maximumInventory: new FormControl(this.material.maximumInventory,[Validators.required, Validators.min(0)]),
      weight: new FormControl(this.material.weight,[Validators.required, Validators.min(0)]),
      detailedDescription: new FormControl(this.material.detailedDescription,[Validators.required])
    })
    this.getCategoryMaterialList();
    this.getTrademarkList();
  }
  get name() { return this.addMaterialForm.get('name'); }
  get salePrice() { return this.addMaterialForm.get('salePrice'); }
  get costPrice() { return this.addMaterialForm.get('costPrice'); }
  get baseMaterialUnit() { return this.addMaterialForm.get('baseMaterialUnit'); }
  get categoryMaterialId() { return this.addMaterialForm.get('categoryMaterialId'); }
  get trademarkId() { return this.addMaterialForm.get('trademarkId'); }
  get minimumInventory() { return this.addMaterialForm.get('minimumInventory'); }
  get maximumInventory() { return this.addMaterialForm.get('maximumInventory'); }
  get weight() { return this.addMaterialForm.get('weight'); }
  get detailedDescription() { return this.addMaterialForm.get('detailedDescription'); }

  openModalTrademark(){
    this.modalService.open(TrademarkComponent).result.then((result) => {
      this.getTrademarkList();
      },(reason) => {
        this.getTrademarkList();
      });
  }
  openModalCategoryMaterial(){
    this.modalService.open(CategoryMaterialComponent).result.then((result) => {
      this.getCategoryMaterialList();
      },(reason) => {
        this.getCategoryMaterialList();
      });
  }
  changCategoryMaterialValue(data:any){
    if(data != undefined){
      this.addMaterialForm.patchValue({categoryMaterialId: data != 'null' ? data : null});
      document.getElementById("categoryMaterialId")?.focus();
    }
  }
  changTrademarkValue(data:any){
    if(data != undefined){
      this.addMaterialForm.patchValue({trademarkId: data != 'null' ? data : null});
      document.getElementById("trademarkId")?.focus();
    }
  }
  refreshCategoryMaterial(){
    this.getCategoryMaterialList();
  }
  refreshTrademark(){
    this.getTrademarkList();
  }
  changeDetailedDescription(){
    this.addMaterialForm.patchValue({detailedDescription: this.description});
  }
  addMaterial(){
    this.submitData = true;
    var formData = new FormData();
    formData.append("Name", this.addMaterialForm.get('name')?.value);
    formData.append("SalePrice", this.addMaterialForm.get('salePrice')?.value);
    formData.append("CostPrice", this.addMaterialForm.get('costPrice')?.value);
    formData.append("BaseMaterialUnit", this.addMaterialForm.get('baseMaterialUnit')?.value);
    formData.append("CategoryMaterialId", this.addMaterialForm.get('categoryMaterialId')?.value);
    formData.append("TrademarkId", this.addMaterialForm.get('trademarkId')?.value);
    formData.append("MinimumInventory", this.addMaterialForm.get('minimumInventory')?.value);
    formData.append("MaximumInventory", this.addMaterialForm.get('maximumInventory')?.value);
    formData.append("Weight", this.addMaterialForm.get('weight')?.value);
    formData.append("DetailedDescription", this.addMaterialForm.get('detailedDescription')?.value);
    for (var i = 0; i < this.files.length; i++) { 
      formData.append("Prictures", this.files[i], this.files[i].name);
    }
    this.materialService.addMaterial(formData).subscribe(
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
    this.sweetalertService.alertAction("/san-pham","Thêm thông tin sản phẩm thành công");
  }
  showError(){
    this.sweetalertService.alertMini("Không thể lưu dữ liệu","Vui lòng kiểm tra lại", "error");
  }
}