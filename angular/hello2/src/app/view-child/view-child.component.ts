import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-child',
  templateUrl: './view-child.component.html',
  styleUrls: ['./view-child.component.css']
})
export class ViewChildComponent implements OnInit {
 
message:any;
  constructor() { }

  ngOnInit(): void {
  }
  clicks(){
    this.message('Rahul');

  }

}
