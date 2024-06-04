import { Injectable } from '@angular/core';
import { HttpGenericService } from '../http/http-generic.service';
import { environment } from 'src/environments/environment.development';
import { INationality } from 'src/app/models/inationality';
import { IResponse } from 'src/app/models/iresponse';

@Injectable({
  providedIn: 'root'
})
export class NationalityService {

  nationalities: INationality[] = []

  constructor(
    private httpService: HttpGenericService
  ) { }

  getNationalities(): void {
    this.httpService.get(environment.endpoints.generalInformation.getNationalities).subscribe({
      next: (cR) => {
        let callResponse = cR as IResponse;
        console.log('getNationalities', callResponse)
        if (callResponse.isSuccess)
          this.nationalities = callResponse.response as INationality[]
        else
          this.nationalities = []
      },
      error: (error) => {
        console.log(error)
        this.nationalities = []
      }
    })
  }
}
