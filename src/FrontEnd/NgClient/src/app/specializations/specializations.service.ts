import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { Params } from '../shared/models/params';
import { ISpecialization } from '../shared/models/specialization';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class SpecializationsService {
  baseUrl: string = 'Specialization';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Specializations
  getSpecializations(specParams: Params) {
    let params = new HttpParams();
    if(specParams.search){
      params = params.append('search', specParams.search);
    }
    params = params.append('pageIndex', specParams.pageNumber.toString());
    params = params.append('pageSize', specParams.pageSize.toString());
    return this.http.get<IPagination>(this.createCompleteRoute(this.baseUrl, this.envUrl.urlAddress), {observe: 'response', params});
  }

  // Get By Id Specialization
  getSpecialization = (id: string) => {
    return this.http.get<ISpecialization>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress));
  }

  // Create Specialization
  createSpecialization = (model: ISpecialization) => {
    return this.http.post<{}>(this.createCompleteRoute(this.baseUrl, this.envUrl.urlAddress), model);
  }

  // Update Specialization
  updateSpecialization = (model: ISpecialization, id: string) => {
    return this.http.put<{}>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress), model);
  }

  // Delete Specialization
  deleteSpecialization = (id: string) => {
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
