import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IOrganization, IShortOrganization } from '../shared/models/organization';
import { Params } from '../shared/models/params';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class OrganizationsService {

  constructor(
    private _http: HttpClient,
    private _envUrl: EnvironmentUrlService) { }

  // Get All Organizations
  getOrganizations = (route: string, orgParams: Params) => {
    let params = new HttpParams();
    if(orgParams.search){
      params = params.append('search', orgParams.search);
    }
    params = params.append('pageIndex', orgParams.pageNumber.toString());
    params = params.append('pageSize', orgParams.pageSize.toString());
    return this._http.get<IOrganization[]>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response', params });
  }

  // Get All Short Organizations
  getShortOrganizations = (route: string) => {
    return this._http.get<IShortOrganization[]>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response' });
  }

  // Get By Id Organization
  getOrganization = (route: string) => {
    return this._http.get<IOrganization>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response' });
  }

  // Create Organization
  createOrganization = (route: string, body: IOrganization) => {
    return this._http.post<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Update Organization
  updateOrganization = (route: string, body: IOrganization) => {
    return this._http.put<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Delete Organization
  deleteOrganization = (route: string) => {
    return this._http.delete<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response' });
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

}
