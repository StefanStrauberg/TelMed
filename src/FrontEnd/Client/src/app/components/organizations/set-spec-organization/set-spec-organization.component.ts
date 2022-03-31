import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/models/IOrganization';
import { ISpecialization } from 'src/app/models/ISpecialization';
import { OrganizationService } from 'src/app/services/organization.service';
import { SpecializationService } from 'src/app/services/specialization.service';

@Component({
  selector: 'app-set-spec-organization',
  templateUrl: './set-spec-organization.component.html',
  styleUrls: ['./set-spec-organization.component.css']
})
export class SetSpecOrganizationComponent implements OnInit {
  
  loading: boolean = false;
  organizationId: string | null = null;
  specializations: ISpecialization[] = [];
  errorMessage: string | null = null;
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
    private specializationService: SpecializationService,
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
        this.specializationService.getAllSpecializations().subscribe((data: ISpecialization[]) => {
          this.specializations = data;
        });
        this.loading = false;
      }, (error) => {
        this.errorMessage = error;
        this.loading = false;
      })
    }
  }

  checkSpecializationInOrganization(specializationId: string): boolean {
    if(this.organization.specializationIds.find(x => x == specializationId)) return true;
      return false;
  }

  pushSpecializationInOrganization(specializationId: string){
    if(this.checkSpecializationInOrganization(specializationId)) return;
      this.organization.specializationIds.push(specializationId);
  }
}
