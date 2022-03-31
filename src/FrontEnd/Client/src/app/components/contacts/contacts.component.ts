import { Component, OnInit } from '@angular/core';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/models/IOrganization';
import { ISpecialization } from 'src/app/models/ISpecialization';
import { OrganizationService } from 'src/app/services/organization.service';
import { SpecializationService } from 'src/app/services/specialization.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  loading: boolean = false;
  organizations: IOrganization[] = [];
  specializations: ISpecialization[] = [];
  orgLev = OrganizationLevel;
  orgReg = OrganizationRegion;
  errorMessage: string | null = null;

  constructor(
    private organizationService: OrganizationService,
    private specializationService: SpecializationService) { }

  ngOnInit(): void {
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
}
