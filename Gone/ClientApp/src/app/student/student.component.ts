import { Component, OnInit } from '@angular/core';
import { StudentModel } from '../GoneModel/Student';
import { StudentService } from '../GoneService/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor(private Service: StudentService) {


  }
  models: StudentModel[] = [];
  ngOnInit(): void {
    this.showForEdit()
  }
  showForEdit() {
    debugger;

    this.Service.GetAll().subscribe(data => this.models = data

    )
    console.log(this.models)
  }
  onDelete(EmpId: any) {

    this.Service.Delete(EmpId).subscribe(res => {

      this.showForEdit();
    })

  }

}
