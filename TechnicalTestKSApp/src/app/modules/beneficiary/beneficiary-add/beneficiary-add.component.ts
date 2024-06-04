import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IBeneficiary } from 'src/app/models/ibeneficiary';
import { IResponse } from 'src/app/models/iresponse';
import { DateSelectService } from 'src/app/services/general-information/date-select.service';
import { NationalityService } from 'src/app/services/general-information/nationality.service';
import { HttpGenericService } from 'src/app/services/http/http-generic.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-beneficiary-add',
  templateUrl: './beneficiary-add.component.html',
  styleUrls: ['./beneficiary-add.component.css']
})
export class BeneficiaryAddComponent implements OnInit {
  
  isEditMode: boolean = false
  isEditModeIndexId: number = 0
  
  participationTotal: number = 0
  employeeId: number = 0
  birhtDate: any = {
    year: ''
    ,month: ''
    ,day: ''
  }
  beneficiaries: IBeneficiary[] = []
  activateBeneficiaries: IBeneficiary[] = []
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
    ,nationalityName: 'Mexican'
    ,participationPercentage: 0
    ,IsDeleted: false
    ,indexId: 0
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
        const id = params.get('employeeId')
        if (!id)
          this.cancel()
        else
        {
          this.getBeneficiaries(id)
        }
      }
    })
  }

  getBeneficiaries(employeeId: string): void {
    this.employeeId = +employeeId
    this.cleanBeneficiary()
    this.httpService.getById<IResponse>(environment.endpoints.beneficiary.getAll, employeeId).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) 
        {
          this.beneficiaries = callResponse.response as IBeneficiary[]
          this.mapActiveBeneficiaries()
        }
          
        else
          console.log('here', callResponse)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  mapActiveBeneficiaries(): void {
    let i: number = 0
    this.participationTotal = 0
    this.beneficiaries.map(b => {
      i++
      b.indexId = i
    })
    this.activateBeneficiaries = this.beneficiaries.filter(b => !b.IsDeleted)
    this.activateBeneficiaries.map(b => this.participationTotal += b.participationPercentage)
  }

  cleanBeneficiary(): void {
    this.beneficiary = {
      beneficiaryId: 0
      ,employeeId: this.employeeId
      ,name: ''
      ,lastName: ''
      ,birthDate: ''
      ,curp: ''
      ,ssn: ''
      ,phone: ''
      ,phoneValue: 0
      ,nationalityId: 0
      ,nationalityName: 'Mexican'
      ,participationPercentage: 0
      ,IsDeleted: false
      ,indexId: 0
    }
    this.birhtDate = {
      year: ''
      ,month: ''
      ,day: ''
    }
  }

  add(): void {
    this.beneficiary.birthDate = `${this.birhtDate.year}-${this.birhtDate.month}-${this.birhtDate.day}`
    this.beneficiaries.push(this.beneficiary)
    this.cleanBeneficiary()
    this.mapActiveBeneficiaries()
  }

  setEdit(indexId: number): void {
    this.beneficiaries.map(b => {
      if (b.indexId === indexId) {
        this.isEditMode = true
        this.isEditModeIndexId = indexId
        this.beneficiary = b
        this.birhtDate = {
          year: this.beneficiary.birthDate.substring(0, 4)
          ,month: this.beneficiary.birthDate.substring(7,5)
          ,day: this.beneficiary.birthDate.substring(10,8)
        }
      }
    })
  }

  edit(indexId: number): void {
    this.isEditMode = false
    this.isEditModeIndexId = 0
    this.cleanBeneficiary()
    this.mapActiveBeneficiaries()
  }

  delete(indexId: number): void {
    this.beneficiaries.map(b => {
      if (b.indexId === indexId) b.IsDeleted = true
    })
    this.mapActiveBeneficiaries()
  }

  submit(): void {
    this.httpService.post<IResponse, IBeneficiary[]>(environment.endpoints.beneficiary.add, this.beneficiaries).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        if (callResponse.isSuccess) {
          console.log('success', callResponse)
          if (this.participationTotal == 100)
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
    this.router.navigate([`/beneficiaries/${this.employeeId}`])
  }
}
