import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IOrganization } from '../shared/models/organization';
import { Params } from '../shared/models/params';
import { IPagination } from '../shared/models/pagination';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class OrganizationsService {

  baseUrl: string = 'Organization';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Organizations
  getOrganizations = (orgParams: Params) => {
    let params = new HttpParams();
    if(orgParams.search){
      params = params.append('search', orgParams.search);
    }
    params = params.append('pageIndex', orgParams.pageNumber.toString());
    params = params.append('pageSize', orgParams.pageSize.toString());
    return this.http.get<IPagination>(this.createCompleteRoute(this.baseUrl, this.envUrl.urlAddress), {observe: 'response', params});
  }

  // Get By Id Organization
  getOrganization = (id: string) => {
    return this.http.get<IOrganization>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress));
  }

  // Create Organization
  createOrganization = (model: IOrganization) => {
    return this.http.post<{}>(this.createCompleteRoute(this.baseUrl, this.envUrl.urlAddress), model);
  }

  // Update Organization
  updateOrganization = (model: IOrganization, id: string) => {
    return this.http.put<{}>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress), model);
  }

  // Delete Organization
  deleteOrganization = (id: string) => {
    return this.http.delete<{}>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress));
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
