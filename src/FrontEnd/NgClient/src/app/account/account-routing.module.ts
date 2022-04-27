import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterAccountComponent } from './register-account/register-account.component';
import { UpdateAccountComponent } from './update-account/update-account.component';
import { ViewAccountsComponent } from './view-accounts/view-accounts.component';

const routes: Routes = [
  { path: '', component: ViewAccountsComponent },
  { path: 'create', component: RegisterAccountComponent },
  { path: 'edit/:id', component: UpdateAccountComponent },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
