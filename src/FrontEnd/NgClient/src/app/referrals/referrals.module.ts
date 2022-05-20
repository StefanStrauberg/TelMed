import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewReferralsComponent } from './view-referrals/view-referrals.component';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { ReferralsRoutingModule } from './referrals-routing.module';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CreateReferralComponent } from './create-referral/create-referral.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    ViewReferralsComponent,
    CreateReferralComponent
  ],
  imports: [
    CommonModule,
    ReferralsRoutingModule,
    RouterModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule
  ],
  exports: [
    ViewReferralsComponent
  ]
})
export class ReferralsModule { }
