import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IOrganization, IShortOrganization } from '../shared/models/organization';
import { Params } from '../shared/models/params';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';
import { AuthService } from '../shared/services/auth.service';
import { from } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrganizationsService {

  constructor(
    private _http: HttpClient,
    private _envUrl: EnvironmentUrlService,
    private _authService: AuthService) { }

  // Get All Organizations
  getOrganizations = (route: string, orgParams: Params) => {
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        let params = new HttpParams();
        if(orgParams.search){
          params = params.append('search', orgParams.search);
        }
        params = params.append('pageIndex', orgParams.pageNumber.toString());
        params = params.append('pageSize', orgParams.pageSize.toString());
        return this._http.get<IOrganization[]>(
          this.createCompleteRoute(route, this._envUrl.urlAddress),
          { headers: headers, observe: 'response', params }).toPromise();
      })
    );
  }

  // Get All Short Organizations
  getShortOrganizations = (route: string) => {
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        return this._http.get<IShortOrganization[]>(
          this.createCompleteRoute(route, this._envUrl.urlAddress),
          { headers: headers, observe: 'response' }).toPromise();
      })
    );
  }

  // Get By Id Organization
  getOrganization = (route: string) => {
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        return this._http.get<IOrganization>(
          this.createCompleteRoute(route, this._envUrl.urlAddress),
          { headers: headers, observe: 'response' }).toPromise();
      })
    );
  }

  // Create Organization
  createOrganization = (route: string, body: IOrganization) => {
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        headers.append('Content-Type','application/json');
        return this._http.post<{}>(
          this.createCompleteRoute(route, this._envUrl.urlAddress),
          body, { headers: headers, observe: 'response' }).toPromise();
      })
    );
  }

  // Update Organization
  updateOrganization = (route: string, body: IOrganization) => {
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        headers.append('Content-Type','application/json');
        return this._http.put<{}>(
          this.createCompleteRoute(route, this._envUrl.urlAddress),
          body, { headers: headers, observe: 'response' }).toPromise();
      })
    );
  }

  // Delete Organization
  deleteOrganization = (route: string) => {
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        return this._http.delete<{}>(
          this.createCompleteRoute(route, this._envUrl.urlAddress),
          { headers: headers, observe: 'response' }).toPromise();
      })
    );
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

}
