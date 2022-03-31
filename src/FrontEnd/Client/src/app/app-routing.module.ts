import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { CreateOrganizationComponent } from './components/organizations/create-organization/create-organization.component';
import { EditOrganizationComponent } from './components/organizations/edit-organization/edit-organization.component';
import { SetSpecOrganizationComponent } from './components/organizations/set-spec-organization/set-spec-organization.component';
import { ViewOrganizationsComponent } from './components/organizations/view-organizations/view-organizations.component';
import { CreateSpecializationComponent } from './components/specializations/create-specialization/create-specialization.component';
import { EditSpecializationComponent } from './components/specializations/edit-specialization/edit-specialization.component';
import { ViewSpecializationsComponent } from './components/specializations/view-specializations/view-specializations.component';

const routes: Routes = [
  { path: "auth", component: AuthComponent },
  { path: "admin/organizations", component: ViewOrganizationsComponent},
  { path: "admin/organizations/create", component: CreateOrganizationComponent},
  { path: "admin/organizations/edit/:id", component: EditOrganizationComponent},
  { path: "admin/organizations/:id/specializations", component: SetSpecOrganizationComponent},
  { path: "admin/specializations", component: ViewSpecializationsComponent},
  { path: "admin/specializations/create", component: CreateSpecializationComponent},
  { path: "admin/specializations/edit/:id", component: EditSpecializationComponent},
  { path: "admin/contacts", component: ContactsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
