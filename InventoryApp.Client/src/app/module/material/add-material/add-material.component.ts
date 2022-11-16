import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PageTitle } from 'src/app/share/layout/page-title/page-title.component';
import { CategoryMaterialComponent } from '../../category-material/category-material.component';
import { TrademarkComponent } from '../../trademark/trademark.component';

@Component({
  selector: 'app-add-material',
  templateUrl: './add-material.component.html',
  styleUrls: ['./add-material.component.css']
})
export class AddMaterialComponent implements OnInit {
  public Title = '';
  public detailedDescription = '';
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
  constructor(private title:Title, private modalService: NgbModal) { }

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
  }
  openModalTrademark(){
    this.modalService.open(TrademarkComponent)
  }
  openModalCategoryMaterial(){
    this.modalService.open(CategoryMaterialComponent)
  }
}
