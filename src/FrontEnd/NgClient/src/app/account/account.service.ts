import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAccount } from '../shared/models/account';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl: string = 'api/Account';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Accounts
  getAccounts = () => {
    return this.http.get<IAccount[]>(this.createCompleteRoute(this.baseUrl, this.envUrl.identityServer));
  }

  // Get By Id Account
  getAccount = (id: string) => {
    return this.http.get<IAccount>(this.createCompleteRoute(this.baseUrl + `/${id}`, this.envUrl.urlAddress));
  }

  // Create Account
  createAccount = (model: IAccount) => {
    return this.http.post<{}>(this.baseUrl, model);
  }

  // Update Account
  updateAccount = (model: IAccount, id: string) => {
    return this.http.put<{}>(this.baseUrl + `/${id}`, model);
  }

  // Delete Account
  deleteAccount = (id: string) => {
    return this.http.delete<{}>(this.baseUrl + `/${id}`);
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
