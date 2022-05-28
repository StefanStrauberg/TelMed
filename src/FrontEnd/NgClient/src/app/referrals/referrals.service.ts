import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAnamnesis } from '../shared/models/anamnesis';
import { IPurpose } from '../shared/models/purpose';
import { IReferral } from '../shared/models/referral';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class ReferralsService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  //********************Referrals********************//

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

  //********************Anamnesis********************//

  // Create Anamnesis
  createAnamnesis = (route: string, body: IAnamnesis) => {
    return this._http.post<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Get All Anamnesies by ReferralId
  getAnamnesies = (route: string) => {
    return this._http.get<IAnamnesis[]>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Get All Anamnesis by ReferralId
  getAnamnesis = (route: string) => {
    return this._http.get<IAnamnesis>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Update Anamnesis
  updateAnamnesis = (route: string, body: IAnamnesis) => {
    return this._http.put<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  //********************Purpose********************//

  // Create Purpose
  createPurpose = (route: string, body: IPurpose) => {
    return this._http.post<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Get All Anamnesies by ReferralId
  getPurposes = (route: string) => {
    return this._http.get<IPurpose[]>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Delete Anamnesis
  deleteAnamnesis = (route: string) => {
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
