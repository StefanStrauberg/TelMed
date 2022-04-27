import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { IAccount } from '../shared/models/account';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl: string = "http://localhost:5050/api/Account";

  constructor(private http: HttpClient) { }

  // Get All Accounts
  getAccounts(): Observable<IAccount[]> {
    return this.http.get<IAccount[]>(this.baseUrl)
      .pipe(catchError(this.handleError));
  }

  // Get By Id Account
  getAccount(id: string): Observable<IAccount> {
    return this.http.get<IAccount>(this.baseUrl + `/${id}`)
    .pipe(catchError(this.handleError));
  }

  // Create Account
  createAccount(model: IAccount): Observable<{}> {
    return this.http.post<{}>(this.baseUrl, model)
      .pipe(catchError(this.handleError));
  }

  // Update Account
  updateAccount(model: IAccount, id: string): Observable<{}> {
    return this.http.put<{}>(this.baseUrl + `/${id}`, model)
      .pipe(catchError(this.handleError));
  }

  // Delete Account
  deleteAccount(id: string): Observable<{}> {
    return this.http.delete<{}>(this.baseUrl + `/${id}`)
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
