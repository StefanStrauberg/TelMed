import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateOrganizationComponent } from './create-organization/create-organization.component';
import { UpdateOrganizationComponent } from './update-organization/update-organization.component';
import { ViewOrganizationsComponent } from './view-organizations/view-organizations.component';
import { OrganizationsRoutingModule } from './organizations-routing.module';
import { SpecOrganizationComponent } from './spec-organization/spec-organization.component';
import { FormsModule } from '@angular/forms';
import { OrgRegPipe } from '../pipes/org-reg.pipe';
import { OrgLevPipe } from '../pipes/org-lev.pipe';
import { SharedModule } from '../shared/shared.module';
import { MatTableModule } from '@angular/material/table'
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    CreateOrganizationComponent,
    UpdateOrganizationComponent,
    ViewOrganizationsComponent,
    SpecOrganizationComponent,
    OrgRegPipe,
    OrgLevPipe
  ],
  imports: [
    CommonModule,
    OrganizationsRoutingModule,
    FormsModule,
    SharedModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatPaginatorModule
  ]
})
export class OrganizationsModule { }
