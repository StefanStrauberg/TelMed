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
      this._organizationsService.getOrganization(`Organization/${this.organizationId}`).subscribe(response => {
        this.orgName = response?.body?.organizationName.officialName!;
        this.ownerForm = this._formBuilder.group({
          organizationName: this._formBuilder.group({
            officialName: new FormControl(response?.body?.organizationName.officialName!),
            usualName: new FormControl(response?.body?.organizationName.usualName!),
          }),
          address: this._formBuilder.group({
            line: new FormControl(response?.body?.address.line!),
          }),
          isActive: new FormControl(response?.body?.isActive!),
          region : new FormControl(response?.body?.region!),
          level : new FormControl(response?.body?.level!),
          specializationIds: new FormControl(response?.body?.specializationIds!)
        });
      }, (error) => {
        console.log(error);
        this._router.navigate([`/admin/organizations/`]).then();
      });
    }
  }

  getShortSpecializations() {
    this._specializationsService.getShortSpecializations('Specialization/GetShort').subscribe(response => {
      this.specializations = response?.body!;
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
      this._organizationsService.updateOrganization(`Organization/${this.organizationId}`, this.ownerForm.value).subscribe(response => {
        this._router.navigate(['/admin/organizations']).then();
      }, (error) => {
        console.log(error);
        this._router.navigate([`/admin/organizations/edit/${this.organizationId}`]).then();
      })
    }
  }
}
