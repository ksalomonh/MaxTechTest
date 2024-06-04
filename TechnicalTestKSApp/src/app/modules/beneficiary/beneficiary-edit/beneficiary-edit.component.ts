import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IBeneficiary } from 'src/app/models/ibeneficiary';
import { IResponse } from 'src/app/models/iresponse';
import { NationalityService } from 'src/app/services/general-information/nationality.service';
import { HttpGenericService } from 'src/app/services/http/http-generic.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-beneficiary-edit',
  templateUrl: './beneficiary-edit.component.html',
  styleUrls: ['./beneficiary-edit.component.css']
})
export class BeneficiaryEditComponent implements OnInit {
  
  beneficiary: IBeneficiary = {
    beneficiaryId: 0
    ,employeeId: 0
    ,name: ''
    ,lastName: ''
    ,birthDate: '' //(Validar que sea mayor de edad)
    ,curp: ''
    ,ssn: ''
    ,phone: '' //(Validar formato a 10 dígitos)
    ,phoneValue: 0 //(Validar formato a 10 dígitos)
    ,nationalityId: 0
    ,nationalityName: ''
    ,participationPercentage: 0
    ,indexId: 0
    ,IsDeleted: false
  }


  constructor(
    private httpService: HttpGenericService    
    ,public nationalityService: NationalityService
    ,private router: Router
    ,private route: ActivatedRoute
  ) { }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id')
        if (!id)
          this.cancel()
        else
        {
          this.nationalityService.getNationalities();
          this.getbeneficiary(id)
        }
      }
    })
  }

  getbeneficiary(id: string): void {
    this.httpService.getById<IResponse>(environment.endpoints.beneficiary.get, id).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) 
        {
          console.log('Success', callResponse)
          this.beneficiary = callResponse.response[0] as IBeneficiary
        }          
        else
          console.log('here', callResponse)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  submit(): void {
    this.httpService.put<IResponse, IBeneficiary>(environment.endpoints.beneficiary.update, this.beneficiary).subscribe({
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
    this.httpService.delete<IResponse>(environment.endpoints.beneficiary.delete, this.beneficiary.beneficiaryId).subscribe({
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
    this.router.navigate(['/beneficiaries'])
  }
}
