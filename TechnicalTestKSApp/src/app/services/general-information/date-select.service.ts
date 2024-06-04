import { Injectable } from '@angular/core';
import { HttpGenericService } from '../http/http-generic.service';
import { environment } from 'src/environments/environment.development';
import { IResponse } from 'src/app/models/iresponse';
import { IDateSelect } from 'src/app/models/idateselect';

@Injectable({
  providedIn: 'root'
})
export class DateSelectService {

  dateSelect: IDateSelect = {
    years: []
    ,months: []
    ,days: []
  }

  constructor(
    private httpService: HttpGenericService
  ) { }

  getDateSelect(): void {
    this.httpService.get(environment.endpoints.generalInformation.getDateSelect).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        console.log('getDateSelect', callResponse)
        if (callResponse.isSuccess)
          this.dateSelect = callResponse.response as IDateSelect
        else
          this.dateSelect = {
            years: []
            ,months: []
            ,days: []
          }
      },
      error: (error) => {
        console.log(error)
        this.dateSelect = {
          years: []
          ,months: []
          ,days: []
        }
      }
    })
  }
}
