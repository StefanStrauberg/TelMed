import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateSpecializationComponent } from './create-specialization/create-specialization.component';
import { UpdateSpecializationComponent } from './update-specialization/update-specialization.component';
import { ViewSpecializationsComponent } from './view-specializations/view-specializations.component';

const routes: Routes = [
  { path: '', component: ViewSpecializationsComponent },
  { path: 'create', component: CreateSpecializationComponent },
  { path: 'edit/:id', component: UpdateSpecializationComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)    
  ],
  exports: [RouterModule]
})
export class SpecializationsRoutingModule { }
