import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OrganizationsService } from 'src/app/organizations/organizations.service';
import { IRole } from 'src/app/shared/models/account';
import { IShortOrganization } from 'src/app/shared/models/organization';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register-account',
  templateUrl: './register-account.component.html',
  styleUrls: ['./register-account.component.scss']
})
export class RegisterAccountComponent implements OnInit {
  ownerForm!: FormGroup;
  roles: IRole[] = [];
  shortOrganizations: IShortOrganization[] = [];

  constructor(
    private organizationService: OrganizationsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.getRoles().subscribe(roles => {
      this.roles = roles;
      this.organizationService.getShortOrganizations().subscribe(shortOrganizations => {
        this.shortOrganizations = shortOrganizations;
      }, (error) => {
        this.router.navigate(['/']).then();
        console.log(error);
      })
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
    this.ownerForm = this.formBuilder.group({
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      firstName: new FormControl('', Validators.required),
      middleName: new FormControl('', Validators.required),
      role: new FormControl('', Validators.required),
      organizationId: new FormControl('', Validators.required),
      phoneNumber: new FormControl('', Validators.required),
      officePhone: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      specializationId: new FormControl('', Validators.required),
    });
  }
}
