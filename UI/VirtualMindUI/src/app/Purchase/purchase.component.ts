import { Component, OnInit } from '@angular/core';
import { PurchaseService } from '../_services/purchase.service';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
model: any = {};
showProgressBar = false;
purchaseError = false;
purchaseResponce : any;
errorMessage : any;

transacciones: any = [];
  constructor(private purchase: PurchaseService) { }

  ngOnInit() {

  }

  Purchase(){
    this.showProgressBar = true;
    this.purchase.AddPurchase(this.model).subscribe(response => {
      this.purchaseResponce = response;
      this.purchaseError=false;
      this.showProgressBar = false;

    }, error => {
      console.log(error);
      this.errorMessage = error
      this.purchaseError= true;
      this.showProgressBar = false;
    });
  }
}
