import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { IOrganization } from 'src/app/shared/models/organization';
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
    private _formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private _specializationsService: SpecializationsService,
    private _organizationsService: OrganizationsService,
    private _router: Router) { }

  async ngOnInit() {
    this._activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.organizationId = param.get('id');
    });
    this.getOrganization();
    this.getShortSpecializations();
  }

  getOrganization() {
    if(this.organizationId){
      this._organizationsService.getOrganization(`Organization/${this.organizationId}`).subscribe((response: IOrganization) => {
        this.orgName = response.organizationName.officialName;
        this.ownerForm = this._formBuilder.group({
          organizationName: this._formBuilder.group({
            officialName: new FormControl(response.organizationName.officialName),
            usualName: new FormControl(response.organizationName.usualName),
          }),
          address: this._formBuilder.group({
            line: new FormControl(response.address.line),
          }),
          isActive: new FormControl(response.isActive),
          region : new FormControl(response.region),
          level : new FormControl(response.level),
          specializationIds: new FormControl(response.specializationIds)
        });
      }, (error) => {
        console.log(error);
        this._router.navigate([`/admin/organizations/`]).then();
      });
    }
  }

  getShortSpecializations() {
    this._specializationsService.getShortSpecializations('Specialization/GetShort').subscribe((response: IShortSpecialization[]) => {
      this.specializations = response;
    }, (error) => {
      console.log(error);
      this._router.navigate([`/admin/organizations/`]).then();
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

  updateOrganization(){
    if(this.organizationId){
      this._organizationsService.updateOrganization(`Organization/${this.organizationId}`, this.ownerForm.value).subscribe((response: {}) => {
        this._router.navigate(['/admin/organizations']).then();
      }, (error) => {
        console.log(error);
        this._router.navigate([`/admin/organizations/edit/${this.organizationId}`]).then();
      })
    }
  }
}
