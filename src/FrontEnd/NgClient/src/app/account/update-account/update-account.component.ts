import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { OrganizationsService } from 'src/app/organizations/organizations.service';
import { IAccount, IRole } from 'src/app/shared/models/account';
import { IShortOrganization } from 'src/app/shared/models/organization';
import { IShortSpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from 'src/app/specializations/specializations.service';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-update-account',
  templateUrl: './update-account.component.html',
  styleUrls: ['./update-account.component.scss']
})
export class UpdateAccountComponent implements OnInit { 
  ownerForm!: FormGroup;
  roles: IRole[] = [];
  shortOrganizations: IShortOrganization[] = [];
  shortSpecializations: IShortSpecialization[] = [];
  accountId: string | null = null;
  fullUserName: string = '';
  
  constructor(
    private specializationService: SpecializationsService,
    private organizationService: OrganizationsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.accountId = param.get('id');
    });
    if(this.accountId)
    {
      this.getAccountById(this.accountId);
      this.getRoles();
      this.getShortOrganizations();
      this.getShortSpecializations();
    }
  }

  private getAccountById(id: string) {
    this.accountService.getAccount(`Api/Account/${id}`).subscribe((response: IAccount) => {
      this.fullUserName = response.lastName + ' ' + response.firstName + ' ' + response.middleName;
      this.ownerForm = this.ownerForm = this.formBuilder.group({
        userName: new FormControl(response.userName, Validators.required),
        lastName: new FormControl(response.lastName, Validators.required),
        firstName: new FormControl(response.firstName, Validators.required),
        middleName: new FormControl(response.middleName, Validators.required),
        role: new FormControl(response.role, Validators.required),
        organizationId: new FormControl(response.organizationId, Validators.required),
        phoneNumber: new FormControl(response.phoneNumber),
        officePhone: new FormControl(response.officePhone),
        email: new FormControl(response.email),
        specializationId: new FormControl(response.specializationId, Validators.required),
        })
    }, (error) => {
      console.log(error)
      this.router.navigate([`/admin/accounts/`]).then();
    })
  }

  public updateAccount() {
    this.accountService.updateAccount(`Api/Account/${this.accountId}`, this.ownerForm.value).subscribe( (response: {}) => {
      this.router.navigate(['/admin/accounts']).then();
    }, (error) => {
      console.log(error);
      this.router.navigate([`/admin/accounts/edit/${this.accountId}`]).then();
    })
  }

  private getRoles() {
    this.accountService.getRoles('Api/Role').subscribe(response => {
      this.roles = response;
    }, (error) => {
      console.log(error);
      this.router.navigate(['/']).then();
    })
  }

  private getShortOrganizations() {
    this.organizationService.getShortOrganizations('Organization/GetShort').subscribe(response => {
      this.shortOrganizations = response;
    }, (error) => {
      console.log(error);
      this.router.navigate(['/']).then();
    })
  }

  private getShortSpecializations() {
    this.specializationService.getShortSpecializations('Specialization/GetShort').subscribe(response => {
      this.shortSpecializations = response;
    }, (error) => {
      console.log(error);
      this.router.navigate(['/']).then();
    })
  }
}
