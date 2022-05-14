import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService implements HttpInterceptor {

  constructor(private _router: Router, private toastr: ToastrService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
    .pipe(
      catchError(error => {
        if(error.status === 400) {
          if(error.error.errors){
            throw error.error;
          } else {
            this.toastr.error(error.error.message, error.error.statusCode);
          }
        }
        if(error.status === 401) {
          this.toastr.error(error.error.detail, error.error.statusCode);
        }
        if(error.status === 404) {
          this._router.navigateByUrl('/not-found');
        }
        if(error.status === 422){
          let message = '';
          const values = Object.values(error.error.errors);
          values.map((m: any) => {
             message += m + '<br>';
          })
          return throwError(message.slice(0, -4));
        }
        if(error.status === 500) {
          const navigationExtras: NavigationExtras = 
            { state: {error: error.error} };
          this._router.navigateByUrl('/server-error', navigationExtras);
        }
      return throwError(error);
      })
    )
  }
}
