import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { ILogin } from '../shared/models/login';
import { ApiServiceService } from '../shared/services/api-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _isLoggedIn$ = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this._isLoggedIn$.asObservable();

  constructor(private apiService: ApiServiceService) { }

  public login = (model: ILogin) => {
    return this.apiService.Login('api/Login', model).pipe(
      tap((response: any) => {
        this._isLoggedIn$.next(true);
        localStorage.setItem('token', response.token);
      })
    );
  }

  public logout = () => {
    localStorage.removeItem("token");
    this._isLoggedIn$.next(true);
  }
}
