import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateSpecializationComponent } from './create-specialization/create-specialization.component';
import { UpdateSpecializationComponent } from './update-specialization/update-specialization.component';
import { ViewSpecializationsComponent } from './view-specializations/view-specializations.component';
import { SpecializationsRoutingModule } from './specializations-routing.module';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';



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
    FormsModule
  ]
})
export class SpecializationsModule { }
