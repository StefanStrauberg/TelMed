import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from } from 'rxjs';
import { IAccount, IRole } from '../shared/models/account';
import { IPagination } from '../shared/models/pagination';
import { Params } from '../shared/models/params';
import { AuthService } from '../shared/services/auth.service';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(
    private _http: HttpClient,
    private _envUrl: EnvironmentUrlService,
    private _authService: AuthService) { }

  // Get All Roles
  public getRoles = (route: string) => {
    return this._http.get<IRole[]>(this.createCompleteRoute(route, this._envUrl.identityServer));
  }

  // Get All Accounts
  public getAccounts = (route: string, specParams: Params) => {
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
        return this._http.get<IAccount[]>(this.createCompleteRoute(route, this._envUrl.identityServer), { headers: headers }).toPromise();
      })
    );
  }

  // Get By Id Account
  public getAccount = (route: string) => {
    return this._http.get<IAccount>(this.createCompleteRoute(route, this._envUrl.identityServer));
  }

  // Create Account
  public createAccount = (route: string, model: IAccount) => {
    return this._http.post<{}>(this.createCompleteRoute(route, this._envUrl.identityServer), model, this.generateHeaders());
  }

  // Update Account
  public updateAccount = (route: string, model: IAccount) => {
    return this._http.put<{}>(this.createCompleteRoute(route, this._envUrl.identityServer), model, this.generateHeaders());
  }

  // Delete Account
  public deleteAccount = (route: string) => {
    return this._http.delete<{}>(this.createCompleteRoute(route, this._envUrl.identityServer));
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
