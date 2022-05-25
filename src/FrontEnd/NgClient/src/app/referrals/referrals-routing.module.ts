import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewReferralsComponent } from './view-referrals/view-referrals.component';
import { CreateReferralComponent } from './create-referral/create-referral.component';
import { UpdateReferralComponent } from './update-referral/update-referral.component';
import { UpdatePatientComponent } from './update-patient/update-patient.component';
import { CreateAnamnesisComponent } from './create-anamnesis/create-anamnesis.component';

const routes: Routes = [
  { path: '', component: ViewReferralsComponent },
  { path: 'create', component: CreateReferralComponent },
  { path: 'edit/:id', component: UpdateReferralComponent },
  { path: ':id/patient', component: UpdatePatientComponent },
  { path: 'anamnesis/:id', component: CreateAnamnesisComponent },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ReferralsRoutingModule { }
