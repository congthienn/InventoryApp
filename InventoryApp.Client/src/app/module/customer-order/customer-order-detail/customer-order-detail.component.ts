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
      this.loadData = false;
    })
  }

}
