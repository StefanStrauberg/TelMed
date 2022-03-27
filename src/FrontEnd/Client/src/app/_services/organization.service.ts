import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Organization } from '../_models/organization';
import { HttpClient } from '@angular/common/http';
import { of, map } from 'rxjs';
import { OrganizationCreate } from '../_models/organizationCreate';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {

  baseUrl = environment.orgUrl;
  organizations: Organization[] = [];

  constructor(private http: HttpClient) { }

  getOrganizations() {
    if(this.organizations.length > 0) return of(this.organizations);
    return this.http.get<Organization[]>(this.baseUrl).pipe(
      map(organizations => {
        this.organizations = organizations;
        return organizations;
      })
    )
  }

  getOrganization(id: string) {
    const organization = this.organizations.find( x => x.id === id);
    if(organization !== undefined) return of(organization);
    return this.http.get<Organization>(this.baseUrl + id);
  }

  createOrganization(organizationCreate: OrganizationCreate) {
    return this.http.post<string>(this.baseUrl, organizationCreate).subscribe(
      response => {
        console.log(response);
      }
    )
  }
}
