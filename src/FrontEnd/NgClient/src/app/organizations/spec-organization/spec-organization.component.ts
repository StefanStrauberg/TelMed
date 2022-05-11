import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { IShortSpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from 'src/app/specializations/specializations.service';
import { OrganizationsService } from '../organizations.service';

@Component({
  selector: 'app-spec-organization',
  templateUrl: './spec-organization.component.html',
  styleUrls: ['./spec-organization.component.scss']
})
export class SpecOrganizationComponent implements OnInit {
  organizationId: string | null = null;
  specializations: IShortSpecialization[] = [];
  ownerForm!: FormGroup;
  orgName: string | null = null;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private specializationsService: SpecializationsService,
    private organizationService: OrganizationsService,
    private router: Router) { }

  async ngOnInit() {
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.organizationId = param.get('id');
    });
    if(this.organizationId){
      this.organizationService.getOrganization(this.organizationId).subscribe(organization => {
        this.orgName = organization.organizationName.officialName;
        this.ownerForm = this.formBuilder.group({
          specializationIds: new FormControl(organization.specializationIds)
        });
      }, (error) => {
        this.router.navigate([`/admin/organizations/`]).then();
      });
    }
    this.getShortSpecializations();
  }


  getShortSpecializations() {
    this.specializationsService.getShortSpecializations().subscribe(data => {
      this.specializations = <IShortSpecialization[]>data;
    }, (error) => {
      this.router.navigate([`/admin/organizations/`]).then();
    });
  }

  checkSpecializationInOrganization(specializationId: string): boolean {
    if(this.ownerForm.value.specializationIds.find((x: string) => x == specializationId)) return true;
      return false;
  }

  pushSpecializationInOrganization(event: MatCheckboxChange){
    if (event.checked){
      this.ownerForm.value.specializationIds.push(event.source.name);
    } else {
      this.ownerForm.value.specializationIds.forEach((item: string | null, index: any) => {
        if(item === event.source.name)
        this.ownerForm.value.specializationIds.splice(index, 1);
      })
    }
  }

  setSpecializationIds(){
    if(this.organizationId){
      this.organizationService.setSetSpecializations(this.ownerForm.value.specializationIds, this.organizationId).subscribe((data: {}) => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        this.router.navigate([`admin/organizations/${this.organizationId}/specializations`]).then();
      })
    }
  }
}
