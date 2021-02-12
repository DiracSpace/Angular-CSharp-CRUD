import { Component, NgModule } from '@angular/core';
import { ApiService } from '../provider/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [],
})

export class HomeComponent {
  title = 'Personas';
  persons = [];

  person;
  constructor(private api: ApiService) {
    this.getAllPeople();
    this.person = {
      id: 0,
      name: '',
      lastName: '',
      age: 0,
      email: '',
      direction: ''
    }
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

  selectedPerson = (id: any) => {
    this.api.getPersonById(id).subscribe(
      (data: any) => {
        console.log(data);
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  eliminarPersona = (id: any) => {
    this.api.erasePerson(id).subscribe(
      (data: any) => {
        this.getAllPeople();
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  
  onclickSetEditPerson = (id: any) => {
    this.api.getPersonById(id).subscribe(
      (data: any) => {
        this.person = data;
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  onClickRegisterPerson = (person: any) => {
    this.api.registerPerson(person).subscribe(
      (data: any) => {
        this.getAllPeople();
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  onClickEditPerson = (person: any) => {
    console.log(person);
  }
}
