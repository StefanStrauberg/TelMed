import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { CreateOrganizationComponent } from './components/organizations/create-organization/create-organization.component';
import { EditOrganizationComponent } from './components/organizations/edit-organization/edit-organization.component';
import { SetSpecOrganizationComponent } from './components/organizations/set-spec-organization/set-spec-organization.component';
import { ViewOrganizationsComponent } from './components/organizations/view-organizations/view-organizations.component';

const routes: Routes = [
  { path: "auth", component: AuthComponent },
  { path: "admin/organizations", component: ViewOrganizationsComponent},
  { path: "admin/organizations/create", component: CreateOrganizationComponent},
  { path: "admin/organizations/edit/:{id}", component: EditOrganizationComponent},
  { path: "admin/organizations/:{id}/specializations", component: SetSpecOrganizationComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
