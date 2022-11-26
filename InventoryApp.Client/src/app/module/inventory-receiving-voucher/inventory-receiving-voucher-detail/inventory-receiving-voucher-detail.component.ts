import { Component, Input, OnInit } from '@angular/core';
import { CompanyService } from '../../general/company.service';
import { Order } from '../../order/model/order';
import { InventoryReceivingVoucher } from '../model/inventory-receiving-voucher';
import { InventoryReceivingVoucherService } from '../service/inventory-receiving-voucher.service';

@Component({
  selector: 'app-inventory-receiving-voucher-detail',
  templateUrl: './inventory-receiving-voucher-detail.component.html',
  styleUrls: ['./inventory-receiving-voucher-detail.component.css']
})
export class InventoryReceivingVoucherDetailComponent implements OnInit {

  @Input() id:any;
  public loadData = false;
  public company:any;
  public dateOrder:any;
  public priceTotal:number = 0;
  public inventoryReceivingVoucher!:InventoryReceivingVoucher;
  constructor(private companyService: CompanyService,
      private inventoryReceivingVoucherService: InventoryReceivingVoucherService
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
    this.inventoryReceivingVoucherService.getInventoryReceivingVoucherById(id).subscribe(response =>{
      this.inventoryReceivingVoucher = response;
      let date = new Date(this.inventoryReceivingVoucher.goodsImportDate);
      this.dateOrder = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
      this.inventoryReceivingVoucher.detail.forEach((item) => {
          item.priceTotalItem = Number(item.price) * Number(item.quantityReceiving);
          this.priceTotal += item.priceTotalItem;
      })
      this.loadData = false;
    })
  }

}

