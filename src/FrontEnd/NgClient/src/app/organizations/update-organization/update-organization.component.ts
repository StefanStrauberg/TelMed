import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/shared/models/organization';
import { OrganizationsService } from '../organizations.service';

@Component({
  selector: 'app-update-organization',
  templateUrl: './update-organization.component.html',
  styleUrls: ['./update-organization.component.scss']
})
export class UpdateOrganizationComponent implements OnInit {
  orgReg = OrganizationRegion;
  orgLev = OrganizationLevel;
  organizationId: string | null = null;
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
  enumValuse = enumValues;

  constructor(private activatedRoute: ActivatedRoute,
    private organizationsService: OrganizationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.organizationId = param.get('id');
    });
    if(this.organizationId){
      this.organizationsService.getOrganization(this.organizationId).subscribe((data: IOrganization) => {
        this.organization = data;
      }, (error) => {
        this.router.navigate([`/admin/organizations/`]).then();
      })
    }
  }

  updateOrganization(){
    if(this.organizationId){
      this.organizationsService.updateOrganization(this.organization, this.organizationId).subscribe((data: {}) => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        this.router.navigate([`/admin/organizations/edit/${this.organizationId}`]).then();
      })
    }
  }
}
