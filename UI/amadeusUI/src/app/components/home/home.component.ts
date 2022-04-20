import { Component, OnInit } from '@angular/core';
import { Service } from '../../amadeus';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  departments: any = {};
  arls: any = {};
  epss: any = {};
  constructor(private amadeus: Service) { }

  ngOnInit(): void {
  }
  
  GetDepartments(){
    this.amadeus.GetDepartments().subscribe(data => {
      console.log(data);
      this.departments = data;
    });
  }

  GetARLs(){
    this.amadeus.GetARLs().subscribe(data => {
      console.log(data);
      this.arls = data;
    });
  }

  GetEPSs(){
    this.amadeus.GetEPSs().subscribe(data => {
      console.log(data);
      this.epss = data;
    });
  }
}
