import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerDashboardComponent } from './customer-dashboard/customer-dashboard.component';
import { Output, EventEmitter } from '@angular/core';


@NgModule({
  declarations: [CustomerDashboardComponent],
  imports: [
    CommonModule
  ],
  exports: [
    CustomerDashboardComponent
  ]
})
export class CustomerDashboardModule {
  
    @Output() newItemEvent = new EventEmitter<string>();
  
    
  }
 

