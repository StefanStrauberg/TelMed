import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Params } from '../shared/models/params';
import { IShortSpecialization, ISpecialization } from '../shared/models/specialization';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class SpecializationsService {

  constructor(
    private _http: HttpClient,
    private _envUrl: EnvironmentUrlService) { }

  // Get All Specializations
  getSpecializations(route: string, specParams: Params) {
    let params = new HttpParams();
    if(specParams.search){
      params = params.append('search', specParams.search);
    }
    params = params.append('pageIndex', specParams.pageNumber.toString());
    params = params.append('pageSize', specParams.pageSize.toString());
    return this._http.get<ISpecialization[]>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response', params });
  }

  // Get All Short Specialization
  getShortSpecializations = (route: string) => {
    return this._http.get<IShortSpecialization[]>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Get By Id Specialization
  getSpecialization = (route: string) => {
    return this._http.get<ISpecialization>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Create Specialization
  createSpecialization = (route: string, body: ISpecialization) => {
    return this._http.post<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),body, { observe: 'response' });
  }

  // Update Specialization
  updateSpecialization = (route: string, body: ISpecialization) => {
    return this._http.put<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Delete Specialization
  deleteSpecialization = (route: string) => {
    return this._http.delete<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response' });
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  
}
