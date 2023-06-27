import { Component, OnInit } from '@angular/core';
import { UserModel } from '../GoneModel/UserModel';
import { UserService } from '../GoneService/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  constructor(private Service: UserService) {


  }

  models: UserModel[] = [];
  ngOnInit(): void {
    this.showForEdit()
  }
  showForEdit() {
    debugger;

    this.Service.GetAll().subscribe(data => this.models = data

    )
    console.log(this.models)
  }
  onDelete(id: any) {

    this.Service.Delete(id).subscribe(res => {

      this.showForEdit();
    })

  }

}
