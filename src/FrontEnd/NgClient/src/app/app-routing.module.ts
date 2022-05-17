import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { HomeComponent } from './home/home.component';
import { SigninRedirectCallbackComponent } from './signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './signout-redirect-callback/signout-redirect-callback.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'signin-callback', component: SigninRedirectCallbackComponent },
  { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
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
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
