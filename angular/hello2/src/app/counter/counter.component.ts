import { MyTestServiceService } from './../my-test-service.service';
import { Component, OnInit, Input,Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent implements OnInit {
  @Input() items: any;



  
  @Output() newItemEvent = new EventEmitter<string>();
  addNewItem(value: string) {
    this.newItemEvent.emit(value);
  }




  serviceMssg="";
  constructor(private myService:MyTestServiceService) { }

  ngOnInit(): void {
    this.myService.currentMessage.subscribe(data=>{console.log('data',data);
  this.serviceMssg=data;
  })
   
  }

}
