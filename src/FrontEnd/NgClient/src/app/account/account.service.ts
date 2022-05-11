import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAccount, IRole } from '../shared/models/account';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseAccountUrl: string = 'api/Account';
  baseRoleUrl: string = 'api/Role';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Roles
  getRoles = () => {
    return this.http.get<IRole[]>(this.createCompleteRoute(this.baseRoleUrl, this.envUrl.identityServer));
  }

  // Get All Accounts
  getAccounts = () => {
    return this.http.get<IAccount[]>(this.createCompleteRoute(this.baseAccountUrl, this.envUrl.identityServer));
  }

  // Get By Id Account
  getAccount = (id: string) => {
    return this.http.get<IAccount>(this.createCompleteRoute(this.baseAccountUrl + `/${id}`, this.envUrl.identityServer));
  }

  // Create Account
  createAccount = (model: IAccount) => {
    return this.http.post<{}>(this.createCompleteRoute(this.baseAccountUrl + '/Register', this.envUrl.identityServer), model);
  }

  // Update Account
  updateAccount = (model: IAccount, id: string) => {
    return this.http.put<{}>(this.baseAccountUrl + `/${id}`, model);
  }

  // Delete Account
  deleteAccount = (id: string) => {
    return this.http.delete<{}>(this.baseAccountUrl + `/${id}`);
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
