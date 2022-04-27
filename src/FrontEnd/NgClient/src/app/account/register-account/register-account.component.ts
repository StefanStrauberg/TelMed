import { Component, OnInit } from '@angular/core';
import { enumValues } from 'src/app/helpers/enum.helper';
import { IRegisterAccount, Role } from 'src/app/shared/models/account';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register-account',
  templateUrl: './register-account.component.html',
  styleUrls: ['./register-account.component.scss']
})
export class RegisterAccountComponent implements OnInit {
  account: IRegisterAccount = {
    userName: "",
    password: "",
    confirmPassword: "",
    firstName: "",
    lastName: "",
    middleName: "",
    role: Role.Врач,
    organizationId: "",
    phoneNumber: "",
    officePhone: "",
    email: "",
    specializationId: ""
  } as IRegisterAccount;
  roles = Role;
  enumValuse = enumValues;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }
}
