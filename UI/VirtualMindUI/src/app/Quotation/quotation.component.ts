import { Component, OnInit } from '@angular/core';
import { QuotationService } from '../_services/quotation.service';

@Component({
  selector: 'app-quotation',
  templateUrl: './quotation.component.html',
  styleUrls: ['./quotation.component.css']
})
export class QuotationComponent implements OnInit {
  [x: string]: any;

  quotationDolar: any;
  quotationReal: any;
  errorDolar: any;
  errorReal: any;
  constructor(private quotation: QuotationService) {
    
  }
 
  ngOnInit() {
    this.getQuotations();
  }

  getQuotations(){
    this.quotationDolar= this.quotationReal= null;
    this.quotation.getQuotation("dolar").subscribe(
      body => {this.quotationDolar = body},
      error=>{ this.errorReal= error.text  }
    );
    this.quotation.getQuotation("real").subscribe(
      body => {this.quotationReal = body},
    error=>{ this.errorReal= error.text }
    );
  }
}
