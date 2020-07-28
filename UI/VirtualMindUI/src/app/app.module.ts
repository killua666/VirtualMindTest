import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { QuotationComponent } from './Quotation/quotation.component';
import { PurchaseComponent } from './Purchase/purchase.component';
import { NavComponent } from './nav/nav.component';
import { PurchaseService } from './_services/purchase.service';
import { QuotationService } from './_services/quotation.service';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule} from '@angular/material/tabs';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';

@NgModule({
   declarations: [
      AppComponent,
      QuotationComponent,
      PurchaseComponent,
      NavComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      CommonModule,
      FormsModule,
      MatTabsModule,
      MatProgressSpinnerModule,
      RouterModule.forRoot(appRoutes),
      BrowserAnimationsModule,
      MatButtonModule,
      MatIconModule,
      MatFormFieldModule,
      MatSelectModule,
      MatInputModule,
      MatDividerModule,
      MatProgressBarModule,
      MatListModule,
      MatCardModule
   ],
   providers: [
      PurchaseService,
      QuotationService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
