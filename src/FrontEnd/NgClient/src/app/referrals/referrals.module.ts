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
import { MatDividerModule } from '@angular/material/divider';
import { UpdateReferralComponent } from './update-referral/update-referral.component';
import { ReferralCardComponent } from './referral-card/referral-card.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { UpdatePatientComponent } from './update-patient/update-patient.component';
import { CreateAnamnesisComponent } from './create-anamnesis/create-anamnesis.component';
import { AnamnesisCategoriesPipe } from '../pipes/anamnesis-categories.pipe';
import { ViewAnamnesiesComponent } from './view-anamnesies/view-anamnesies.component';
import { UpdateAnamnesiesComponent } from './update-anamnesies/update-anamnesies.component';
import { AnamnesisTableComponent } from './anamnesis-table/anamnesis-table.component';
import { MatTableModule } from '@angular/material/table';
import { PurposeTableComponent } from './purpose-table/purpose-table.component';
import { CreatePurposeComponent } from './create-purpose/create-purpose.component';
import { PurposeGroupPipe } from '../pipes/purpose-group.pipe';

@NgModule({
  declarations: [
    ViewReferralsComponent,
    CreateReferralComponent,
    PatientGenderPipe,
    ReferralStatusPipe,
    UpdateReferralComponent,
    ReferralCardComponent,
    UpdatePatientComponent,
    CreateAnamnesisComponent,
    AnamnesisCategoriesPipe,
    ViewAnamnesiesComponent,
    UpdateAnamnesiesComponent,
    AnamnesisTableComponent,
    PurposeTableComponent,
    CreatePurposeComponent,
    PurposeGroupPipe
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
    MatNativeDateModule,
    MatDividerModule,
    MatTooltipModule,
    MatTableModule
  ]
})
export class ReferralsModule { }
