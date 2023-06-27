import { Component, OnInit } from '@angular/core';
import { EmpModel } from '../GoneModel/EmpModel';
import { EmpService } from '../GoneService/emp.service';

@Component({
  selector: 'app-emp',
  templateUrl: './emp.component.html',
  styleUrls: ['./emp.component.css']
})
export class EmpComponent implements OnInit {

  constructor(private empService: EmpService) {


  }
  allemp: EmpModel[] =[];
  ngOnInit(): void {
    this.showForEdit()
  }
  showForEdit() {
    debugger;

    this.empService.GetAll().subscribe(data => this.allemp = data
      
    )
    console.log(this.allemp)
  }
  onDelete(EmpId: any) {

    this.empService.Delete(EmpId).subscribe(res => {

      this.showForEdit();
    })

  }

}
