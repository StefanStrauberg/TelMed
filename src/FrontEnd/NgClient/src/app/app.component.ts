import { Component } from '@angular/core';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public isUserAuthenticated = false;
  public isUserAdmin = false;

  constructor(private _authService: AuthService) {
    this._authService.loginChanged
    .subscribe(userAuthenticated => {
      this.isUserAuthenticated = userAuthenticated;
      this.checkAdmin();
    })
  }

  ngOnInit(): void {
    this._authService.isAuthenticated()
    .then(userAuthenticated => {
      this.isUserAuthenticated = userAuthenticated;
    });
    this.checkAdmin();
  }

  private checkAdmin() {
    if(this.isUserAuthenticated)
    {
      this._authService.checkIfUserIsAdmin()
      .then(res => {
        this.isUserAdmin = res;
      });
    }
  }

  public login = () => {
    this._authService.login();
  }
  public logout = () => {
    this._authService.logout();
  }
}
