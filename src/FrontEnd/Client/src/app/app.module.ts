import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthComponent } from './auth/auth.component';
import { OrganizationListComponent } from './organization/organization-list/organization-list.component';
import { OrganizationDetailComponent } from './organization/organization-detail/organization-detail.component';
import { OrganizationEditComponent } from './organization/organization-edit/organization-edit.component';
import { HttpClientModule } from '@angular/common/http';
import { OrganizationCreateComponent } from './organization/organization-create/organization-create.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    AuthComponent,
    OrganizationListComponent,
    OrganizationDetailComponent,
    OrganizationEditComponent,
    OrganizationCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
