import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
  displayedColumns: string[] = ['officialName', 'usualName', 'line', 'region', 'level', 'isActive', 'actions'];
  
  constructor(
    private organizationsService: OrganizationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllOrganizations()
  }

  getAllOrganizations() {
    this.organizationsService.getOrganizations(this.orgParams).subscribe(response => {
      this.organizations = <IOrganization[]>response.body?.data;
      this.orgParams.pageNumber = response.body!.pageIndex;
      this.orgParams.pageSize = response.body!.pageSize;
      this.totalCount = response.body!.count;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  deleteOrganization(organizationId: string){
    if(organizationId)
    {
      this.organizationsService.deleteOrganization(organizationId).subscribe((date: {}) => {
        this.getAllOrganizations();
      }, (error) => {
        this.getAllOrganizations();
      });
    }
  }

  onSearch() {
    this.orgParams.search = this.searchTerm.nativeElement.value;
    this.orgParams.pageNumber = 1;
    this.getAllOrganizations();
  }

  onPageChange(event: any) {
    if(this.orgParams.pageNumber !== event)
    {
      this.orgParams.pageNumber = event;
      this.getAllOrganizations();
    }
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.orgParams = new Params();
    this.getAllOrganizations();
  }
}
