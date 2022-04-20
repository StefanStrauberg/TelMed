import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/shared/models/organization';
import { OrganizationsService } from '../organizations.service';

@Component({
  selector: 'app-create-organization',
  templateUrl: './create-organization.component.html',
  styleUrls: ['./create-organization.component.scss']
})
export class CreateOrganizationComponent implements OnInit {
  orgReg = OrganizationRegion;
  orgLev = OrganizationLevel;
  organization: IOrganization = {
    organizationName: { 
      officialName: '',
      usualName: ''
    },
    address: { 
      line: ''
    },
    region: OrganizationRegion['г. Минск'],
    level: OrganizationLevel['Республиканский уровень'],
    specializationIds: [""],
  } as IOrganization;
  enumValuse = enumValues;

  constructor(
    private organizationsService: OrganizationsService,
    public router: Router) { }

  ngOnInit(): void {
  }

  createOrganization(){
    this.organizationsService.createOrganization(this.organization).subscribe((data: {}) => {
      this.router.navigate(['/admin/organizations']).then();
    }, (error) => {
      this.router.navigate(['/admin/organizations/create']).then();
    })
  }
}
