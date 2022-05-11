import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { OrganizationsService } from 'src/app/organizations/organizations.service';
import { IRole } from 'src/app/shared/models/account';
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
  
  constructor(
    private specializationService: SpecializationsService,
    private organizationService: OrganizationsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.getRoles();
    this.getShortOrganizations();
    this.getShortSpecializations();
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.accountId = param.get('id');
    });
    if(this.accountId)
    {
      this.accountService.getAccount(this.accountId).subscribe(response => {
        this.ownerForm = this.formBuilder.group({
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
        this.router.navigate([`/admin/accounts/`]).then();
      })
    }
  }

  getRoles() {
    this.accountService.getRoles().subscribe(response => {
      this.roles = response;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  getShortOrganizations() {
    this.organizationService.getShortOrganizations().subscribe(response => {
      this.shortOrganizations = response;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  getShortSpecializations() {
    this.specializationService.getShortSpecializations().subscribe(response => {
      this.shortSpecializations = response;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }
}
