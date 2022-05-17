import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { IOrganization, OrganizationLevel, OrganizationRegion } from 'src/app/shared/models/organization';
import { Params } from 'src/app/shared/models/params';
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
  @ViewChild('search', {static: false}) searchTerm!: ElementRef;
  orgParams = new Params();
  totalCount!: number;
  displayedColumns: string[] = ['officialName', 'usualName', 'line', 'specializationIds', 'region', 'level', 'isActive', 'actions'];
  
  constructor(
    private organizationsService: OrganizationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllOrganizations()
  }

  getAllOrganizations() {
    this.organizationsService.getOrganizations('Organization', this.orgParams).subscribe(response => {
      this.organizations = response!;
    }, (error) => {
      console.log(error);
      this.router.navigate(['/']).then();
    })
  }

  deleteOrganization(organizationId: string){
    if(organizationId)
    {
      this.organizationsService.deleteOrganization(`Organization/${organizationId}`).subscribe((response: {}) => {
        this.getAllOrganizations();
      }, (error) => {
        console.log(error);
        this.getAllOrganizations();
      });
    }
  }

  onSearch() {
    this.orgParams.search = this.searchTerm.nativeElement.value;
    this.orgParams.pageNumber = 0;
    this.getAllOrganizations();
  }

  onPageChange(event: PageEvent) {
    if(this.orgParams.pageSize !== event.pageSize)
    {
      this.orgParams.pageSize = event.pageSize;
      this.getAllOrganizations();
    }
    if(this.orgParams.pageNumber !== event.pageIndex)
    {
      this.orgParams.pageNumber = event.pageIndex;
      this.getAllOrganizations();
    }
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.orgParams = new Params();
    this.getAllOrganizations();
  }
}
