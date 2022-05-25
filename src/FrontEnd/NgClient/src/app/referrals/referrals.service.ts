import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IReferral } from '../shared/models/referral';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class ReferralsService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  // Get All Referrals
  getReferrals = (route: string) => {
    return this._http.get<IReferral[]>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Get By Id Referral
  getReferral = (route: string) => {
    return this._http.get<IReferral>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Create Referral
  createReferral = (route: string, body: IReferral) => {
    return this._http.post<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Update Referral
  updateReferral = (route: string, body: IReferral) => {
    return this._http.put<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Delete Referral
  deleteReferral = (route: string) => {
    return this._http.delete<{}>(this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response' });
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
