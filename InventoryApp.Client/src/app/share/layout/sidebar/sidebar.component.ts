import { Component, OnInit } from '@angular/core';
import { faBook, faBoxesStacked, faBuilding ,faDashboard,faGear,faParachuteBox, faPeopleGroup, faReorder, faUsers, faUserSecret, faWarehouse } 
from '@fortawesome/free-solid-svg-icons';

export interface RouteInfo {
  path: string;
  title: string;
  icontype: any;
  roleAccess?: boolean;
  collapse?: string;
  children?: ChildrenItems[];
}

export interface ChildrenItems {
  path: string;
  title:string;
}

export const ROUTES: RouteInfo[] = [
  {
    path: 'san-pham',
    title: 'Danh mục sản phẩm',
    icontype: faParachuteBox,
    collapse: 'managerMaterial',
    roleAccess: true,
    children: [
      { path: '', title:'Danh sách'},
      { path: 'them-moi', title:'Thêm mới'},
    ],
  },
  {
    path: 'kho-hang',
    title: 'Kho hàng',
    icontype: faWarehouse,
    collapse: 'managerWarehouse',
    roleAccess: true,
    children: [
      { path: '', title: 'Danh sách'},
      { path: 'xuat-kho', title: 'Xuất kho'},
      { path: 'nhap-kho', title: 'Nhập kho'},
      { path: 'so-lieu-thong-ke', title: 'Số liệu thống kê'},
      { path: 'vi-tri-san-pham', title: 'Vị trí sản phẩm'},
    ],
  },
  {
    path: 'chi-nhanh',
    title: 'Chi nhánh',
    icontype: faBuilding,
    collapse: 'managerBranch',
    roleAccess: true,
    children: [
      { path: '',title: 'Danh sách'},
      { path: 'them-moi', title: 'Thêm mới'},
    ],
  },
  {
    path: 'lo-hang',
    title: 'Lô hàng',
    icontype: faBoxesStacked,
    collapse: 'managerShipment',
    roleAccess: true,
    children: [
      { path: '',title: 'Danh sách'},
      { path: 'so-lieu-thong-ke', title: 'Số liệu thống kê'},
    ],
  },
  {
    path: '',
    title: 'Đối tác',
    icontype: faPeopleGroup,
    collapse: 'managerPartner',
    roleAccess: true,
    children: [
      { path: 'khach-hang', title: 'Khách hàng'},
      { path: 'nha-cung-cap',title: 'Nhà cung cấp'},
    ],
  },
  {
    path: 'don-dat-hang',
    title: 'Đơn đặt hàng',
    icontype: faReorder,
    collapse: 'order',
    roleAccess: true,
    children: [
      { path: 'danh-sach',title: 'Danh sách'},
      { path: 'them-moi', title: 'Thêm mới'},
      { path: 'nhom-nha-cung-cap',title: 'Nhóm nhà cung cấp'},
      { path: 'so-lieu-thong-ke',title: 'Số liệu thống kê'},
    ],
  },
  {
    path: 'bao-cao',
    title: 'Báo cáo',
    icontype: faBook,
    collapse: 'report',
    roleAccess: true,
    children: [
      { path: 'tai-chinh',title: 'Tài chính'},
      { path: 'ban-hang', title: 'Bán hàng'},
      { path: 'khach-hang',title: 'Khách hàng'},
      { path: 'nha-cung-cap',title: 'Nhà cung cấp'},
    ],
  },
  {
    path: 'quan-ly-tai-khoan',
    title: 'Quản lý tài khoản',
    icontype: faUsers,
    collapse: 'managerUser',
    roleAccess: true,
    children: [
      { path: 'danh-sach',title: 'Danh sách'},
      { path: 'them-moi', title: 'Thêm mới'},
    ],
  },
  {
    path: 'chuc-vu-vai-tro',
    title: 'Chức vụ - Vai trò',
    icontype: faUserSecret,
    collapse: 'role',
    roleAccess: true,
    children: [
      { path: 'danh-sach',title: 'Danh sách'},
      { path: 'phan-quyen', title: 'Phân quyền'},
    ],
  },
  {
    path: 'cai-dat-chung',
    title: 'Cài đặt chung',
    icontype: faGear,
    collapse: 'role',
    roleAccess: true,
    children: [
      { path: 'thong-tin-cong-ty',title: 'Thông tin công ty'},
      { path: 'mau-email-chung', title: 'Mẫu email chung'},
    ],
  },
]

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent {
  public menuItems!: any[];
  public fadashboard = faDashboard;
  public Click(id:string) {

    var allItemSidebar = document.getElementsByClassName('waves-effect');  
    for(var i=0; i< allItemSidebar.length; i++) {
      allItemSidebar.item(i)?.classList.remove('collapse_item');
    }

    var itemElement = document.getElementById(id);
    if(itemElement?.classList.contains('collapse_item')){
      itemElement?.classList.remove('collapse_item')
    }
    else{
      itemElement?.classList.add('collapse_item')
    }
  }
  
  ngOnInit() {
    this.menuItems = ROUTES.filter((menuItem) => menuItem);
  }
}