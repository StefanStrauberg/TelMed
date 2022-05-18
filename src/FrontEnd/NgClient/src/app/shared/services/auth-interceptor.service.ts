import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { Constants } from '../Constants';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private _authService: AuthService) { }
  
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(req.url.startsWith(Constants.apiRoot)){
      return from(
        this._authService.getAccessToken()
        .then(token => {
          const headers = req.headers.set('Authorization', `Bearer ${token}`);
          const authRequest = req.clone({ headers });
          return <any>(next.handle(authRequest).toPromise());
        })
      );
    }
    else {
      return next.handle(req);
    }
  }
}
