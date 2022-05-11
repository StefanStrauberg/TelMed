import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'admin/organizations', loadChildren: () => import('./organizations/organizations.module')
    .then(mod => mod.OrganizationsModule) },
  { path: 'admin/specializations', loadChildren: () => import('./specializations/specializations.module')
    .then(mod => mod.SpecializationsModule) },
  { path: 'admin/reports', loadChildren: () => import('./reports/reports.module')
    .then(mod => mod.ReportsModule) },
  { path: 'admin/accounts', loadChildren: () => import('./account/account.module')
    .then(mod => mod.AccountModule) },
  { path: 'ereferral', loadChildren: () => import('./referrals/referrals.module')
    .then(mod => mod.ReferralsModule) },
  { path: 'authentication', loadChildren: () => import('./authentication/authentication.module')
    .then(mod => mod.AuthenticationModule) },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
