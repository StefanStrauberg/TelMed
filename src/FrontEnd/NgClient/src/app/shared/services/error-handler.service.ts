import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService implements HttpInterceptor {

  constructor(private _router: Router, private _toastr: ToastrService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if(error) {
          if(error.status === 400) {
            if(error.error.errors){
              throw error.error;
            } else {
              this._toastr.error(error.error.detail, error.error.statusCode);
            }
          }
          if(error.status === 401) {
            this._toastr.error(error.statusText, error.status);
          }
          if(error.status === 403) {
            this._toastr.error(error.statusText, error.status);
          }
          if(error.status === 404) {
            this._router.navigateByUrl('/not-found');
          }
          if(error.status === 500) {
            const navigationExtras: NavigationExtras = 
              { state: {error: error.error} };
            this._router.navigateByUrl('/server-error', navigationExtras);
          }
        }
        return throwError(error);
      })
    );
  }

}
