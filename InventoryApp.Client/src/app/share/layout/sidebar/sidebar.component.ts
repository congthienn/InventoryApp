import { Component, OnInit } from '@angular/core';
import { faBook, faBoxesStacked, faBuilding ,faDashboard,faGear,faParachuteBox, faPeopleGroup, faReorder, faUsers, faUserSecret, faWarehouse } 
from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  faWarehouse = faWarehouse;
  faparachutebox = faParachuteBox;
  faboxesstacked = faBoxesStacked;
  fapeoplegroup = faPeopleGroup;
  fabuilding = faBuilding;
  fadashboard = faDashboard;
  faGear = faGear;
  faReorder = faReorder;
  faUsers = faUsers;
  faUserSecret = faUserSecret;
  faBook = faBook;

  public clicked = true;
  public collapseParent = "#collapseParent";
  public managerMaterial = true;
  public managerShipment = true;
  public managerBranch = true;
  public managerPartner = true;
  public managerWarehouse = true;
  public generalSetting  = true;
  public role = true;
  public order = true;
  public managerUser = true;
  public report = true;

  public Click(item: string) {
    this.managerMaterial =  item != "managerMaterial";
    this.managerShipment = item  != "managerShipment";
    this.managerBranch = item  != "managerBranch";
    this.managerPartner = item  != "managerPartner";
    this.managerWarehouse = item  != "managerWarehouse";
    this.generalSetting = item != "generalSetting";
    this.role = item != "role";
    this.order = item != "order";
    this.managerUser = item != "managerUser";
    this.report = item != "report";
  }
}