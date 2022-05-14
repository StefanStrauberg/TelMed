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
  ownerForm!: FormGroup;
  
  constructor(
    private _authService: AuthService,
    private _router: Router) { }

  ngOnInit(): void {
    this.ownerForm = new FormGroup({
      login: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required)
    })
  }

  loginUser() {
    if(this.ownerForm.valid)
    {
      this._authService.login('Api/Login2', this.ownerForm.value).subscribe((response: IToken) => {
        console.log(response);
        // this._router.navigate(['/']).then();
      }, (error) => {
        console.log(error);
        // this._router.navigate(['/auth']).then();
      })
    }
  }

}
