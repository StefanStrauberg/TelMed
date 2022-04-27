import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterAccountComponent } from './register-account/register-account.component';
import { ViewAccountsComponent } from './view-accounts/view-accounts.component';
import { UpdateAccountComponent } from './update-account/update-account.component';
import { SharedModule } from '../shared/shared.module';
import { AccountRoutingModule } from './account-routing.module';
import { FormsModule } from '@angular/forms';
import { RolesPipe } from '../pipes/roles.pipe';



@NgModule({
  declarations: [
    RegisterAccountComponent,
    ViewAccountsComponent,
    UpdateAccountComponent,
    RolesPipe
  ],
  imports: [
    CommonModule,
    SharedModule,
    AccountRoutingModule,
    FormsModule
  ]
})
export class AccountModule { }
