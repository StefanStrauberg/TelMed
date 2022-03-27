import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrganizationLevel, OrganizationRegion } from 'src/app/_models/organization';
import { OrganizationCreate } from 'src/app/_models/organizationCreate';
import { OrganizationService } from 'src/app/_services/organization.service';

@Component({
  selector: 'app-organization-create',
  templateUrl: './organization-create.component.html',
  styleUrls: ['./organization-create.component.scss']
})
export class OrganizationCreateComponent implements OnInit {

  data:OrganizationCreate = {
    level: OrganizationLevel.RepublicLevel,
    region: OrganizationRegion.Belarus,
    address: {
      line: ''
    },
    organizationName: {
      officialName: '',
      usualName: ''
    }
  }

  constructor(
    private organizationService: OrganizationService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createProduct(): void {
    this.organizationService.createOrganization(this.data).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
    this.router.navigate(['/organizations']);
  }
}
