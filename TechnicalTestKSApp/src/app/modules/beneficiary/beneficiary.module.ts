import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BeneficiaryRoutingModule } from './beneficiary-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BeneficiaryListComponent } from './beneficiary-list/beneficiary-list.component';
import { BeneficiaryAddComponent } from './beneficiary-add/beneficiary-add.component';
import { BeneficiaryEditComponent } from './beneficiary-edit/beneficiary-edit.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DashboardComponent,
    BeneficiaryListComponent,
    BeneficiaryAddComponent,
    BeneficiaryEditComponent
  ],
  imports: [
    CommonModule,
    BeneficiaryRoutingModule,
    FormsModule
  ]
})
export class BeneficiaryModule { }
