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
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { PatientGenderPipe } from '../pipes/patient-gender.pipe';
import { ReferralStatusPipe } from '../pipes/referral-status.pipe';

@NgModule({
  declarations: [
    ViewReferralsComponent,
    CreateReferralComponent,
    PatientGenderPipe,
    ReferralStatusPipe
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
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule
  ]
})
export class ReferralsModule { }
