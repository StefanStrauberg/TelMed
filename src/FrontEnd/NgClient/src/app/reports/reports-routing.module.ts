import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewReportsComponent } from './view-reports/view-reports.component';
import { Report1Component } from './report1/report1.component';
import { Report2Component } from './report2/report2.component';
import { Report3Component } from './report3/report3.component';
import { Report4Component } from './report4/report4.component';
import { Report5Component } from './report5/report5.component';
import { Report6Component } from './report6/report6.component';

const routes: Routes = [
  { path: '', component: ViewReportsComponent },
  { path: 'form-1a', component: Report1Component },
  { path: 'form-1b', component: Report2Component },
  { path: 'form-2a', component: Report3Component },
  { path: 'form-2b', component: Report4Component },
  { path: 'form-3a', component: Report5Component },
  { path: 'form-3b', component: Report6Component },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ReportsRoutingModule { }
