import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BeneficiaryAddComponent } from './beneficiary-add/beneficiary-add.component';
import { BeneficiaryEditComponent } from './beneficiary-edit/beneficiary-edit.component';


const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
  },
  {
    path: 'add',
    component: BeneficiaryAddComponent,
  },
  {
    path: 'edit/:id',
    component: BeneficiaryEditComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BeneficiaryRoutingModule { }
