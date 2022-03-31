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
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { OrgRegPipe } from './pipes/org-reg.pipe';
import { OrgLevPipe } from './pipes/org-lev.pipe';

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
    EditSpecializationComponent,
    OrgRegPipe,
    OrgLevPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
