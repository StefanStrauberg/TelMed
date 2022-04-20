import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'admin/organizations', loadChildren: () => import('./organizations/organizations.module')
    .then(mod => mod.OrganizationsModule) },
    { path: 'admin/specializations', loadChildren: () => import('./specializations/specializations.module')
    .then(mod => mod.SpecializationsModule) },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
