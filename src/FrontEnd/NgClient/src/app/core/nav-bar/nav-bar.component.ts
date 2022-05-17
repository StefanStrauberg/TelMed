import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  public isUserAuthenticated: boolean = false;

  constructor(private _authService: AuthService) { }

  ngOnInit(): void {
    this._authService.loginChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }

  public login = () => {
    this._authService.login();
  }
  public logout = () => {
    this._authService.logout();
  }

}
