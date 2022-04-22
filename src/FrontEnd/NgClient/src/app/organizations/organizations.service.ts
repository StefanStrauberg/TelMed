import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { IOrganization } from '../shared/models/organization';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrganizationsService {
  baseUrl = 'http://localhost:5010/organization';

  constructor(private http: HttpClient) { }

  // Get All Organizations
  getOrganizations(): Observable<IOrganization[]> {
    return this.http.get<IOrganization[]>(this.baseUrl)
      .pipe(catchError(this.handleError));
  }

  // Get By Id Organization
  getOrganization(id: string): Observable<IOrganization> {
    return this.http.get<IOrganization>(this.baseUrl + `/${id}`)
    .pipe(catchError(this.handleError));
  }

  // Create Organization
  createOrganization(model: IOrganization): Observable<{}> {
    return this.http.post<{}>(this.baseUrl, model)
      .pipe(catchError(this.handleError));
  }

  // Update Organization
  updateOrganization(model: IOrganization, id: string): Observable<{}> {
    return this.http.put<{}>(this.baseUrl + `/${id}`, model)
      .pipe(catchError(this.handleError));
  }

  // Delete Organization
  deleteOrganization(id: string): Observable<{}> {
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