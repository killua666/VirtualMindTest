import {Routes} from '@angular/router';
import {QuotationComponent} from './Quotation/quotation.component';
import {PurchaseComponent} from './Purchase/purchase.component';


export const appRoutes: Routes = [
    { path: 'cotizaciones', component: QuotationComponent },
    { path: 'compra', component: PurchaseComponent },
    { path: '**', redirectTo: 'cotizaciones', pathMatch: 'full' },
];