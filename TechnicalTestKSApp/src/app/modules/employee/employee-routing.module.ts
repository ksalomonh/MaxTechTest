import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeeAddComponent } from './employee-add/employee-add.component';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
  },
  {
    path: 'add',
    component: EmployeeAddComponent,
  },
  {
    path: 'edit/:id',
    component: EmployeeEditComponent,
  },
  {
    path: 'beneficiaries/:employeeId',
    loadChildren: () => import('../beneficiary/beneficiary.module').then(x => x.BeneficiaryModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
