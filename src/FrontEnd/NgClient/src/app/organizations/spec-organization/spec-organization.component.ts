import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Params } from 'src/app/shared/models/params';
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
  ownerForm!: FormGroup;
  orgName: string | null = null;
  params: Params = {
    pageNumber: 0,
    pageSize: 0,
    sort: '',
    search: ''
  };

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
          organizationName: this.formBuilder.group({
            officialName: new FormControl(organization.organizationName.officialName),
            usualName: new FormControl(organization.organizationName.usualName),
          }),
          address: this.formBuilder.group({
            line: new FormControl(organization.address.line),
          }),
          isActive: new FormControl(organization.isActive),
          region : new FormControl(organization.region),
          level : new FormControl(organization.level),
          specializationIds: new FormControl(organization.specializationIds)
        });
        this.specializationsService.getSpecializations(this.params).subscribe(data => {
          this.specializations = <ISpecialization[]>data.body?.data;
        }, (error) => {
          this.router.navigate([`/admin/organizations/`]).then();
        });
      }, (error) => {
        this.router.navigate([`/admin/organizations/`]).then();
      });
    }
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

  updateOrganization(){
    if(this.organizationId){
      this.organizationService.updateOrganization(this.ownerForm.value, this.organizationId).subscribe((data: {}) => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        this.router.navigate([`admin/organizations/${this.organizationId}/specializations`]).then();
      })
    }
  }
}
