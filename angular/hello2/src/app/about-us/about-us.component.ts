import { Component, OnInit } from '@angular/core';
import { MyTestServiceService } from '../my-test-service.service';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {
  messages:any;

  constructor(private myService:MyTestServiceService) { }

  ngOnInit(): void {
  }
  clickMe()
  {
    this.messages= this.myService.changeMessage('My new message');
  }

}
