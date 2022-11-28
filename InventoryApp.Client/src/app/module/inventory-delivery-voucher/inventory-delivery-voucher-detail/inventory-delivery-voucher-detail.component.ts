import { Component, Input, OnInit } from '@angular/core';
import { CompanyService } from '../../general/company.service';
import { InventoryDeliveryVoucher } from '../model/inventory-delivery-voucher';
import { InventoryDeliveryVoucherService } from '../service/inventory-delivery-voucher.service';

@Component({
  selector: 'app-inventory-delivery-voucher-detail',
  templateUrl: './inventory-delivery-voucher-detail.component.html',
  styleUrls: ['./inventory-delivery-voucher-detail.component.css']
})
export class InventoryDeliveryVoucherDetailComponent implements OnInit {
  
  @Input() id:any;
  public loadData = false;
  public company:any;
  public dateOrder:any;
  public priceTotal:number = 0;
  public inventoryDeliveryVoucher!:InventoryDeliveryVoucher;
  constructor(private companyService: CompanyService,
      private inventoryDeliveryVoucherService: InventoryDeliveryVoucherService
    ) { }

  ngOnInit(): void {
      this.getInventoryReceivingVoucher(this.id);
      this.getCompanyName();
      
  }
  getCompanyName(){
    this.companyService.getCompanyInfomation().subscribe(company => {
      this.company = company;
    })
  }
  getInventoryReceivingVoucher(id:string){
    this.loadData = true;
    this.inventoryDeliveryVoucherService.getInventoryDeliveryVoucherById(id).subscribe(response =>{
      this.inventoryDeliveryVoucher = response;
      console.log(this.inventoryDeliveryVoucher)
      let date = new Date(this.inventoryDeliveryVoucher.goodsIssueDate);
      this.dateOrder = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
      this.inventoryDeliveryVoucher.details.forEach((item) => {
          item.priceTotalItem = Number(item.price) * Number(item.quantityDelivery);
          this.priceTotal += item.priceTotalItem;
      })
      this.loadData = false;
    })
  }

}


