import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from } from 'rxjs';
import { IPagination } from '../shared/models/pagination';
import { Params } from '../shared/models/params';
import { IShortSpecialization, ISpecialization } from '../shared/models/specialization';
import { AuthService } from '../shared/services/auth.service';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class SpecializationsService {

  constructor(
    private _http: HttpClient,
    private _envUrl: EnvironmentUrlService,
    private _authService: AuthService) { }

  // Get All Specializations
  getSpecializations(route: string, specParams: Params) {
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        let params = new HttpParams();
        if(specParams.search){
          params = params.append('search', specParams.search);
        }
        params = params.append('pageIndex', specParams.pageNumber.toString());
        params = params.append('pageSize', specParams.pageSize.toString());
        return this._http.get<ISpecialization[]>(this.createCompleteRoute(route, this._envUrl.urlAddress), { headers: headers, observe: 'response' }).toPromise();
      })
    );
  }

  // Get All Short Specialization
  getShortSpecializations = (route: string) => {
    return this._http.get<IShortSpecialization[]>(this.createCompleteRoute(route, this._envUrl.urlAddress));
  }

  // Get By Id Specialization
  getSpecialization = (route: string) => {
    return this._http.get<ISpecialization>(this.createCompleteRoute(route, this._envUrl.urlAddress));
  }

  // Create Specialization
  createSpecialization = (route: string, body: ISpecialization) => {
    return this._http.post<{}>(this.createCompleteRoute(route, this._envUrl.urlAddress), body, this.generateHeaders());
  }

  // Update Specialization
  updateSpecialization = (route: string, body: ISpecialization) => {
    return this._http.put<{}>(this.createCompleteRoute(route, this._envUrl.urlAddress), body, this.generateHeaders());
  }

  // Delete Specialization
  deleteSpecialization = (route: string) => {
    return this._http.delete<{}>(this.createCompleteRoute(route, this._envUrl.urlAddress));
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
