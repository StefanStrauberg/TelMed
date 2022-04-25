import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/shared/models/organization';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from 'src/app/specializations/specializations.service';
import { OrganizationsService } from '../organizations.service';

@Component({
  selector: 'app-spec-organization',
  templateUrl: './spec-organization.component.html',
  styleUrls: ['./spec-organization.component.scss']
})
export class SpecOrganizationComponent implements OnInit {
  organizationId: string | null = null;
  specializations: ISpecialization[] = [];
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
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private specializationsService: SpecializationsService,
    private organizationsService: OrganizationsService,
    private router: Router) { }

  ngOnInit(): void {
    // this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
    //   this.organizationId = param.get('id');
    // });
    // if(this.organizationId){
    //   this.organizationsService.getOrganization(this.organizationId).subscribe((data: IOrganization) => {
    //     this.organization = data;
    //     this.specializationsService.getSpecializations().subscribe((data: ISpecialization[]) => {
    //       this.specializations = data;
    //     }, (error) => {
    //       this.router.navigate([`/admin/organizations/`]).then();
    //     });
    //   }, (error) => {
    //     this.router.navigate([`/admin/organizations/`]).then();
    //   });
    // }
  }

  checkSpecializationInOrganization(specializationId: string): boolean {
    if(this.organization.specializationIds.find(x => x == specializationId)) return true;
      return false;
  }

  pushSpecializationInOrganization(event: any){
    if (event.target?.checked){
      this.organization.specializationIds.push(event.target.name);
    } else {
      this.organization.specializationIds.forEach((item, index) => {
        if(item === event.target.name)
        this.organization.specializationIds.splice(index, 1);
      })
    }
  }

  updateOrganization(){
    if(this.organizationId){
      this.organizationsService.updateOrganization(this.organization, this.organizationId).subscribe((data: {}) => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        this.router.navigate([`admin/organizations/${this.organizationId}/specializations`]).then();
      })
    }
  }
}
