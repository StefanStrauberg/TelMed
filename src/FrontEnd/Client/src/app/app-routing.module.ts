import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { OrganizationCreateComponent } from './organization/organization-create/organization-create.component';
import { OrganizationEditComponent } from './organization/organization-edit/organization-edit.component';
import { OrganizationListComponent } from './organization/organization-list/organization-list.component';

const routes: Routes = [
  { path:'auth', component: AuthComponent },
  { path:'organizations', component: OrganizationListComponent },
  { path:'organizations/create', component: OrganizationCreateComponent },
  { path:'organizations/edit/:id', component: OrganizationEditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
