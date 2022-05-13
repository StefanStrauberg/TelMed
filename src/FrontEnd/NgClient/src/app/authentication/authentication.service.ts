import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ILogin, IToken } from '../shared/models/login';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseAccountUrl: string = 'api/Login';
  private _authChangeSub = new Subject<boolean>();
  public authChanged = this._authChangeSub.asObservable();

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public loginUser = (model: ILogin) => {
    return this.http.post<IToken>(this.createCompleteRoute(this.baseAccountUrl, this.envUrl.identityServer), model);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }
}
