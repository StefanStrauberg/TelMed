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

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  // Get All Roles
  public getRoles = (route: string) => {
    return this.http.get<IRole[]>(this.createCompleteRoute(route, this.envUrl.identityServer));
  }

  // Get All Accounts
  public getAccounts = (route: string, specParams: Params) => {
    let params = new HttpParams();
    if(specParams.search){
      params = params.append('search', specParams.search);
    }
    params = params.append('pageIndex', specParams.pageNumber.toString());
    params = params.append('pageSize', specParams.pageSize.toString());
    return this.http.get<IPagination>(this.createCompleteRoute(route, this.envUrl.identityServer), {observe: 'response', params});
  }

  // Get By Id Account
  public getAccount = (route: string, id: string) => {
    return this.http.get<IAccount>(this.createCompleteRoute(route + `/${id}`, this.envUrl.identityServer));
  }

  // Create Account
  public createAccount = (route: string, model: IAccount) => {
    return this.http.post<{}>(this.createCompleteRoute(route, this.envUrl.identityServer), model, this.generateHeaders());
  }

  // Update Account
  public updateAccount = (route: string, model: IAccount, id: string) => {
    return this.http.put<{}>(this.createCompleteRoute(route + `/${id}`, this.envUrl.identityServer), model, this.generateHeaders());
  }

  // Delete Account
  public deleteAccount = (route: string, id: string) => {
    return this.http.delete<{}>(this.createCompleteRoute(route + `/${id}`, this.envUrl.identityServer));
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
