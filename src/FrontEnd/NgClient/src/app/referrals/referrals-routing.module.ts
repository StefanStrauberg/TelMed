import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ViewReferralsComponent } from './view-referrals/view-referrals.component';

const routes: Routes = [
  { path: '', component: ViewReferralsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ReferralsRoutingModule { }
