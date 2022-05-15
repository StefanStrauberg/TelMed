import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IOrganization, IShortOrganization } from '../shared/models/organization';
import { Params } from '../shared/models/params';
import { IPagination } from '../shared/models/pagination';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class OrganizationsService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Organizations
  getOrganizations = (route: string, orgParams: Params) => {
    let params = new HttpParams();
    if(orgParams.search){
      params = params.append('search', orgParams.search);
    }
    params = params.append('pageIndex', orgParams.pageNumber.toString());
    params = params.append('pageSize', orgParams.pageSize.toString());
    return this.http.get<IPagination>(this.createCompleteRoute(route, this.envUrl.urlAddress), {observe: 'response', params});
  }

  // Get All Short Organizations
  getShortOrganizations = (route: string) => {
    return this.http.get<IShortOrganization[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  // Get By Id Organization
  getOrganization = (route: string) => {
    return this.http.get<IOrganization>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  // Create Organization
  createOrganization = (route: string, body: IOrganization) => {
    return this.http.post<{}>(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  }

  // Update Organization
  updateOrganization = (route: string, body: IOrganization) => {
    return this.http.put<{}>(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  }

  // Delete Organization
  deleteOrganization = (route: string) => {
    return this.http.delete<{}>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
