import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { OrganizationLevel, OrganizationRegion } from 'src/app/shared/models/organization';
import { OrganizationsService } from '../organizations.service';

@Component({
  selector: 'app-create-organization',
  templateUrl: './create-organization.component.html',
  styleUrls: ['./create-organization.component.scss']
})
export class CreateOrganizationComponent implements OnInit {
  orgReg = OrganizationRegion;
  orgLev = OrganizationLevel;
  enumValuse = enumValues;
  ownerForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private organizationsService: OrganizationsService,
    public router: Router) { }

  ngOnInit(): void {
    this.ownerForm = this.formBuilder.group({
      organizationName: this.formBuilder.group({
        officialName: new FormControl('', Validators.required),
        usualName: new FormControl('', Validators.required),
      }),
      address: this.formBuilder.group({
        line: new FormControl('', Validators.required),
      }),
      region : new FormControl(null, Validators.required),
      level : new FormControl(null, Validators.required)
    });
  }

  createOrganization(){
    if(this.ownerForm.valid)
    {
      this.organizationsService.createOrganization('Organization', this.ownerForm.value).subscribe((response: {}) => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        console.log(error);
        this.router.navigate(['/admin/organizations/create']).then();
      })
    }
  }
}
