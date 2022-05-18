import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OrganizationsService } from 'src/app/organizations/organizations.service';
import { IRole } from 'src/app/shared/models/account';
import { IShortOrganization } from 'src/app/shared/models/organization';
import { IShortSpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from 'src/app/specializations/specializations.service';
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
  shortSpecializations: IShortSpecialization[] = [];
  hidePassword = true;
  hideConfirmPassword = true;

  constructor(
    private specializationService: SpecializationsService,
    private organizationService: OrganizationsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.getRoles();
    this.getShortOrganizations();
    this.getShortSpecializations();
    this.ownerForm = this.formBuilder.group({
      userName: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.pattern('^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z]).{8,}$')]),
      confirmPassword: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      firstName: new FormControl('', Validators.required),
      middleName: new FormControl('', Validators.required),
      role: new FormControl('', Validators.required),
      organizationId: new FormControl('', Validators.required),
      phoneNumber: new FormControl(''),
      officePhone: new FormControl(''),
      email: new FormControl(''),
      specializationId: new FormControl('', Validators.required),
    });
  }

  private getRoles() {
    this.accountService.getRoles('Api/Role').subscribe(response => {
      this.roles = response;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  private getShortOrganizations() {
    this.organizationService.getShortOrganizations('Organization/GetShort').subscribe(response => {
      this.shortOrganizations = response?.body!;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  private getShortSpecializations() {
    this.specializationService.getShortSpecializations('Specialization/GetShort').subscribe(response => {
      this.shortSpecializations = response?.body!;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  public createAccount(){
    if(this.ownerForm.valid)
    {
      this.accountService.createAccount('Api/Register',this.ownerForm.value).subscribe((data: {}) => {
        this.router.navigate(['/admin/accounts']).then();
      }, (error) => {
        this.router.navigate(['/admin/accounts/create']).then();
      })
    }
  }
}
