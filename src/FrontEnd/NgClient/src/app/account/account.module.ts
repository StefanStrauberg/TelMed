import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterAccountComponent } from './register-account/register-account.component';
import { ViewAccountsComponent } from './view-accounts/view-accounts.component';
import { UpdateAccountComponent } from './update-account/update-account.component';
import { SharedModule } from '../shared/shared.module';
import { AccountRoutingModule } from './account-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    RegisterAccountComponent,
    ViewAccountsComponent,
    UpdateAccountComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    AccountRoutingModule,
    FormsModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule
  ]
})
export class AccountModule { }
