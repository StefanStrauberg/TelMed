import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/models/IOrganization';
import { OrganizationService } from 'src/app/services/organization.service';

@Component({
  selector: 'app-view-organizations',
  templateUrl: './view-organizations.component.html',
  styleUrls: ['./view-organizations.component.css']
})
export class ViewOrganizationsComponent implements OnInit {

  loading: boolean = false;
  organizations: IOrganization[]= [];
  errorMessage: string | null = null;
  levOrg = OrganizationLevel;
  orgReg = OrganizationRegion;

  constructor(
    private organizationService: OrganizationService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllOrganizations();
  }

  getAllOrganizations(){
    console.log(this.orgReg[2]);
    this.loading = true;
    this.organizationService.getAllOrganizations().subscribe((data: IOrganization[]) => {
      this.organizations = data;
      this.loading = false;
    }, (error) => {
      this.errorMessage = error;
      console.log(this.errorMessage);
      this.loading = false;
    })
  }

}
