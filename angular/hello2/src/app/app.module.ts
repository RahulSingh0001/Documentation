import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
// import the feature module here so you can add it to the imports array below
import { CustomerDashboardModule } from './customer-dashboard/customer-dashboard.module';
import { CounterComponent } from './counter/counter.component';
import { HeropipeComponent } from './heropipe/heropipe.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { MyTestServiceService } from './my-test-service.service';
import { ViewChildComponent } from './view-child/view-child.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,
    HeropipeComponent,
    AboutUsComponent,
    ViewChildComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    CustomerDashboardModule // add the feature module here
  ],
  providers: [MyTestServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }




