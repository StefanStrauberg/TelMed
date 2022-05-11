import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin, IToken } from '../shared/models/login';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseAccountUrl: string = 'api/Account/Login';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public loginUser = (model: ILogin) => {
    return this.http.post<IToken>(this.createCompleteRoute(this.baseAccountUrl, this.envUrl.identityServer), model);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
