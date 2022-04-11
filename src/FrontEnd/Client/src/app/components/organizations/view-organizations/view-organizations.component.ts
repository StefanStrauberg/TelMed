import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/models/IOrganization';
import { ISpecialization } from 'src/app/models/ISpecialization';
import { OrganizationService } from 'src/app/services/organization.service';
import { SpecializationService } from 'src/app/services/specialization.service';

@Component({
  selector: 'app-view-organizations',
  templateUrl: './view-organizations.component.html',
  styleUrls: ['./view-organizations.component.css']
})
export class ViewOrganizationsComponent implements OnInit {

  loading: boolean = false;
  organizations: IOrganization[]= [];
  errorMessage: string | null = null;
  orgLev = OrganizationLevel;
  orgReg = OrganizationRegion;
  specializations: ISpecialization[] = [];

  constructor(
    private organizationService: OrganizationService,
    private specializationService: SpecializationService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllOrganizations();
  }

  getAllOrganizations(){
    this.loading = true;
    this.organizationService.getAllOrganizations().subscribe((data: IOrganization[]) => {
      this.organizations = data;
      this.specializationService.getAllSpecializations().subscribe((data: ISpecialization[]) => {
        this.specializations = data;
      });
      this.loading = false;
    }, (error) => {
      this.errorMessage = error;
      console.log(this.errorMessage);
      this.loading = false;
    })
  }

  getSpecializationsName(specs: string[]): string[] {
    let returnSpecsNames: string[] = [];
    for(let item of specs){
      returnSpecsNames.push(this.specializations.find(x => x.id == item)?.name as string);
    }
    return returnSpecsNames;
  }

  deleteOrganization(organizationId: string){
    if(organizationId)
    {
      this.organizationService.deleteOrganization(organizationId).subscribe((date: {}) => {
        this.getAllOrganizations();
        this.loading = false;
      }, (error) => {
        this.errorMessage = error;
        this.getAllOrganizations();
        this.loading = false;
      });
    }
  }
}
