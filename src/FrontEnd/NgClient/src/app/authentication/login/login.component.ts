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
  
  loginForm = new FormGroup({
    login: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required])
  })
  
  constructor(
    private authService: AuthenticationService,
    private router: Router) { }

  ngOnInit(): void {
  }

  public loginUser = () => {
    this.authService.login(this.loginForm.value).subscribe(response => {
      this.router.navigate(['/']);
    });
  }
}
