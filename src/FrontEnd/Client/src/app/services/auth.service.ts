import { Injectable } from '@angular/core';
import { User, UserManager, UserManagerSettings } from 'oidc-client';
import { Subject } from 'rxjs';
import { Constants } from '../shared/constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _userManager!: UserManager;
  private _user!: User;
  private _loginChangedSubject = new Subject<boolean>();

  constructor() {
    this._userManager = new UserManager(this.idpSettings);
  }

  private checkUser = (user : User): boolean => {
    return !!user && !user.expired;
  }

  private get idpSettings() : UserManagerSettings {
    return {
      authority: Constants.idpAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}/signin-callback`,
      scope: "openid profile companyApi",
      response_type: "code",
      post_logout_redirect_uri: `${Constants.clientRoot}/signout-callback`
    }
  }

  public login = () => {
    return this._userManager.signinRedirect();
  }

  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser()
    .then(user => {
      if(this._user !== user){
        this._loginChangedSubject.next(this.checkUser(user!));
      }
      this._user = user!;
        
      return this.checkUser(user!);
    })
  }

  public loginChanged = this._loginChangedSubject.asObservable();
}
