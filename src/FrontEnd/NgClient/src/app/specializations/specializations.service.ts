import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { Params } from '../shared/models/params';
import { IShortSpecialization, ISpecialization } from '../shared/models/specialization';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class SpecializationsService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Specializations
  getSpecializations(route: string, specParams: Params) {
    let params = new HttpParams();
    if(specParams.search){
      params = params.append('search', specParams.search);
    }
    params = params.append('pageIndex', specParams.pageNumber.toString());
    params = params.append('pageSize', specParams.pageSize.toString());
    return this.http.get<IPagination>(this.createCompleteRoute(route, this.envUrl.urlAddress), {observe: 'response', params});
  }

  // Get All Short Specialization
  getShortSpecializations = (route: string) => {
    return this.http.get<IShortSpecialization[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  // Get By Id Specialization
  getSpecialization = (route: string) => {
    return this.http.get<ISpecialization>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  // Create Specialization
  createSpecialization = (route: string, body: ISpecialization) => {
    return this.http.post<{}>(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  }

  // Update Specialization
  updateSpecialization = (route: string, body: ISpecialization) => {
    return this.http.put<{}>(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  }

  // Delete Specialization
  deleteSpecialization = (route: string) => {
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
