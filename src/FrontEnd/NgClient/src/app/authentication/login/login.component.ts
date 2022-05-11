import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  errorMessage: string = '';
  showError!: boolean;
  
  constructor(
    private authService: AuthenticationService,
    private router: Router) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      login: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
  }

  public loginUser = () => {
    this.showError = false;
    this.authService.loginUser(this.loginForm.value).subscribe(res => {
      localStorage.setItem("token", res.token);
      this.router.navigate(["/"]);
    },
    (error) => {
      this.errorMessage = error;
      this.showError = true;
    })
  }
}
