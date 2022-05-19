import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private _authService: AuthService, private _router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const roles = route.data['roles'] as string;
    if(!roles) {
      return this.checkIsUserAuthenticated();
    }
    else{
      return this.checkForAdministrator();
    }
  }

  private checkIsUserAuthenticated() {
    return this._authService.isAuthenticated()
    .then(res => {
      console.log(`Guard isAuthenticated: ${res}`);
      return res ? true : this.redirectToUnauthorized();
    })
  }
  
  private checkForAdministrator() {
    return this._authService.checkIfUserIsAdmin()
      .then(res => {
        console.log(`Guard checkIfUserIsAdmin: ${res}`);
        return res ? true : this.redirectToUnauthorized();
      })
  }

  private redirectToUnauthorized() {
    this._router.navigate(['/']);
    return false;
  }

}
