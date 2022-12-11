import { Component, OnInit } from '@angular/core';
import { faBook, faBoxesStacked, faBuilding ,faChessBishop,faDashboard,faGear,faParachuteBox, faPeopleGroup, faReorder, faUsers, faUserSecret, faWarehouse } 
from '@fortawesome/free-solid-svg-icons';
import { AuthService } from 'src/app/auth/auth.service';

export interface RouteInfo {
  path: string;
  title: string;
  icontype: any;
  roleAccess?: boolean;
  collapse?: string;
  children?: ChildrenItems[];
  role:string[];
}

export interface ChildrenItems {
  path: string;
  title:string;
  roleAccess:boolean;
  role:string[];
}

export const ROUTES: RouteInfo[] = [
  {
    path: 'san-pham',
    title: 'Danh mục sản phẩm',
    icontype: faParachuteBox,
    collapse: 'managerMaterial',
    role: ['Quản trị hệ thống', 'Thủ kho', "Nhân viên bán hàng"],
    roleAccess: true,
    children: [
      { path: '', title:'Danh sách', roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho', "Nhân viên bán hàng"]},
      { path: 'vi-tri', title:'Vị trí sản phẩm', roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho', "Nhân viên bán hàng"]},
    ],
  },
  {
    path: 'kho-hang',
    title: 'Kho hàng',
    icontype: faWarehouse,
    role: ['Quản trị hệ thống', 'Thủ kho'],
    collapse: 'managerWarehouse',
    roleAccess: true,
    children: [
      { path: '', title: 'Danh sách',roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho']},
      { path: 'danh-sach-phieu-xuat-kho', title: 'Xuất kho',roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho']},
      { path: 'danh-sach-phieu-nhap-kho', title: 'Nhập kho', roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho']},
      { path: 'thong-ke-san-pham', title: 'Thống kê sản phẩm',roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho']},
      { path: 'bo-cuc-kho', title: 'Bố cục kho',roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho']},
    ],
  },
  {
    path: 'lo-hang',
    title: 'Lô hàng',
    icontype: faBoxesStacked,
    role: ['Quản trị hệ thống', 'Thủ kho'],
    collapse: 'managerShipment',
    roleAccess: true,
    children: [
      { path: '',title: 'Danh sách',roleAccess: true, role: ['Quản trị hệ thống', 'Thủ kho']}
    ],
  },
  {
    path: '',
    title: 'Đối tác',
    icontype: faPeopleGroup,
    role: ['Quản trị hệ thống', 'Thủ kho','Nhân viên bán hàng'],
    collapse: 'managerPartner',
    roleAccess: true,
    children: [
      { path: 'khach-hang', title: 'Khách hàng', roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho','Nhân viên bán hàng']},
      { path: 'nha-cung-cap',title: 'Nhà cung cấp', roleAccess: false,role: ['Quản trị hệ thống', 'Thủ kho']},
      { path: 'don-vi-giao-hang', title: 'Đơn vị giao hàng', roleAccess: true,role: ['Quản trị hệ thống', 'Thủ kho','Nhân viên bán hàng']},
    ],
  },
  {
    path: 'don-hang',
    title: 'Đơn hàng',
    icontype: faReorder,
    role: ['Quản trị hệ thống', 'Thủ kho', "Nhân viên bán hàng"],
    collapse: 'order',
    roleAccess: true,
    children: [
      { path: '',title: 'Danh sách',roleAccess: true, role: ['Quản trị hệ thống', 'Thủ kho', "Nhân viên bán hàng"]},
    ],
  },
  {
    path: 'dat-hang',
    title: 'Đặt hàng',
    icontype: faChessBishop,
    role: ['Quản trị hệ thống', 'Thủ kho'],
    collapse: 'managerOrder',
    roleAccess: true,
    children: [
      { path: '',title: 'Danh sách', roleAccess: true, role: ['Quản trị hệ thống', 'Thủ kho']},
    ],
  },
  // {
  //   path: 'bao-cao',
  //   title: 'Báo cáo',
  //   icontype: faBook,
  //   collapse: 'report',
  //   roleAccess: true,
  //   children: [
  //     { path: 'tai-chinh',title: 'Tài chính'},
  //     { path: 'ban-hang', title: 'Bán hàng'},
  //     { path: 'khach-hang',title: 'Khách hàng'},
  //     { path: 'nha-cung-cap',title: 'Nhà cung cấp'},
  //   ],
  // },
  {
    path: 'chi-nhanh',
    title: 'Chi nhánh',
    icontype: faBuilding,
    role: ['Quản trị hệ thống'],
    collapse: 'managerBranch',
    roleAccess: true,
    children: [
      { path: '',title: 'Danh sách',roleAccess: true, role: ['Quản trị hệ thống'],}
    ],
  },
  {
    path: 'nhan-vien',
    title: 'Nhân viên',
    icontype: faUsers,
    role: ['Quản trị hệ thống'],
    collapse: 'managerUser',
    roleAccess: true,
    children: [
      { path: '',title: 'Danh sách',roleAccess: true, role: ['Quản trị hệ thống']},
    ],
  },
  // {
  //   path: 'chuc-vu-vai-tro',
  //   title: 'Chức vụ - Vai trò',
  //   icontype: faUserSecret,
  //   collapse: 'role',
  //   roleAccess: true,
  //   children: [
  //     { path: 'danh-sach',title: 'Danh sách'},
  //     { path: 'phan-quyen', title: 'Phân quyền'},
  //   ],
  // },
  {
    path: 'cai-dat-chung',
    title: 'Cài đặt chung',
    icontype: faGear,
    role: ['Quản trị hệ thống'],
    collapse: 'setting',
    roleAccess: true,
    children: [
      { path: 'thong-tin-cong-ty', title: 'Thông tin công ty', roleAccess: true,role: ['Quản trị hệ thống']},
      // { path: 'mau-email-chung', title: 'Mẫu email chung'},
    ],
  },
]

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit {
  public constructor(private authService: AuthService){}
  public menuItems!: any[];
  public fadashboard = faDashboard;
  role = this.authService.getRole();
  dashboard = this.authService.getRole() === "Quản trị hệ thống" || this.authService.getRole() === "Thủ kho";
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
    this.menuItems.forEach(menuItem =>{
      menuItem.roleAccess = menuItem.role.includes(this.role);
      menuItem.children.forEach((child: any) => {
        child.roleAccess = child.role.includes(this.role);
      })
    })
  }
}