import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {
  isUserAdmin!: boolean;
  isUserDoctor!: boolean;

  constructor(private _authService: AuthService) { }

  ngOnInit(): void {
    this._authService.loginChanged
      .subscribe(res => {
        this.isAdmin();
    })
  }

  public isAdmin = () => {
    return this._authService.checkIfUserIsAdmin()
    .then(res => {
      this.isUserAdmin = res;
    })
  }

}
