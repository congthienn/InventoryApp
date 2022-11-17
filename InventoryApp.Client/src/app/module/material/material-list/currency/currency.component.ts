import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.css']
})
export class CurrencyComponent implements ICellRendererAngularComp {
  public params: any;

  agInit(params: any): void {
      this.params = params;
  }

  refresh(params: { value: any; }): boolean {
      if(params.value !== this.params.value) {
          this.params = params;
      }
      return true;
  }
}