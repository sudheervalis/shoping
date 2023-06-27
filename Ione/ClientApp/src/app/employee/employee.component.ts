import { Component, OnInit } from '@angular/core';
import { EmpModel } from '../IoneModel/EmpModel';
import { EmpService } from '../IoneService/emp.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private empService: EmpService) {


  }
  empModel?: EmpModel;
  ngOnInit(): void {
    this.showForEdit() 
  }
  showForEdit() {

    this.empService.GetAll().subscribe(data => this.empModel = data)

  }
  onDelete(EmpId: any) {

    this.empService.Delete(EmpId).subscribe(res => {

      this.showForEdit();
    })

  }

}
