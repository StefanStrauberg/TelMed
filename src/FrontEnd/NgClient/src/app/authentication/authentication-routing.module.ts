import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterUserComponent } from './register-user/register-user.component';
import { ViewAccountsComponent } from './view-accounts/view-accounts.component';

const routes: Routes = [
  { path: '', component: ViewAccountsComponent },
  { path: 'create', component: RegisterUserComponent },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class AuthenticationRoutingModule { }
