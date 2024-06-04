import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';  

import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { FormsModule } from '@angular/forms';
import { EmployeeAddComponent } from './employee-add/employee-add.component';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';

@NgModule({
  declarations: [
    DashboardComponent,
    EmployeeListComponent,
    EmployeeAddComponent,
    EmployeeEditComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    FormsModule
  ]
})
export class EmployeeModule { }
