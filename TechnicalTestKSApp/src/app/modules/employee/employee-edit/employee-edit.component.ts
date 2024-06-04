import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IEmployee } from 'src/app/models/iemployee';
import { IResponse } from 'src/app/models/iresponse';
import { DateSelectService } from 'src/app/services/general-information/date-select.service';
import { NationalityService } from 'src/app/services/general-information/nationality.service';
import { HttpGenericService } from 'src/app/services/http/http-generic.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  
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
    ,private route: ActivatedRoute
  ) { }
  
  ngOnInit(): void {
    this.nationalityService.getNationalities();
    this.dateSelectService.getDateSelect();

    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id')
        if (!id)
          this.cancel()
        else
        {
          this.getEmployee(id)
        }
      }
    })
  }

  getEmployee(id: string): void {
    this.httpService.getById<IResponse>(environment.endpoints.employee.get, id).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) 
        {
          console.log('Success', callResponse)
          this.setup(callResponse.response[0] as IEmployee)
        }          
        else
          console.log('here', callResponse)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  setup(employee: IEmployee): void {
    this.employee = employee
    this.birhtDate = {
      year: this.employee.birthDate.substring(0, 4)
      ,month: this.employee.birthDate.substring(7,5)
      ,day: this.employee.birthDate.substring(10,8)
    }
    console.log('this.birhtDate', this.birhtDate)
  }

  submit(): void {
    this.employee.birthDate = `${this.birhtDate.year}-${this.birhtDate.month}-${this.birhtDate.day}`
    console.log('this.employee', this.employee)
    this.httpService.put<IResponse, IEmployee>(environment.endpoints.employee.update, this.employee).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) 
          this.cancel()
        else
          console.log('here', callResponse)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  delete(): void {
    this.httpService.delete<IResponse>(environment.endpoints.employee.delete, this.employee.employeeId).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess)
          this.cancel()
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
