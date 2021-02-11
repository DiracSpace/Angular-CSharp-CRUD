import { Component } from '@angular/core';
import { ApiService } from '../provider/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [],
})
export class HomeComponent {
  title = 'Personas';
  persons = [];

  constructor(private api: ApiService) {
    this.getAllPeople();
  }

  getAllPeople = () => {
    this.api.getAll().subscribe(
      (data: any) => {
        this.persons = data;
      },
      (error: any) => {
        console.log(error);
      }
    )
  }
}
