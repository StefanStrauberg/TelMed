import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewReportsComponent } from './view-reports/view-reports.component';
import { Report1Component } from './report1/report1.component';
import { Report2Component } from './report2/report2.component';
import { Report3Component } from './report3/report3.component';
import { Report4Component } from './report4/report4.component';
import { Report5Component } from './report5/report5.component';
import { Report6Component } from './report6/report6.component';
import { ReportsRoutingModule } from './reports-routing.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ViewReportsComponent,
    Report1Component,
    Report2Component,
    Report3Component,
    Report4Component,
    Report5Component,
    Report6Component
  ],
  imports: [
    CommonModule,
    ReportsRoutingModule,
    FormsModule
  ]
})
export class ReportsModule { }
