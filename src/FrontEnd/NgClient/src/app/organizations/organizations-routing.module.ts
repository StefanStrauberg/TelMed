import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateOrganizationComponent } from './create-organization/create-organization.component';
import { SpecOrganizationComponent } from './spec-organization/spec-organization.component';
import { UpdateOrganizationComponent } from './update-organization/update-organization.component';
import { ViewOrganizationsComponent } from './view-organizations/view-organizations.component';

const routes: Routes = [
  { path: '', component: ViewOrganizationsComponent },
  { path: 'create', component: CreateOrganizationComponent },
  { path: 'edit/:id', component: UpdateOrganizationComponent },
  { path: ':id/specializations', component: SpecOrganizationComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrganizationsRoutingModule { }
