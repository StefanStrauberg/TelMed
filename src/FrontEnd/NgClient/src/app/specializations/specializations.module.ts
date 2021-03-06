import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateSpecializationComponent } from './create-specialization/create-specialization.component';
import { UpdateSpecializationComponent } from './update-specialization/update-specialization.component';
import { ViewSpecializationsComponent } from './view-specializations/view-specializations.component';
import { SpecializationsRoutingModule } from './specializations-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTooltipModule } from '@angular/material/tooltip';



@NgModule({
  declarations: [
    CreateSpecializationComponent,
    UpdateSpecializationComponent,
    ViewSpecializationsComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    SpecializationsRoutingModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
    MatPaginatorModule,
    MatCardModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatTooltipModule
  ]
})
export class SpecializationsModule { }
