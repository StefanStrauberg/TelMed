import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateOrganizationComponent } from './create-organization/create-organization.component';
import { UpdateOrganizationComponent } from './update-organization/update-organization.component';
import { ViewOrganizationsComponent } from './view-organizations/view-organizations.component';
import { OrganizationsRoutingModule } from './organizations-routing.module';



@NgModule({
  declarations: [
    CreateOrganizationComponent,
    UpdateOrganizationComponent,
    ViewOrganizationsComponent
  ],
  imports: [
    CommonModule,
    OrganizationsRoutingModule
  ]
})
export class OrganizationsModule { }
