import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map, catchError} from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  baseUrl = '/api/Purchase/Purchase';
  cotizacion: any;
  handleError: any;
  constructor(private http: HttpClient) { }

  AddPurchase(model: any): Observable<any>{
    return this.http.post(this.baseUrl, model);
  }
}
