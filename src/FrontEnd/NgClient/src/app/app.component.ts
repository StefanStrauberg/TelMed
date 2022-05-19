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
  public isUserDocktor = false;

  constructor(private _authService: AuthService) {
    this._authService.loginChanged
    .subscribe(userAuthenticated => {
      this.isUserAuthenticated = userAuthenticated;
      this.checkAdmin();
      this.checkDocktor();
    })
  }

  ngOnInit(): void {
    this._authService.isAuthenticated()
    .then(userAuthenticated => {
      this.isUserAuthenticated = userAuthenticated;
    });
    this.checkAdmin();
    this.checkDocktor();
  }

  private checkAdmin() {
    if(this.isUserAuthenticated)
    {
      this._authService.checkUserRole("Administrator")
      .then(res => {
        this.isUserAdmin = res;
      });
    }
  }

  private checkDocktor() {
    if(this.isUserAuthenticated)
    {
      this._authService.checkUserRole("Doctor")
      .then(res => {
        this.isUserDocktor = res;
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
