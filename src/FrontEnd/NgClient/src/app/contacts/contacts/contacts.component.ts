import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrganizationsService } from 'src/app/organizations/organizations.service';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/shared/models/organization';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from 'src/app/specializations/specializations.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent implements OnInit {
  organizations: IOrganization[] = [];
  specializations: ISpecialization[] = [];
  orgLev = OrganizationLevel;
  orgReg = OrganizationRegion;
  
  constructor(
    private organizationsService: OrganizationsService,
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
    // this.organizationsService.getOrganizations().subscribe((data: IOrganization[]) => {
    //   this.organizations = data;
    //   this.specializationsService.getSpecializations().subscribe((data: ISpecialization[]) => {
    //     this.specializations = data;
    //   }, (error) => {
    //     this.router.navigate(['/']).then();
    //   });
    // }, (error) => {
    //   this.router.navigate(['/']).then();
    // })
  }

  getSpecializationsName(specs: string[]): string[] {
    let returnSpecsNames: string[] = [];
    for(let item of specs){
      returnSpecsNames.push(this.specializations.find(x => x.id == item)?.name as string);
    }
    return returnSpecsNames;
  }

}
