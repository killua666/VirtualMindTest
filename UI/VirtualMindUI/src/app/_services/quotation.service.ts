import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuotationService {
  baseUrl = '/api/Quotation/CurrencyRate/';
  cotizacion: any;
  constructor(private http: HttpClient) { }

  getQuotation(unit: any): Observable<any> {
    
  return this.http.get(this.baseUrl + unit);
  }
}
