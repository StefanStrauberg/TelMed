import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/models/IOrganization';
import { OrganizationService } from 'src/app/services/organization.service';

@Component({
  selector: 'app-edit-organization',
  templateUrl: './edit-organization.component.html',
  styleUrls: ['./edit-organization.component.css']
})
export class EditOrganizationComponent implements OnInit {

  orgReg = OrganizationRegion;
  orgLev = OrganizationLevel;
  organizationId: string | null = null;
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
    private activatedRoute: ActivatedRoute,
    private organizationService: OrganizationService,
    private router: Router) { }

  ngOnInit(): void {
    this.loading = true;
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.organizationId = param.get('id');
    });
    if(this.organizationId){
      this.organizationService.getOrganization(this.organizationId).subscribe((data: IOrganization) => {
        this.organization = data;
        this.loading = false;
      }, (error) => {
        this.errorMessage = error;
        this.loading = false;
      })
    }
  }

  updateOrganization(){
    if(this.organizationId){
      this.organizationService.updateOrganization(this.organization).subscribe((data: {}) => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        this.errorMessage = error;
        this.router.navigate([`/admin/organizations/edit/${this.organizationId}`]).then();
      })
    }
  }
}
