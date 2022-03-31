import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/models/IOrganization';
import { OrganizationService } from 'src/app/services/organization.service';

@Component({
  selector: 'app-create-organization',
  templateUrl: './create-organization.component.html',
  styleUrls: ['./create-organization.component.css']
})
export class CreateOrganizationComponent implements OnInit {

  orgReg = OrganizationRegion;
  orgLev = OrganizationLevel;
  loading: boolean = false;
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
    isActive: true
  } as IOrganization; 
  errorMessage: string | null = null;
  enumValuse = enumValues;

  constructor(
    private organizationService: OrganizationService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createOrganization(){
    this.organizationService.createOrganization(this.organization).subscribe((data: IOrganization) => {
      this.router.navigate(['/admin/organizations']).then();
    }, (error) => {
      this.errorMessage = error;
      this.router.navigate(['/admin/organizations/create']).then();
    })
  }

}
