import { Component, OnInit } from '@angular/core';
import { IBeneficiary } from '../../../models/ibeneficiary';
import { HttpGenericService } from 'src/app/services/http/http-generic.service';
import { environment } from 'src/environments/environment.development';
import { IResponse } from 'src/app/models/iresponse';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-beneficiary-list',
  templateUrl: './beneficiary-list.component.html',
  styleUrls: ['./beneficiary-list.component.css']
})
export class BeneficiaryListComponent implements OnInit {

  beneficiaries: IBeneficiary[] = []

  constructor(
    private httpService: HttpGenericService
    ,private router: Router
    ,private route: ActivatedRoute
  ) { }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('employeeId')
        if (!id)
          this.router.navigate(['/'])
        else
        {
          this.getBeneficiaries(id)          
        }
      }
    })
  }

  getBeneficiaries(employeeId: string): void {
    this.httpService.getById<IResponse>(environment.endpoints.beneficiary.getAll, employeeId).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) 
          this.beneficiaries = callResponse.response as IBeneficiary[]
        else
          console.log('here', callResponse)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }
}
