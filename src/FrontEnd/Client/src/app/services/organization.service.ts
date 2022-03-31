import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { IOrganization } from '../models/IOrganization';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {

  stringUrl: string = 'http://localhost:3000';

  constructor(private httpClient: HttpClient) { }

  //Get All Organizations
  getAllOrganizations(): Observable<IOrganization[]> {
    let dataUrl: string = `${this.stringUrl}/organizations`;
    return this.httpClient.get<IOrganization[]>(dataUrl).pipe(catchError(this.handleError));
  }

  //Get Organizations By Id
  getOrganization(organizationId: string): Observable<IOrganization>{
    let dataUrl: string = `${this.stringUrl}/organizations/${organizationId}`;
    return this.httpClient.get<IOrganization>(dataUrl).pipe(catchError(this.handleError));
  }

  //Create Organization
  createOrganization(organization: IOrganization): Observable<IOrganization>{
    let dataUrl: string = `${this.stringUrl}/organizations`;
    return this.httpClient.post<IOrganization>(dataUrl, organization).pipe(catchError(this.handleError));
  }

  //Update Organization
  updateOrganization(organization: IOrganization, organizationId: string): Observable<IOrganization>{
    let dataUrl: string = `${this.stringUrl}/organizations/${organizationId}`;
    return this.httpClient.put<IOrganization>(dataUrl, organization).pipe(catchError(this.handleError));
  }

  // Error Handling
  handleError(error: HttpErrorResponse){
    let errorMessage: string = '';
    if(error.error instanceof ErrorEvent){
      errorMessage = `Error: ${error.error.message}`;
    }
    else{
      errorMessage = `Status: ${error.status} \n Message: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
