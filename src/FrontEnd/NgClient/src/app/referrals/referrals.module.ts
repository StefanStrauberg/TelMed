import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewReferralsComponent } from './view-referrals/view-referrals.component';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { ReferralsRoutingModule } from './referrals-routing.module';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [
    ViewReferralsComponent
  ],
  imports: [
    CommonModule,
    ReferralsRoutingModule,
    RouterModule,
    MatTabsModule,
    MatCardModule
  ],
  exports: [
    ViewReferralsComponent
  ]
})
export class ReferralsModule { }
