import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAccount, IRole } from '../shared/models/account';
import { IPagination } from '../shared/models/pagination';
import { Params } from '../shared/models/params';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseAccountUrl: string = 'api';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Roles
  getRoles = () => {
    return this.http.get<IRole[]>(this.createCompleteRoute(this.baseAccountUrl + '/Role', this.envUrl.identityServer));
  }

  // Get All Accounts
  getAccounts = (specParams: Params) => {
    let params = new HttpParams();
    if(specParams.search){
      params = params.append('search', specParams.search);
    }
    params = params.append('pageIndex', specParams.pageNumber.toString());
    params = params.append('pageSize', specParams.pageSize.toString());
    return this.http.get<IPagination>(this.createCompleteRoute(this.baseAccountUrl + '/Account', this.envUrl.identityServer), {observe: 'response', params});
  }

  // Get By Id Account
  getAccount = (id: string) => {
    return this.http.get<IAccount>(this.createCompleteRoute(this.baseAccountUrl + `/Account/${id}`, this.envUrl.identityServer));
  }

  // Create Account
  createAccount = (model: IAccount) => {
    return this.http.post<{}>(this.createCompleteRoute(this.baseAccountUrl + '/Register', this.envUrl.identityServer), model);
  }

  // Update Account
  updateAccount = (model: IAccount, id: string) => {
    return this.http.put<{}>(this.createCompleteRoute(this.baseAccountUrl + `/Account/${id}`, this.envUrl.identityServer), model);
  }

  // Delete Account
  deleteAccount = (id: string) => {
    return this.http.delete<{}>(this.createCompleteRoute(this.baseAccountUrl + `/Account/${id}`, this.envUrl.identityServer));
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
