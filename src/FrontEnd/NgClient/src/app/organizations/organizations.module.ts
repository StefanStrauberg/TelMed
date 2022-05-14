import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateOrganizationComponent } from './create-organization/create-organization.component';
import { UpdateOrganizationComponent } from './update-organization/update-organization.component';
import { ViewOrganizationsComponent } from './view-organizations/view-organizations.component';
import { OrganizationsRoutingModule } from './organizations-routing.module';
import { SpecOrganizationComponent } from './spec-organization/spec-organization.component';
import { OrgRegPipe } from '../pipes/org-reg.pipe';
import { OrgLevPipe } from '../pipes/org-lev.pipe';
import { SharedModule } from '../shared/shared.module';
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import { ReactiveFormsModule } from '@angular/forms';

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
    SharedModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
    MatPaginatorModule,
    MatCardModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatDividerModule
  ]
})
export class OrganizationsModule { }
