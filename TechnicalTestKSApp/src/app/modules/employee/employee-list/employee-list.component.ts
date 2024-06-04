import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../../../models/iemployee';
import { HttpGenericService } from 'src/app/services/http/http-generic.service';
import { environment } from 'src/environments/environment.development';
import { IResponse } from 'src/app/models/iresponse';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  
  employees: IEmployee[] = []

  constructor(private httpService: HttpGenericService) { }
  
  ngOnInit(): void {
    this.httpService.get<IResponse>(environment.endpoints.employee.getAll).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) 
          this.employees = callResponse.response as IEmployee[]
        else
          console.log('here', callResponse)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }
}
