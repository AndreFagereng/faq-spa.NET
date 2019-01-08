import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { FaqComponent } from './FAQ/FAQ.component';
import { NavMenuLeft } from './nav-left/nav-left';
import { CustomerFaqComponent } from './customerfaq/customer-faq.component'

@NgModule({
  declarations: [
    AppComponent,
    FaqComponent,
    NavMenuLeft,
    CustomerFaqComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    HttpModule,
    JsonpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: FaqComponent, pathMatch: 'full' },
      { path: 'nav', component: NavMenuLeft},
      { path: 'FAQ', component: FaqComponent},
      { path: 'CustomerFAQ', component: CustomerFaqComponent}
     
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
