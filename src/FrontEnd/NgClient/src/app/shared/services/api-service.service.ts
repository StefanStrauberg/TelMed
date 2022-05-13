import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin, IToken } from '../models/login';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public Login = (route: string, body: ILogin) => {
    return this.http.post<IToken>(this.createCompleteRoute(route, this.envUrl.identityServer), body);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
