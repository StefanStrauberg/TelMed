import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IReferral } from '../shared/models/referral';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class ReferralsService {
  baseUrl: string = 'Referral';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Referrals
  getReferrals() {
    return this.http.get<IReferral[]>(this.createCompleteRoute(this.baseUrl, this.envUrl.urlAddress));
  }

  // Get By Id Referral
  getReferral = (id: string) => {
    return this.http.get<IReferral>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress));
  }

  // Create Referral
  createReferral = (model: IReferral) => {
    return this.http.post<{}>(this.createCompleteRoute(this.baseUrl, this.envUrl.urlAddress), model);
  }

  // Update Referral
  updateReferral = (model: IReferral, id: string) => {
    return this.http.put<{}>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress), model);
  }

  // Delete Referral
  deleteReferral = (id: string) => {
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
