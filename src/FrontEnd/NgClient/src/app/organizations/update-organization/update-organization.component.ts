import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
  enumValuse = enumValues;
  ownerForm!: FormGroup;
  orgName: string | null = null;
  
  constructor(private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private organizationsService: OrganizationsService,
    private router: Router) { }

  async ngOnInit() {
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.organizationId = param.get('id');
    });
    this.getOrganization();
  }

  getOrganization() {
    if(this.organizationId){
      this.organizationsService.getOrganization(`Organization/${this.organizationId}`).subscribe(response => {
        this.orgName = response?.body?.organizationName.officialName!;
        this.ownerForm = this.formBuilder.group({
          organizationName: this.formBuilder.group({
            officialName: new FormControl(response?.body?.organizationName.officialName!, Validators.required),
            usualName: new FormControl(response?.body?.organizationName.usualName!, Validators.required),
          }),
          address: this.formBuilder.group({
            line: new FormControl(response?.body?.address.line!, Validators.required),
          }),
          isActive: new FormControl(response?.body?.isActive!),
          region : new FormControl(response?.body?.region!, Validators.required),
          level : new FormControl(response?.body?.level!, Validators.required),
          specializationIds: new FormControl(response?.body?.specializationIds!)
        });
      }, (error) => {
        this.router.navigate([`/admin/organizations/`]).then();
      })
    };
  }

  updateOrganization(){
    if(this.organizationId){
      this.organizationsService.updateOrganization(`Organization/${this.organizationId}`, this.ownerForm.value).subscribe(response => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        console.log(error);
        this.router.navigate([`/admin/organizations/edit/${this.organizationId}`]).then();
      })
    }
  }
}
