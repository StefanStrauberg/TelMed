import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/shared/models/organization';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from 'src/app/specializations/specializations.service';
import { OrganizationsService } from '../organizations.service';

@Component({
  selector: 'app-view-organizations',
  templateUrl: './view-organizations.component.html',
  styleUrls: ['./view-organizations.component.scss']
})
export class ViewOrganizationsComponent implements OnInit {
  organizations: IOrganization[] = [];
  orgLev = OrganizationLevel;
  orgReg = OrganizationRegion;
  specializations: ISpecialization[] = [];
  
  constructor(
    private organizationsService: OrganizationsService,
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.getOrganizations()
  }

  getOrganizations() {
    // this.organizationsService.getOrganizations().subscribe((response: IOrganization[]) => {
    //   this.organizations = response;
    //   this.specializationsService.getSpecializations().subscribe((data: ISpecialization[]) => {
    //     this.specializations = data;
    //   });
    // }, error => {
    //   this.router.navigate(['/']).then();
    // });
  }

  deleteOrganization(organizationId: string){
    if(organizationId)
    {
      this.organizationsService.deleteOrganization(organizationId).subscribe((date: {}) => {
        this.getOrganizations();
      }, (error) => {
        this.getOrganizations();
      });
    }
  }

  getSpecializationsName(specs: string[]): string[] {
    let returnSpecsNames: string[] = [];
    for(let item of specs){
      returnSpecsNames.push(this.specializations.find(x => x.id == item)?.name as string);
    }
    return returnSpecsNames;
  }
}
