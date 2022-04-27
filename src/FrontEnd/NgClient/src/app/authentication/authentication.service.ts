import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { IAccount } from '../shared/models/account';
import { UserForRegistrationDto } from '../shared/models/registration';
import { RegistrationResponseDto } from '../shared/models/registrationResponse';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl: string = "http://localhost:5050/api/Account";

  constructor(private http: HttpClient,
    private envUrl: EnvironmentUrlService) { }

  registerUser = (route: string, body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  // Get All Users
  getOrganizations() : Observable<IAccount[]> {
    return this.http.get<IAccount[]>(this.baseUrl + "/GetUsers")
    .pipe(catchError(this.handleError));
  }

  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
