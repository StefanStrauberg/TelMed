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
    if(roles === "Doctor") {
      return this.checkUserRole("Doctor");
    }
    else{
      return this.checkUserRole("Administrator");
    }
  }

  private checkIsUserAuthenticated() {
    return this._authService.isAuthenticated()
    .then(res => {
      return res ? true : this.redirectToUnauthorized();
    })
  }
  
  private checkUserRole(userRole: string) {
    return this._authService.checkUserRole(userRole)
      .then(res => {
        return res ? true : this.redirectToUnauthorized();
      })
  }

  private redirectToUnauthorized() {
    this._router.navigate(['/']);
    return false;
  }

}
