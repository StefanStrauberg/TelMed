import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IToken } from 'src/app/shared/models/login';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public errorMessage: string = '';
  ownerForm!: FormGroup;
  public showError!: boolean;
  
  constructor(
    private _authService: AuthService,
    private _router: Router) { }

  ngOnInit(): void {
    this.ownerForm = new FormGroup({
      login: new FormControl(null),
      password: new FormControl(null)
    })
  }

  loginUser() {
    if(this.ownerForm.valid)
    {
      this._authService.login('Api/Login', this.ownerForm.value).subscribe((response: IToken) => {
        console.log(response);
        // this._router.navigate(['/']).then();
      }, (error) => {
        this.errorMessage = error;
        this.showError = true;
        console.log(error);
        // this._router.navigate(['/auth']).then();
      })
    }
  }

}
