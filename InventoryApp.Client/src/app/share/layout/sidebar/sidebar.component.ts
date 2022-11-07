import { Component, OnInit } from '@angular/core';
import { faBoxesStacked, faBuilding ,faDashboard,faParachuteBox, faPeopleGroup, faWarehouse } from '@fortawesome/free-solid-svg-icons';
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


  public managerMaterial = true;
  public managerShipment = true;
  public managerBranch = true;
  public managerPartner = true;
  public manaagerWarehouse = true;
}