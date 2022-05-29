import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAnamnesis, IPurpose, IReferral } from '../shared/models/referral';
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

  // Get By Id Anamnesis
  getAnamnesis = (route: string) => {
    return this._http.get<IAnamnesis>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Create Anamnesis
  createAnamnesis = (route: string, body: IAnamnesis) => {
    return this._http.post<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Update Anamnesis
  updateAnamnesis = (route: string, body: IAnamnesis) => {
    return this._http.put<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Delete Anamnesis
  deleteAnamnesis = (route: string) => {
    return this._http.delete<{}>(this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response' });
  }

  //********************Purpose********************//

  // Get By Id Purpose
  getPurpose = (route: string) => {
    return this._http.get<IPurpose>(
      this.createCompleteRoute(route, this._envUrl.urlAddress),{ observe: 'response' });
  }

  // Create Purpose
  createPurpose = (route: string, body: IPurpose) => {
    return this._http.post<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Update Purpose
  updatePurpose = (route: string, body: IPurpose) => {
    return this._http.put<{}>(
      this.createCompleteRoute(route, this._envUrl.urlAddress), body, { observe: 'response' });
  }

  // Delete Purpose
  deletePurpose = (route: string) => {
    return this._http.delete<{}>(this.createCompleteRoute(route, this._envUrl.urlAddress), { observe: 'response' });
  }

  //***********************************************//

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}