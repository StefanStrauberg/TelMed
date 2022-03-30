import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { AuthComponent } from './components/auth/auth.component';
import { ViewOrganizationsComponent } from './components/organizations/view-organizations/view-organizations.component';
import { EditOrganizationComponent } from './components/organizations/edit-organization/edit-organization.component';
import { CreateOrganizationComponent } from './components/organizations/create-organization/create-organization.component';
import { SetSpecOrganizationComponent } from './components/organizations/set-spec-organization/set-spec-organization.component';
import { CreateSpecializationComponent } from './components/specializations/create-specialization/create-specialization.component';
import { ViewSpecializationsComponent } from './components/specializations/view-specializations/view-specializations.component';
import { EditSpecializationComponent } from './components/specializations/edit-specialization/edit-specialization.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    AuthComponent,
    ViewOrganizationsComponent,
    EditOrganizationComponent,
    CreateOrganizationComponent,
    SetSpecOrganizationComponent,
    CreateSpecializationComponent,
    ViewSpecializationsComponent,
    EditSpecializationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
