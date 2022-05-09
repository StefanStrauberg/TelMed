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
    if(this.organizationId){
      this.organizationsService.getOrganization(this.organizationId).subscribe((data: IOrganization) => {
        this.orgName = data.organizationName.officialName;
        this.ownerForm = this.formBuilder.group({
          organizationName: this.formBuilder.group({
            officialName: new FormControl(data.organizationName.officialName, Validators.required),
            usualName: new FormControl(data.organizationName.usualName, Validators.required),
          }),
          address: this.formBuilder.group({
            line: new FormControl(data.address.line, Validators.required),
          }),
          isActive: new FormControl(data.isActive),
          region : new FormControl(data.region, Validators.required),
          level : new FormControl(data.level, Validators.required)
        });
      }, (error) => {
        this.router.navigate([`/admin/organizations/`]).then();
      })
    };
  }

  updateOrganization(){
    if(this.organizationId){
      this.organizationsService.updateOrganization(this.ownerForm.value, this.organizationId).subscribe((data: {}) => {
        this.router.navigate(['/admin/organizations']).then();
      }, (error) => {
        this.router.navigate([`/admin/organizations/edit/${this.organizationId}`]).then();
      })
    }
  }
}
