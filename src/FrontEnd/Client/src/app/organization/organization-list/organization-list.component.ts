import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Organization } from 'src/app/_models/organization';
import { OrganizationService } from 'src/app/_services/organization.service';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.scss']
})
export class OrganizationListComponent implements OnInit {

  organizations$!: Observable<Organization[]>;
  
  constructor(private organizationService: OrganizationService) { }

  ngOnInit(): void {
    this.organizations$ = this.organizationService.getOrganizations();
  }

}
