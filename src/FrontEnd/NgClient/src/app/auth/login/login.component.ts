import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IToken } from 'src/app/shared/models/login';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  ownerForm!: FormGroup;
  private _returnUrl!: string;
  
  constructor(
    private _route: ActivatedRoute,
    private _authService: AuthService,
    private _router: Router) { }

  ngOnInit(): void {
    this.ownerForm = new FormGroup({
      login: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required)
    });
    this._returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
  }

  loginUser() {
    if(this.ownerForm.valid)
    {
      this._authService.login('Api/Login', this.ownerForm.value).subscribe((response: IToken) => {
        console.log(response);
        localStorage.setItem("token", response.token);
        this._authService.sendAuthStateChangeNotification(response.isAuthSuccessful);
        this._router.navigate([this._returnUrl]);
      }, (error) => {
        console.log(error);
        this._router.navigate(['/auth']).then();
      })
    }
  }

}
