import { Component, Input, OnInit } from '@angular/core';
import { CompanyService } from '../../general/company.service';
import { Order } from '../model/order';
import { OrderService } from '../service/order.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnInit {

  @Input() id:any;
  public loadData = false;
  public company:any;
  public dateOrder:any;
  public order!:Order;
  constructor(private companyService: CompanyService,
      private orderService: OrderService
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
    this.orderService.getOrderByCode(id).subscribe(response =>{
      this.order = response;
      let date = new Date(this.order.orderDate);
      this.dateOrder = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
      this.order.supplierOrderDetail.forEach((item) => {
          item.priceTotalItem = Number(item.materialPrice) * Number(item.quantityRequest);
      })
      this.loadData = false;
    })
  }

}
