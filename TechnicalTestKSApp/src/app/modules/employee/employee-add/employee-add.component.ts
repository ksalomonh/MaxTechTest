import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IEmployee } from 'src/app/models/iemployee';
import { IResponse } from 'src/app/models/iresponse';
import { DateSelectService } from 'src/app/services/general-information/date-select.service';
import { NationalityService } from 'src/app/services/general-information/nationality.service';
import { HttpGenericService } from 'src/app/services/http/http-generic.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent implements OnInit {
  
  birhtDate: any = {
    year: ''
    ,month: ''
    ,day: ''
  }
  employee: IEmployee = {
    employeeId: 0
    ,employeeNumber: ''
    ,name: ''
    ,lastName: ''
    ,birthDate: '' //(Validar que sea mayor de edad)
    ,curp: ''
    ,ssn: ''
    ,phone: '' //(Validar formato a 10 dígitos)
    ,phoneValue: 0 //(Validar formato a 10 dígitos)
    ,nationalityId: 0
    ,nationalityName: ''
    ,beneficiariesCount: 0
  }

  constructor(
    private httpService: HttpGenericService
    ,public nationalityService: NationalityService
    ,public dateSelectService: DateSelectService
    ,private router: Router
  ) { }
  
  ngOnInit(): void {
    this.nationalityService.getNationalities();
    this.dateSelectService.getDateSelect();
  }

  submit(): void {
    this.employee.birthDate = `${this.birhtDate.year}-${this.birhtDate.month}-${this.birhtDate.day}`
    console.log('this.employee', this.employee)
    this.httpService.post<IResponse, IEmployee>(environment.endpoints.employee.add, this.employee).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) {
          console.log('success', callResponse)
          this.cancel()
        }          
        else
          console.log('here', callResponse)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  cancel(): void {    
    this.router.navigate(['/'])
  }
}
