import { Component, Input, OnInit } from '@angular/core';
import { CustomerService } from '../../business-partner/customer/service/customer.service';
import { CompanyService } from '../../general/company.service';
import { CustomerOrder } from '../model/customer-order';
import { CustomerOrderService } from '../service/customer-order.service';

@Component({
  selector: 'app-customer-order-detail',
  templateUrl: './customer-order-detail.component.html',
  styleUrls: ['./customer-order-detail.component.css']
})
export class CustomerOrderDetailComponent implements OnInit {

  
  @Input() id:any;
  public loadData = false;
  public company:any;
  public dateOrder:any;
  public needToPay = 0;
  public returnMaterialPrice = 0;
  public priceTotal = 0;
  public formula = ''
  public paidString = '';
  public paidStatus = '';
  public returnedMaterialExists = false;
  public order!:CustomerOrder;
  constructor(private companyService: CompanyService,
      private customerOrderService: CustomerOrderService
    ) { }

  ngOnInit(): void {
      this.getOrder(this.id);
      this.getCompanyName();
      
  }
  getCompanyName(){
    this.companyService.getCompanyInfomation().subscribe(company => {
      this.company = company;
    })
  }
  getOrder(id:string){
    this.loadData = true;
    this.customerOrderService.getCustomerOrderByCode(id).subscribe(response =>{
      this.order = response;
      let date = new Date(this.order.orderDate);
      this.dateOrder = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
      this.order.orderDetail.forEach((item) => {
          item.priceTotalItem = Number(item.materialPrice) * Number(item.quantityRequest);
      })
      this.returnedMaterialExists = this.order.returnedMaterial != null;
      this.priceTotal = Number(this.order.priceTotal);
      if(this.returnedMaterialExists){
        this.order.returnedMaterial.detail.forEach((item) => {
          item.priceTotalItem = Number(item.quantity) * Number(item.price);
          this.returnMaterialPrice +=  item.priceTotalItem;
        })
        this.priceTotal -=this.returnMaterialPrice;
        this.formula = this.order.returnedMaterial.formula  ? "Hoàn tiền" : "Đổi sản phẩm mới";
      }
      this.loadData = false;
      this.needToPay = Number(this.order.priceTotal) - Number(this.order.prepayment);
      this.paidString = this.order.paid ? "Đã thanh toán đủ" : "Chưa thanh toán đủ";
      this.paidStatus = this.order.paid ? "ĐÃ THANH TOÁN" : "CẦN THANH TOÁN";
    })
  }

}
